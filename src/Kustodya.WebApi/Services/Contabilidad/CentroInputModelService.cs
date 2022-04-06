using Kustodya.ApplicationCore.DTOs.Contabilidades;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Services.Contabilidades
{
    public class CentroInputModelService : ICentroInputModelService
    {
        private readonly IAsyncContabilidadRepository<ApplicationCore.Entities.Contabilidades.Contabilidad> _repoContabilidad;
        private readonly IAsyncContabilidadRepository<Segmento> _repoSegmento;
        private readonly IAsyncContabilidadRepository<Regional> _repoRegional;

        public CentroInputModelService(IAsyncContabilidadRepository<ApplicationCore.Entities.Contabilidades.Contabilidad> repoContabilidad,
            IAsyncContabilidadRepository<Segmento> repoSegmento, IAsyncContabilidadRepository<Regional> repoRegional) {
            _repoContabilidad = repoContabilidad;
            _repoSegmento = repoSegmento;
            _repoRegional = repoRegional;
        }


        public async Task<IReadOnlyList<CentroInputModel>> GetInputModel(DataTable dt, int entidadId) {
            //Validar existencia de registros en el archivo
            if (dt.Rows.Count == 0)
            {
                throw new Exception("El archivo no contiene información");
            }
            if (dt.Select("[Código Contabilidad] <>'' or [Código] <>'' or [Segmento] <>'' or [Regional] <>''", "[Código Contabilidad] desc").Length == 0)
                throw new Exception("Los campos Contabilidad, Código, Segmento y Regional son obligatorios");

            //Eliminar filas sin código de contabilidad
            dt = dt.Select("[Código Contabilidad] <>''", "[Código Contabilidad] desc").CopyToDataTable();

            //Validar existencia de registros en el archivo
            if (dt.Rows.Count == 0)
            {
                throw new Exception("El archivo no contiene información");
            }

            //Validar cantidad de columnas
            if (dt.Columns.Count != 5)
            {
                throw new Exception("La cantidad de columnas no corresponde con la estructura requerida " +
                    "(5 columnas: Código Contabilidad, Código, Descripción, Segmento y Regional)");
            }

            //Validar Nombre y Orden de las columnas
            if (dt.Columns[0].ColumnName != "Código Contabilidad" || dt.Columns[1].ColumnName != "Código"
                || dt.Columns[2].ColumnName != "Descripción" || dt.Columns[3].ColumnName != "Regional" || dt.Columns[4].ColumnName != "Segmento")
                throw new Exception("Los nombres de las columnas del archivo no corresponden con el orden y estructura requerida (Código Contabilidad, Código, Descripción, Regional y Segmento)");

            //Pasar DataTable a Listado de PucInputModel
            List<CentroInputModel> centros = new List<CentroInputModel>();
            foreach (DataRow item in dt.Rows)
            {
                if (item["Código Contabilidad"].ToString() == "" || item["Código"].ToString() == "" || item["Segmento"].ToString() == "" || item["Regional"].ToString() == "")
                    throw new Exception("Hay campos sin diligenciar en el archivo cargado");

                CentroInputModel centro = new CentroInputModel
                {
                    Contabilidad = item["Código Contabilidad"].ToString(),
                    Codigo = item["Código"].ToString(),
                    Descripcion = item["Descripción"].ToString(),
                    Segmento = item["Segmento"].ToString(),
                    Regional = item["Regional"].ToString()
                };
                centros.Add(centro);
            }
            //Validar existencia contabilidades
            IEnumerable<string> contabilidadInput = centros.Select(c => c.Contabilidad).Distinct();
            var contabilidades = await _repoContabilidad.ListAllAsync();
            contabilidades = contabilidades.Where(c => c.EntidadId == entidadId).ToList();
            foreach (string item in contabilidadInput)
            {
                if (!contabilidades.Select(c => c.Codigo).Contains(item))
                    throw new Exception("La contabilidad " + item + " no existe");
            }

            //Validar existencia segmentos
            IEnumerable<string> segmentosInput = centros.Select(c => c.Segmento).Distinct();
            var segmentos = await _repoSegmento.ListAllAsync();
            foreach (string item in segmentosInput)
            {
                if (!segmentos.Select(c => c.Descripcion).ToList().Contains(item))
                    throw new Exception("El segmento " + item + " no existe");
            }

            //Validar existencia regionales
            IEnumerable<string> regionalesInput = centros.Select(c => c.Regional).Distinct();
            var regionales = await _repoRegional.ListAllAsync();
            foreach (string item in regionalesInput)
            {
                if (!regionales.Select(c => c.Descripcion).ToList().Contains(item))
                    throw new Exception("La regional " + item + " no existe");
            }
            return centros;
        }
    }
}
