using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.Entities.Administracion;
using Kustodya.ApplicationCore.Entities.Concepto;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Specifications.Contabilidades;
using Kustodya.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kustodya.ApplicationCore.Entities.CalificacionOrigen;

namespace Kustodya.WebApi.Controllers.General
{
    [ApiController]
    [Authorize]
    public class EnumeracionesController : ControllerBase
    {
        private IAsyncRepository<PronosticoConcepto> _pronosticoConceptoRepo;

        public EnumeracionesController(IAsyncRepository<PronosticoConcepto> pronosticoConceptoRepo)
        {
            _pronosticoConceptoRepo = pronosticoConceptoRepo;
        }

        [Route("api/Entidades/TipoIdentificacion")]
        [Route("api/Usuarios/TipoIdentificacion")]
        [HttpGet]
        public IActionResult ObtenerIdentificacion()
        {
            return Ok(((TipoIdentificacion[])Enum.GetValues(typeof(TipoIdentificacion)))
             .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList());
        }

        [Route("api/Direcciones/Via")]
        [HttpGet]
        public IActionResult ObtenerVia()
        {
            return Ok(((Via[])Enum.GetValues(typeof(Via)))
             .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList());
        }
        [Route("api/Entidades/Naturaleza")]
        [HttpGet]
        public IActionResult ObtenerNaturaleza()
        {
            return Ok(((Naturaleza[])Enum.GetValues(typeof(Naturaleza)))
             .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList());
        }
        [Route("api/Entidades/TipoEntidad")]
        [HttpGet]
        public IActionResult ObtenerTipoEntidad()
        {
            return Ok(((TipoEntidad[])Enum.GetValues(typeof(TipoEntidad)))
             .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList());
        }
        [Route("api/Entidades/TipoSociedad")]
        [HttpGet]
        public IActionResult ObtenerTipoSociedad()
        {
            return Ok(((Sociedad[])Enum.GetValues(typeof(Sociedad)))
             .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList());
        }
        [Route("api/Entidades/Regimen")]
        [HttpGet]
        public IActionResult ObtenerRegimen()
        {
            return Ok(((Regimen[])Enum.GetValues(typeof(Regimen)))
             .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList());
        }
        [Route("api/Entidades/TipoCliente")]
        [HttpGet]
        public IActionResult ObtenerTipoCliente()
        {
            return Ok(((TipoCliente[])Enum.GetValues(typeof(TipoCliente)))
             .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList());
        }
        [Route("api/Usuarios/Sexos")]
        [HttpGet]
        public IActionResult ObtenerSexos()
        {
            return Ok(((Sexos[])Enum.GetValues(typeof(Sexos)))
             .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList());
        }
        [Route("api/Usuarios/RedesSociales")]
        [HttpGet]
        public IActionResult ObtenerRedesSociales()
        {
            return Ok(((RedSocial[])Enum.GetValues(typeof(RedSocial)))
             .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList());
        }
        
        [Route("api/Contabilidades/EstadosDepuracion")]
        [HttpGet]
        public IActionResult ObtenerEstadosComprobante()
        {
            return Ok(((DepuracionContable.EstadoDepuracion[])Enum.GetValues(typeof(DepuracionContable.EstadoDepuracion)))
             .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList());
        }
        [Route("api/Entidades/TipoRelacion")]
        [HttpGet]
        public IActionResult ObtenerTipoRelacion()
        {
            return Ok(((TipoRelacion[])Enum.GetValues(typeof(TipoRelacion)))
             .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList());
        }
        // [Route("api/Contabilidades/TipoAjuste")]
        // [HttpGet]
        // public IActionResult ObtenerTipoAjuste()
        // {
        //     return Ok(((TipoAjuste[])Enum.GetValues(typeof(TipoAjuste)))
        //      .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList());
        // }
        [Route("api/Contabilidades/TipoContabilidad")]
        [HttpGet]
        public IActionResult ObtenerTipoContabilidad()
        {
            return Ok(((Puc.TiposContabilidad[])Enum.GetValues(typeof(Puc.TiposContabilidad)))
             .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList());
        }
        [Route("api/Contabilidades/TipoPlantillaContable")]
        [HttpGet]
        public IActionResult ObtenerTipoPlantillaContable()
        {
            return Ok(((Plantilla.TiposPlantillaContable[])Enum.GetValues(typeof(Plantilla.TiposPlantillaContable)))
             .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList());
        }
        [Route("api/Entidades/TipoPersona")]
        [Route("api/Terceros/TipoPersona")]
        [HttpGet]
        public IActionResult ObtenerTipoPersona()
        {
            return Ok(((TiposPersona[])Enum.GetValues(typeof(TiposPersona)))
             .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList());
        }
        [Route("api/Auditoria/Acciones")]
        [HttpGet]
        public IActionResult ObtenerAuditoriaAcciones()
        {
            return Ok(((Auditoria.TipoAccion[])Enum.GetValues(typeof(Auditoria.TipoAccion)))
             .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList());
        }
        [Route("api/ConceptoRehabilitacion/Estados")]
        [HttpGet]
        public IActionResult ObtenerConceptoRehabilitacionEstados()
        {
            return Ok(((PacientesPorEmitir.EstadoConcepto[])Enum.GetValues(typeof(PacientesPorEmitir.EstadoConcepto)))
             .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList());
        }

        [Route("api/ConceptoRehabilitacion/Diagnostico/Etiologias")]
        [HttpGet]
        public IActionResult ConceptoRehabilitacionDiagnosticoEtiologias()
        {
            return Ok(((Diagnostico.TipoEtiologia[])Enum.GetValues(typeof(Diagnostico.TipoEtiologia)))
             .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList());
        }

        [Route("api/ConceptoRehabilitacion/Secuela/Tipos")]
        [HttpGet]
        public IActionResult ConceptoRehabilitacionSecuelaTipos()
        {
            return Ok(((Secuela.TipoSecuela[])Enum.GetValues(typeof(Secuela.TipoSecuela)))
             .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList());
        }
        [Route("api/ConceptoRehabilitacion/Secuela/Pronosticos")]
        [HttpGet]
        public IActionResult ConceptoRehabilitacionSecuelaPronostico()
        {
            return Ok(((Secuela.TipoPronostico[])Enum.GetValues(typeof(Secuela.TipoPronostico)))
             .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList());
        }
        [Route("api/ConceptoRehabilitacion/FinalidadTratamientos")]
        [HttpGet]
        public IActionResult ConceptoRehabilitacionFinalidadTratamientos()
        {
            return Ok(((ConceptoRehabilitacion.TipoFinalidad[])Enum.GetValues(typeof(ConceptoRehabilitacion.TipoFinalidad)))
             .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList());
        }
        [Route("api/ConceptoRehabilitacion/Plazos")]
        [HttpGet]
        public IActionResult ConceptoRehabilitacionPlazos()
        {
            return Ok(((ConceptoRehabilitacion.TipoPlazo[])Enum.GetValues(typeof(ConceptoRehabilitacion.TipoPlazo)))
             .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList());
        }
        [Route("api/ConceptoRehabilitacion/Conceptos")]
        [HttpGet]
        public async Task<IActionResult> ConceptoRehabilitacionConceptos()
        {
            var conceptos =  await _pronosticoConceptoRepo.ListAllAsync();
            return Ok(conceptos);
            /*return Ok(((ConceptoRehabilitacion.TipoConcepto[])Enum.GetValues(typeof(ConceptoRehabilitacion.TipoConcepto)))
             .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList());*/
        }
        [Route("api/CalificacionOrigen/Estados")]
        [HttpGet]
        public IActionResult CalificacionOrigenEstados()
        {
            return Ok(((Correo.EstadoCorreo[])Enum.GetValues(typeof(Correo.EstadoCorreo)))
             .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList());
        }
    }
}