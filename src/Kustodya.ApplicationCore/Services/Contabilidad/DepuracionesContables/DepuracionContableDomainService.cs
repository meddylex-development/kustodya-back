using System;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.DTOs.DepuracionesContables;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Services;
using Kustodya.ApplicationCore.Specifications.Contabilidades;
using Kustodya.ApplicationCore.Services.DepuracionesContables;
using Kustodya.ApplicationCore.Interfaces.Configuracion.Email;

namespace Kustodya.ApplicationCore.Services.DepuracionesContables
{

    public class DepuracionContableDomainService : 
        BaseDomainService<
            DepuracionContable,
            DepuracionContableInputModel,
            IAsyncContabilidadRepository<DepuracionContable>>,
        IDepuracionContableDomainService
    {
        #region DI
        private IAsyncContabilidadRepository<Contabilidad> _repoContabilidad;
        private IAsyncContabilidadRepository<ClaseDocumento> _repoClaseDocumento;
        private IEmailService _emailService;

        public DepuracionContableDomainService(
            IAsyncContabilidadRepository<DepuracionContable> repo
            , IAsyncContabilidadRepository<Contabilidad> repoContabilidad
            , IAsyncContabilidadRepository<ClaseDocumento> repoClaseDocumento,
            IEmailService emailService
            )
            : base(repo)
        {
            _repoContabilidad = repoContabilidad;
            _repoClaseDocumento = repoClaseDocumento;
            _emailService = emailService;
        }
        #endregion

        public override async Task<DepuracionContable> ActualizarAsync(int entidadId, Guid Id, DepuracionContableInputModel inputModel, int userId)
        {
            var depuracionContable = await GetDepuracionContableAsync(Id, entidadId);

            Guid ClaseDocumentoId = await GetClaseDocumentoIdAsync(inputModel.ClaseDocumento, entidadId);

            if (inputModel.EstadoRevisor != null && (depuracionContable.Estado == DepuracionContable.EstadoDepuracion.Aprobada || 
                depuracionContable.Estado == DepuracionContable.EstadoDepuracion.Rechazada)) {
                throw new Exception("El estado de la depuración no permite hacer gestión de la misma");
            }
            if (inputModel.EstadoRevisor != null) { 
                if(inputModel.EstadoRevisor == DepuracionContable.EstadoRevisor.Rechazada && (inputModel.NotaRevisor == "" || inputModel.NotaRevisor == null))
                    throw new Exception("La nota del revisor no puede estar vacía cuando la depuración es rechazada");
            }

            if (inputModel.EstadoRevisor != null && depuracionContable.Estado == DepuracionContable.EstadoDepuracion.Aprobada_Contador)
            {
                switch (inputModel.EstadoRevisor)
                {
                    case DepuracionContable.EstadoRevisor.Aprobada:
                        if (depuracionContable.Operativo_1_Id == userId)
                        {
                            depuracionContable.NotaOpertaivo_1 = inputModel.NotaRevisor;
                            depuracionContable.Estado = DepuracionContable.EstadoDepuracion.Aprobada;
                            depuracionContable.EstadoAprobacionOperativo_1_Id = DepuracionContable.EstadoRevisor.Aprobada;
                        }
                        else if (depuracionContable.Operativo_2_Id == userId)
                        {
                            depuracionContable.NotaOpertaivo_2 = inputModel.NotaRevisor;
                            depuracionContable.Estado = DepuracionContable.EstadoDepuracion.Aprobada;
                            depuracionContable.EstadoAprobacionOperativo_2_Id = DepuracionContable.EstadoRevisor.Aprobada;
                        }
                        else
                        {
                            throw new Exception("El usuario no es el aprobador asignado");
                        }
                        break;
                    case DepuracionContable.EstadoRevisor.Rechazada:
                        if (depuracionContable.Operativo_1_Id == userId)
                        {
                            depuracionContable.NotaOpertaivo_1 = inputModel.NotaRevisor;
                            depuracionContable.Estado = DepuracionContable.EstadoDepuracion.Rechazada;
                            depuracionContable.EstadoAprobacionOperativo_1_Id = DepuracionContable.EstadoRevisor.Rechazada;
                        }
                        else if (depuracionContable.Operativo_2_Id == userId)
                        {
                            depuracionContable.NotaOpertaivo_2 = inputModel.NotaRevisor;
                            depuracionContable.Estado = DepuracionContable.EstadoDepuracion.Rechazada;
                            depuracionContable.EstadoAprobacionOperativo_2_Id = DepuracionContable.EstadoRevisor.Rechazada;
                        }
                        else
                        {
                            throw new Exception("El usuario no es el aprobador asignado");
                        }
                        break;
                    default:
                        break;
                }
            }

            if (inputModel.EstadoRevisor != null && depuracionContable.Estado == DepuracionContable.EstadoDepuracion.Aprobada_Operativo)
            {
                switch (inputModel.EstadoRevisor)
                {
                    case DepuracionContable.EstadoRevisor.Aprobada:
                        if (depuracionContable.Contador_1_Id == userId)
                        {
                            depuracionContable.NotaContador_1 = inputModel.NotaRevisor;
                            depuracionContable.Estado = DepuracionContable.EstadoDepuracion.Aprobada;
                            depuracionContable.EstadoAprobacionContador_1_Id = DepuracionContable.EstadoRevisor.Aprobada;
                        }
                        else if (depuracionContable.Contador_2_Id == userId)
                        {
                            depuracionContable.NotaContador_2 = inputModel.NotaRevisor;
                            depuracionContable.Estado = DepuracionContable.EstadoDepuracion.Aprobada;
                            depuracionContable.EstadoAprobacionContador_2_Id = DepuracionContable.EstadoRevisor.Aprobada;
                        }
                        else
                        {
                            throw new Exception("El usuario no es el aprobador asignado");
                        }
                        break;
                    case DepuracionContable.EstadoRevisor.Rechazada:
                        if (depuracionContable.Contador_1_Id == userId)
                        {
                            depuracionContable.NotaContador_1 = inputModel.NotaRevisor;
                            depuracionContable.Estado = DepuracionContable.EstadoDepuracion.Rechazada;
                            depuracionContable.EstadoAprobacionContador_1_Id = DepuracionContable.EstadoRevisor.Rechazada;
                        }
                        else if (depuracionContable.Contador_2_Id == userId) 
                        {
                            depuracionContable.NotaContador_2 = inputModel.NotaRevisor;
                            depuracionContable.Estado = DepuracionContable.EstadoDepuracion.Rechazada;
                            depuracionContable.EstadoAprobacionContador_2_Id = DepuracionContable.EstadoRevisor.Rechazada;
                        }
                        else
                        {
                            throw new Exception("El usuario no es el aprobador asignado");
                        }
                        break;
                    default:
                        break;
                }
            }

            if (inputModel.EstadoRevisor != null && depuracionContable.Estado == DepuracionContable.EstadoDepuracion.Preaprobada)
            {
                switch (inputModel.EstadoRevisor)
                {
                    case DepuracionContable.EstadoRevisor.Aprobada:
                        if (depuracionContable.Contador_1_Id == userId)
                        {
                            depuracionContable.NotaContador_1 = inputModel.NotaRevisor;
                            depuracionContable.Estado = DepuracionContable.EstadoDepuracion.Aprobada_Contador;
                            depuracionContable.EstadoAprobacionContador_1_Id = DepuracionContable.EstadoRevisor.Aprobada;
                        }
                        else if(depuracionContable.Contador_2_Id == userId){
                            depuracionContable.NotaContador_2 = inputModel.NotaRevisor;
                            depuracionContable.Estado = DepuracionContable.EstadoDepuracion.Aprobada_Contador;
                            depuracionContable.EstadoAprobacionContador_2_Id = DepuracionContable.EstadoRevisor.Aprobada;
                        }
                        else if (depuracionContable.Operativo_1_Id == userId)
                        {
                            depuracionContable.NotaOpertaivo_1 = inputModel.NotaRevisor;
                            depuracionContable.Estado = DepuracionContable.EstadoDepuracion.Aprobada_Operativo;
                            depuracionContable.EstadoAprobacionOperativo_1_Id = DepuracionContable.EstadoRevisor.Aprobada;
                        }
                        else if (depuracionContable.Operativo_2_Id == userId)
                        {
                            depuracionContable.NotaOpertaivo_2 = inputModel.NotaRevisor;
                            depuracionContable.Estado = DepuracionContable.EstadoDepuracion.Aprobada_Operativo;
                            depuracionContable.EstadoAprobacionOperativo_2_Id = DepuracionContable.EstadoRevisor.Aprobada;
                        }
                        else {
                            throw new Exception("El usuario no es el aprobador asignado");
                        }
                        break;
                    case DepuracionContable.EstadoRevisor.Rechazada:
                        if (depuracionContable.Contador_1_Id == userId)
                        {
                            depuracionContable.NotaContador_1 = inputModel.NotaRevisor;
                            depuracionContable.Estado = DepuracionContable.EstadoDepuracion.Rechazada;
                            depuracionContable.EstadoAprobacionContador_1_Id = DepuracionContable.EstadoRevisor.Rechazada;
                        }
                        else if(depuracionContable.Contador_2_Id == userId)
                        {
                            depuracionContable.NotaContador_2 = inputModel.NotaRevisor;
                            depuracionContable.Estado = DepuracionContable.EstadoDepuracion.Rechazada;
                            depuracionContable.EstadoAprobacionContador_2_Id = DepuracionContable.EstadoRevisor.Rechazada;
                        }
                        else if (depuracionContable.Operativo_1_Id == userId)
                        {
                            depuracionContable.NotaOpertaivo_1 = inputModel.NotaRevisor;
                            depuracionContable.Estado = DepuracionContable.EstadoDepuracion.Rechazada;
                            depuracionContable.EstadoAprobacionOperativo_1_Id = DepuracionContable.EstadoRevisor.Rechazada;
                        }
                        else if (depuracionContable.Operativo_2_Id == userId)
                        {
                            depuracionContable.NotaOpertaivo_2 = inputModel.NotaRevisor;
                            depuracionContable.Estado = DepuracionContable.EstadoDepuracion.Rechazada;
                            depuracionContable.EstadoAprobacionOperativo_2_Id = DepuracionContable.EstadoRevisor.Rechazada;
                        }
                        else
                        {
                            throw new Exception("El usuario no es el aprobador asignado");
                        }
                        break;
                    default:
                        throw new Exception("El usuario no es el aprobador asignado");
                }
            }

            if (inputModel.EstadoRevisor != null && depuracionContable.Estado == DepuracionContable.EstadoDepuracion.PorPreaprobar)
            {
                switch (inputModel.EstadoRevisor)
                {
                    case DepuracionContable.EstadoRevisor.Aprobada:
                        //Se actualia el estado según quien preaprobo
                        if (depuracionContable.GerenteId == userId)
                        {
                            depuracionContable.EstadoAprobacionGerente = DepuracionContable.EstadoRevisor.Aprobada;
                            depuracionContable.NotaGerente = inputModel.NotaRevisor;
                        }
                        if (depuracionContable.CoordinadorId == userId)
                        {
                            depuracionContable.EstadoAprobacionCoordinador = DepuracionContable.EstadoRevisor.Aprobada;
                            depuracionContable.NotaCoordinador = inputModel.NotaRevisor;
                        }
                        if (depuracionContable.InterventorId == userId)
                        {
                            depuracionContable.EstadoAprobacionInterventor = DepuracionContable.EstadoRevisor.Aprobada;
                            depuracionContable.NotaInterventor = inputModel.NotaRevisor;
                        }

                        //Si la depuración contable es aprobada por los 3 preaprobadores de modifica el estado
                        //de la depuración y se envía correo al aprobador de famisanar
                        if (depuracionContable.EstadoAprobacionGerente == DepuracionContable.EstadoRevisor.Aprobada &&
                            depuracionContable.EstadoAprobacionCoordinador == DepuracionContable.EstadoRevisor.Aprobada &&
                            depuracionContable.EstadoAprobacionInterventor == DepuracionContable.EstadoRevisor.Aprobada)
                        {
                            depuracionContable.Estado = DepuracionContable.EstadoDepuracion.Preaprobada;
                            //enviar correo a preaprobadores
                            //await _emailService.SendEmailAsync("fabianvivas55@hotmail.com", "prueba", null);
                        }

                        break;
                    case DepuracionContable.EstadoRevisor.Rechazada:
                        if (depuracionContable.GerenteId == userId)
                        {
                            depuracionContable.EstadoAprobacionGerente = DepuracionContable.EstadoRevisor.Rechazada;
                            depuracionContable.NotaGerente = inputModel.NotaRevisor;
                        }
                        if (depuracionContable.CoordinadorId == userId)
                        {
                            depuracionContable.EstadoAprobacionCoordinador = DepuracionContable.EstadoRevisor.Rechazada;
                            depuracionContable.NotaCoordinador = inputModel.NotaRevisor;
                        }
                        if (depuracionContable.InterventorId == userId)
                        {
                            depuracionContable.EstadoAprobacionInterventor = DepuracionContable.EstadoRevisor.Rechazada;
                            depuracionContable.NotaInterventor = inputModel.NotaRevisor;
                        }
                        depuracionContable.Estado = DepuracionContable.EstadoDepuracion.Rechazada;
                        break;
                    default:
                        throw new Exception("El usuario no tiene asignada la depuración para gestionar");
                }
            }

            if (inputModel.EstadoRevisor != null && depuracionContable.Estado == DepuracionContable.EstadoDepuracion.Borrador)
            {
                if (inputModel.EstadoRevisor == DepuracionContable.EstadoRevisor.Terminada)
                {
                    depuracionContable.Estado = DepuracionContable.EstadoDepuracion.PorPreaprobar;
                }
                else
                {
                    throw new Exception("La depuración solo permite cambiar el estado a por preaprobar");
                }
            }

            if (depuracionContable.Estado == DepuracionContable.EstadoDepuracion.Borrador)
            {
                depuracionContable.Actualizar(depuracionContable.ContabilidadId, ClaseDocumentoId, inputModel.DescripcionFicha,
                    inputModel.Folios, inputModel.SituacionEncontrada, inputModel.Anexos, inputModel.DisposicionesLegales, inputModel.AccionesRealizadas, inputModel.Recomendaciones);
            }
            else {
                depuracionContable.Actualizar(depuracionContable.ContabilidadId, depuracionContable.ClaseDocumentoId, depuracionContable.DescripcionFicha,
                        depuracionContable.Folios, depuracionContable.SituacionEncontrada, depuracionContable.Anexos, depuracionContable.DisposicionesLegales, depuracionContable.AccionesRealizadas, depuracionContable.Recomendaciones);
            }

            await _repo.UpdateAsync(depuracionContable);
            return depuracionContable;
        }
        public override async Task<DepuracionContable> CrearAsync(int usuarioId, int entidadId, Guid contabilidadId, DepuracionContableInputModel inputModel)
        {
            var contabilidadSpec = new ContabilidadConEntidadSpec(contabilidadId, entidadId);
            var contabilidad = await _repoContabilidad.GetOneAsync(contabilidadSpec);
            AsegurarNoNulo(contabilidad);

            var claseDocumentoSpec = new ClaseDocumentoConDescripcionSpec(inputModel.ClaseDocumento, contabilidad.Id);
            var claseDocumento = await _repoClaseDocumento.GetOneAsync(claseDocumentoSpec);
            AsegurarNoNulo(claseDocumento);

            var depuracionContable = DepuracionContable.Nueva.Basica(
                usuarioId,
                contabilidad,
                claseDocumento,
                inputModel.DescripcionFicha,
                inputModel.Folios,
                inputModel.SituacionEncontrada,
                inputModel.Anexos,
                inputModel.DisposicionesLegales,
                inputModel.AccionesRealizadas,
                inputModel.Recomendaciones
            );
            depuracionContable.EntidadId = entidadId;
            depuracionContable.Estado = DepuracionContable.EstadoDepuracion.Borrador;
            return await _repo.AddAsync(depuracionContable);
        }
        private async Task<DepuracionContable> GetDepuracionContableAsync(Guid Id, int entidadId)
        {
            var spec = new DepuracionContableConIdSpec(Id, entidadId);
            var depuracionContable = await _repo.GetOneAsync(spec);
            AsegurarNoNulo(depuracionContable);
            return depuracionContable;
        }
        private async Task<Guid> GetContabilidadIdAsync(string codigo, int entidadId)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                throw new Exception("Se requiere el código de la contabilidad");
            var contabilidadSpec = new ContabilidadConCodigoSpec(codigo, entidadId);
            var contabilidad = await _repoContabilidad.GetOneAsync(contabilidadSpec);

            if (contabilidad is null)
                throw new Exception("No se encuentra el código de contabilidad");
            return contabilidad.Id;
        }
        private async Task<Guid> GetClaseDocumentoIdAsync(string codigo, int entidadId)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                throw new EntidadNoExisteException("Se requiere la clase de documento");
            var claseDocumentoSpec = new ClaseDocumentoConDescSpec(codigo, entidadId);
            var claseDocumento = await _repoClaseDocumento.GetOneAsync(claseDocumentoSpec);
            if (claseDocumento is null)
                throw new EntidadNoExisteException("No se encuentra la clase de documento");
            return claseDocumento.Id;
        }
    }
}