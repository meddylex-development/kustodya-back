using Kustodya.ApplicationCore.Dtos.Configuracion.Notificaciones;
using Kustodya.ApplicationCore.Interfaces.Configuracion.Email;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Kustodya.Medicos.Data;

namespace Kustodya.Medicos.Services
{
    public class ServicioDeNotificaciones : IServicioDeNotificaciones
    {
        #region Inyeccion de dependencias
        public ServicioDeNotificaciones(IHttpClientFactory clientFactory, ILoggerFactory loggerFactory,
        IEmailService emailService)
        {
            _webApiClient = clientFactory.CreateClient("webApiClient");
            _logger = loggerFactory.CreateLogger(nameof(ServicioDeNotificaciones));
            _emailService = emailService;
        }

        private readonly HttpClient _webApiClient;
        private readonly ILogger _logger;
        private readonly IEmailService _emailService;
        #endregion
        
        private async Task<IReadOnlyList<string>> ConsultarCorreosAsync()
        {
            var response = await _webApiClient.GetAsync(string.Empty);
            var json = await response.Content.ReadAsStringAsync();
            var notificaciones = JsonConvert.DeserializeObject<List<UsuariosNotificacionesModel>>(json);

            // return new List<string> { "davidchaparro9894@gmail.com" };
            return notificaciones.Select(n => n.TEmail).ToList();
        }

        [FunctionName(nameof(ConsultarCorreosAsync))]
        public async Task<IReadOnlyList<string>> ConsultarCorreosAsync([ActivityTrigger] IDurableActivityContext context)
        {
            return await ConsultarCorreosAsync();
        }

        [FunctionName(nameof(EnviarCorreos))]
        public async Task EnviarCorreos([ActivityTrigger] IDurableActivityContext context)
        {
            //peticionId, nombreUsuario, nombreArchivo, idArchivo, fechaCargue
            var (listaCorreos, cargue) = context.GetInput<(List<string>, CargueMasivo)>();

            await EnviarCorreosDeFinalizacion(listaCorreos, cargue);
            await EnviarCorreosDeFinalizacion("dchaparro@roojo.tech", cargue);
        }

        private async Task EnviarCorreosDeFinalizacion(List<string> listaCorreos, CargueMasivo cargue)
        {
            var template = Environment.GetEnvironmentVariable("Email:Template");
            
            listaCorreos.ForEach(email =>
                _logger.LogInformation($"ℹ Orquestador - Enviando correo de finalización a {email}, con template {template}. Peticion {cargue.PeticionId}"));

            await _emailService.SendEmailListAsync(listaCorreos, template,
            new Dictionary<string, string>
            {
                { "nombreUsuario", cargue.NombreUsuario },
                { "nombreArchivo", cargue.NombreArchivo },
                { "peticionId", cargue.NombreArchivo },
                { "fechaCargue", cargue.Creado.ToString() }
            });
        }

        private async Task EnviarCorreosDeFinalizacion(string correo, CargueMasivo cargue)
        {
            var template = Environment.GetEnvironmentVariable("Email:Template");

            await _emailService.SendEmailAsync(correo, template,
            new Dictionary<string, string>
            {
                { "nombreUsuario", cargue.NombreUsuario },
                { "nombreArchivo", cargue.NombreArchivo },
                { "peticionId", cargue.NombreArchivo },
                { "fechaCargue", cargue.Creado.ToString() }
            });
        }
    }
}
