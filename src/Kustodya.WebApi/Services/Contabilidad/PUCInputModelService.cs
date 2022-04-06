using Kustodya.ApplicationCore.DTOs.Contabilidades;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.WebApi.Models.Contabilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Services.Contabilidades
{
    public class PUCInputModelService : IPUCInputModelService
    {
        private readonly IAsyncContabilidadRepository<ApplicationCore.Entities.Contabilidades.Contabilidad> _repoContabilidad;
        public PUCInputModelService(IAsyncContabilidadRepository<ApplicationCore.Entities.Contabilidades.Contabilidad> repoContabilidad) {
            _repoContabilidad = repoContabilidad;
        }
        public async Task<IReadOnlyList<PUCInputModel>> GetInputModel(DataTable dt, int entidadId) 
        {
            //Validar existencia de registros en el archivo
            if (dt.Rows.Count == 0)
            {
                throw new Exception("El archivo no contiene información");
            }
            if (dt.Select("[Código Contabilidad] <>''", "[Código Contabilidad] desc").Length == 0)
                throw new Exception("Debe diligenciar todos los campos de cada fila");

            //Eliminar filas sin código de contabilidad
            dt = dt.Select("[Código Contabilidad] <>''", "[Código Contabilidad] desc").CopyToDataTable();

            //Validar existencia de registros en el archivo
            if (dt.Rows.Count == 0) {
                throw new Exception("El archivo no contiene información");
            }

            //Validar cantidad de columnas
            if (dt.Columns.Count != 3) { 
                throw new Exception("La cantidad de columnas no corresponde con la estructura requerida " +
                    "(3 columnas: Código Contabilidad, Código PUC, Descripción)");
            }

            //Validar Nombre y Orden de las columnas
            if (dt.Columns[0].ColumnName != "Código Contabilidad" || dt.Columns[1].ColumnName != "Código PUC" 
                || dt.Columns[2].ColumnName != "Descripción")
                throw new Exception("Los nombres de las columnas del archivo no corresponden con el orden y estructura requerida (Código Contabilidad, Código PUC, Descripción)");

            //Pasar DataTable a Listado de PucInputModel
            List<PUCInputModel> pucs = new List<PUCInputModel>();
            foreach (DataRow item in dt.Rows)
            {
                if (item["Código Contabilidad"].ToString() == "" || item["Código PUC"].ToString() == "" || item["Descripción"].ToString() == "")
                    throw new Exception("Hay campos sin diligenciar en el archivo cargado");

                PUCInputModel puc = new PUCInputModel
                {
                    Contabilidad = item["Código Contabilidad"].ToString(),
                    Codigo = item["Código PUC"].ToString(),
                    Descripcion = item["Descripción"].ToString(),
                    EntidadId = entidadId
                };
                pucs.Add(puc);
            }
            //Validar existencia contabilidad
            IEnumerable<string> contabilidadInput = pucs.Select(c => c.Contabilidad).Distinct();
            var contabilidades = await _repoContabilidad.ListAllAsync();
            contabilidades = contabilidades.Where(c => c.EntidadId == entidadId).ToList();
            foreach (string item in contabilidadInput)
            {
                if (!contabilidades.Select(c => c.Codigo).Contains(item))
                    throw new Exception("La contabilidad " + item + " no existe");
            }
            return pucs;
        }
    }
}

