using System.Threading.Tasks;
using Kustodya.WebApi.Controllers.Contabilidades.Modelo;
using Kustodya.WebApi.Models.Contabilidades;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Kustodya.WebApi.Controllers.Contabilidades
{
    public interface IClasesDocumentoOutputModelService
    {
        Task<OutputModel<ClaseDocumentoOutputModel>> GetOutputModelsAsync(string codigoContabilidad, int entidadId, string busqueda, int pagina = 1);
        Task<ClaseDocumentoOutputModel> GetOutputModelAsync(string codigoContabilidad, int entidadId, string descripcion);
        Task<OutputModel<ClaseDocumentoOutputModel>> GetOutputModelsAsync(int entidadId, string busqueda, int pagina = 1);
    }
}