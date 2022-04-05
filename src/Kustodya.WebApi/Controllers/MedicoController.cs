using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Entities.Medicos;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Kustodya.WebApi.Controllers
{
    [Route("api/[controller]/")]
    public class MedicoController : BaseController
    {
        public MedicoController(IServiceScopeFactory serviceScopeFactory, IMapper mapper)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _mapper = mapper;
        }

        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IMapper _mapper;

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] List<MedicosInputModel> medicosInputModel)
        {
            var consultas = medicosInputModel.Select((consultarMedico, i) => ConsultarMedicos(consultarMedico, i)).ToArray();

            return Ok(Task.WhenAll(consultas).Result);
        }

        private async Task<MedicoOutputModel> ConsultarMedicos(MedicosInputModel medicoInputModel, int indice)
        {
            var outputmodel = new MedicoOutputModel
            {
                Errors = new List<Error>()
            };
            if (string.IsNullOrWhiteSpace(medicoInputModel.NumeroIdentificacion))
            {
                Error error = new Error(indice)
                {
                    Mensaje = $"{nameof(medicoInputModel.NumeroIdentificacion)} no puede ser nulo"
                };
                outputmodel.Errors.Add(error);
            }

            if (medicoInputModel.Tipo == null)
            {
                Error error = new Error(indice)
                {
                    Mensaje = $"{nameof(Type)} no puede ser nulo"
                };
                outputmodel.Errors.Add(error);
            }

            if (outputmodel.Errors.Count > 0)
                return outputmodel;

            var _medicoService = _serviceScopeFactory.CreateScope().ServiceProvider.GetService<IMedicoService>();
            Medico medico = new Medico();
            try
            {
                medico = await _medicoService
                        .GetMedicoAsync(medicoInputModel.NumeroIdentificacion, medicoInputModel.Tipo.Value);
            }
            catch (TaskCanceledException)
            {
                outputmodel.Errors.Add(new Error(indice) { Mensaje = "Nuestro servicio de consulta externa ha excedido el tiempo maximo de espera" });
            }

            var medicoOutputViewModel = (MedicoOutputModel)_mapper.Map(medico, outputmodel, typeof(Medico), typeof(MedicoOutputModel));
            return medicoOutputViewModel;
        }

    }
    public class MedicosInputModel
    {
        [FromQuery(Name = "NumeroIdentificacion")]
        public string NumeroIdentificacion { get; set; }
        [FromQuery(Name = "Tipo")]
        public TipoIdentificacion? Tipo { get; set; }
    }
}