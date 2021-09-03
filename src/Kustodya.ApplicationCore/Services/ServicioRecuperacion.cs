using System;
using System.Collections.Generic;
using System.Text; 
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Specifications;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Interfaces.Configuracion.Email;

namespace Kustodya.ApplicationCore.Services
{
    public class ServicioRecuperacion : IServicioRecuperacion
    {
        private readonly IAsyncRepository<TblUsuarios> _usuariosRepo;
        private readonly IEmailService _emailService;
        
        public ServicioRecuperacion(IAsyncRepository<TblUsuarios> usuariosRepo, IEmailService emailService)
        {
            _usuariosRepo = usuariosRepo;
            _emailService = emailService;
        }
        public async Task Recuperar(string origin, string template, string requestPasswordUrl, TblUsuarios u)
        {
            u.RecuperacionContrasena();
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                { "username", u.TPrimerNombre + " " + u.TPrimerApellido },
                { "link", requestPasswordUrl },
                { "origin", origin }
            };
            await _emailService.SendEmailAsync(u.TEmail, template, dictionary);
            await _usuariosRepo.UpdateAsync(u);
        }
    }
}
