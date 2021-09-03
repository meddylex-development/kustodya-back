using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kustodya.WebApi.Controllers.Contabilidades.Modelo;
using Kustodya.WebApi.Models.Contabilidades;

namespace Kustodya.WebApi.Controllers.Contabilidades
{
    public class MockClasesDocumentoOutputModelService : IClasesDocumentoOutputModelService
    {
        private const string Pagina = "ServicioDeHomologacion/Pagina.json";

        public Task<ClaseDocumentoOutputModel> GetOutputModelAsync(string codigoContabilidad, int entidadId, string descripcion)
        {
            return Task.Run(() => new ClaseDocumentoOutputModel()
            {
                Descripcion = "Caja menor de la oficina",
                Contabilidad = "Roojo Bogota",
                EsClaseDocumentoPorDefecto = false
            });
        }

        public Task<OutputModel<ClaseDocumentoOutputModel>> GetOutputModelsAsync(string codigoContabilidad, int entidadId, string busqueda, int pagina = 1)
        {
            return Task.Run(() => new OutputModel<ClaseDocumentoOutputModel>(
                new List<ClaseDocumentoOutputModel>
                {
                    new ClaseDocumentoOutputModel()
                    {
                        Descripcion = "Caja menor de la oficina",
                        Contabilidad = "Roojo Bogota",
                        EsClaseDocumentoPorDefecto = false
                    },
                    new ClaseDocumentoOutputModel()
                    {
                        Descripcion = "Fondo de empleados",
                        Contabilidad = "Roojo Perth",
                        EsClaseDocumentoPorDefecto = false
                    },
                    new ClaseDocumentoOutputModel()
                    {
                        Descripcion = "Vaca pal almuerzo",
                        Contabilidad = "Roojo Bogota",
                        EsClaseDocumentoPorDefecto = false
                    },
                },
                1, 10));
        }

        public Task<OutputModel<ClaseDocumentoOutputModel>> GetOutputModelsAsync(int entidadId, string busqueda, int pagina = 1)
        {
            return Task.Run(() => new OutputModel<ClaseDocumentoOutputModel>(
                new List<ClaseDocumentoOutputModel>
                {
                    new ClaseDocumentoOutputModel()
                    {
                        Descripcion = "Caja menor de la oficina",
                        Contabilidad = "Roojo Bogota",
                        EsClaseDocumentoPorDefecto = false
                    },
                    new ClaseDocumentoOutputModel()
                    {
                        Descripcion = "Fondo de empleados",
                        Contabilidad = "Roojo Perth",
                        EsClaseDocumentoPorDefecto = false
                    },
                    new ClaseDocumentoOutputModel()
                    {
                        Descripcion = "Vaca pal almuerzo",
                        Contabilidad = "Roojo Bogota",
                        EsClaseDocumentoPorDefecto = false
                    },
                },
                1, 10));
        }
    }
}