using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kustodya.WebApi.Models.Contabilidades;
using Kustodya.ApplicationCore.Entities.Contabilidades;

namespace Kustodya.WebApi.Services.Contabilidades
{
public interface IContabilidadOutputModelService
    {
        Task<DetalleContabilidadOutputModel> GetContabilidadOutputModel(string codigo, int entidadId);
        Task<ContabilidadesOutputModel> GetListaContabilidadOutputModel(string busqueda, int entidadId, int pagina);
        Task<ContabilidadOutputModel> GetContabilidadOutputModel(ApplicationCore.Entities.Contabilidades.Contabilidad contabilidad);
    }
}