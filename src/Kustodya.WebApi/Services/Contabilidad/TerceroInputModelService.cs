using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.DTOs.Contabilidades;
using Kustodya.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Services.Contabilidades
{
    public class TerceroInputModelService : ITerceroInputModelService
    {
        public IReadOnlyList<TerceroInputModel> GetInputModel(DataTable dt, int entidadId) {
            //Validar existencia de registros en el archivo
            if (dt.Rows.Count == 0)
            {
                throw new Exception("El archivo no contiene información");
            }

            if (dt.Select("[Tipo persona] <>''", "[Tipo persona] desc").Length == 0)
                throw new Exception("Debe diligenciar el campo tipo persona");

            //Eliminar filas vacías
            dt = dt.Select("[Tipo persona] <>''", "[Tipo persona] desc").CopyToDataTable();

            //Validar existencia de registros en el archivo
            if (dt.Rows.Count == 0)
            {
                throw new Exception("El archivo no contiene información");
            }

            //Validar información de personas jurídicas y naturales
            if (dt.Select("([Razón Social] = '' or [Dígito verificación] = '')  and [Tipo persona] = 'PJ'", "[Tipo persona] desc").Length > 0)
                throw new Exception("Hay dígitos de verificación y/o razones sociales vacías para personas jurídicas");

            if (dt.Select("([Primer nombre] = '' or [Primer apellido] = '') and [Tipo persona] = 'PN'", "[Tipo persona] desc").Length > 0)
                throw new Exception("Hay primeros nombres y/o primeros apellidos vacíos para personas naturales");

            //Validar cantidad de columnas
            if (dt.Columns.Count != 17)
            {
                throw new Exception("La cantidad de columnas no corresponde con la estructura requerida " +
                    "(17 columnas: Tipo persona, Tipo Id, Número Id, Razón social, Primer nombre, Segundo nombre, " +
                    "Primer apellido, Segundo apellido, Dígito verificación, Número Comprobante, Fecha Comprobante, Código Contable, Valor Débito," +
                    "Valor Crédito, Código Contabilidad, Centro Costo, Fecha Corte)");
            }

            //Validar Nombre y Orden de las columnas
            if (dt.Columns[0].ColumnName != "Tipo persona" || dt.Columns[1].ColumnName != "Tipo Id" || dt.Columns[2].ColumnName != "Número Id"
                || dt.Columns[3].ColumnName != "Razón social" || dt.Columns[4].ColumnName != "Primer nombre"
                || dt.Columns[5].ColumnName != "Segundo nombre" || dt.Columns[6].ColumnName != "Primer apellido"
                || dt.Columns[7].ColumnName != "Segundo apellido" || dt.Columns[8].ColumnName != "Dígito verificación" || dt.Columns[9].ColumnName != "Número Comprobante"
                || dt.Columns[10].ColumnName != "Fecha Comprobante (dd/mm/yyyy)" || dt.Columns[11].ColumnName != "Código Contable" || dt.Columns[12].ColumnName != "Valor Débito"
                || dt.Columns[13].ColumnName != "Valor Crédito" || dt.Columns[14].ColumnName != "Código Contabilidad" || dt.Columns[15].ColumnName != "Centro Costo"
                || dt.Columns[16].ColumnName != "Fecha Corte (dd/mm/yyyy)")
                throw new Exception("Los nombres de las columnas del archivo no corresponden con el orden y estructura requerida " +
                    "(Tipo persona, Tipo Id, Número Id, Razón social, Primer nombre, Segundo nombre, " +
                    "Primer apellido, Segundo apellido, Dígito verificación, Número Comprobante, Fecha Comprobante, Código Contable, Valor Débito," +
                    "Valor Crédito, Código Contabilidad, Centro Costo, Fecha Corte");

            //Validar tipo persona
            if (dt.Select("[Tipo persona] <>'PN' and [Tipo persona] <>'PJ'", "[Tipo persona] desc").Length > 1)
                throw new Exception("Hay registros con tipos de persona no válidos. Válidos(PN, PJ)");

            //Pasar DataTable a Listado de PucInputModel
            List<TerceroInputModel> terceros = new List<TerceroInputModel>();
            foreach (DataRow item in dt.Rows)
            {
                TerceroInputModel tercero = new TerceroInputModel
                {
                    TipoPersona = item["Tipo persona"].ToString(),
                    TipoId = item["Tipo Id"].ToString(),
                    NumeroId = item["Número Id"].ToString(),
                    RazonSocial = item["Razón social"].ToString(),
                    PrimerNombre = item["Primer nombre"].ToString(),
                    SegundoNombre = item["Segundo nombre"].ToString(),
                    PrimerApellido = item["Primer apellido"].ToString(),
                    SegundoApellido = item["Segundo apellido"].ToString(),
                    NumeroComprobante = Convert.ToInt64(item["Número Comprobante"].ToString()),
                    CodigoContabilidad = item["Código Contabilidad"].ToString(),
                    CentroCosto = item["Centro Costo"].ToString()
                };
                try { tercero.DigVerificacion = Convert.ToInt32(item["Dígito verificación"].ToString()); } catch (Exception) { }
                try { 
                    tercero.FechaComprobante = new DateTime(Convert.ToInt32(item["Fecha Comprobante (dd/mm/yyyy)"].ToString().Substring(0,10).Split('/')[2]),
                        Convert.ToInt32(item["Fecha Comprobante (dd/mm/yyyy)"].ToString().Split('/')[1]),
                        Convert.ToInt32(item["Fecha Comprobante (dd/mm/yyyy)"].ToString().Split('/')[0])); 
                } catch (Exception) { }
                try { tercero.CodigoContable = Convert.ToInt32(item["Código Contable"].ToString()); } catch (Exception) { }
                try { tercero.ValorCredito = Convert.ToInt32(item["Valor Crédito"].ToString()); } catch (Exception) { }
                try { tercero.ValorDebito = Convert.ToInt32(item["Valor Débito"].ToString()); } catch (Exception) { }
                try { tercero.FechaCorte = new DateTime(Convert.ToInt32(item["Fecha Corte (dd/mm/yyyy)"].ToString().Substring(0, 10).Split('/')[2]),
                        Convert.ToInt32(item["Fecha Corte (dd/mm/yyyy)"].ToString().Split('/')[1]),
                        Convert.ToInt32(item["Fecha Corte (dd/mm/yyyy)"].ToString().Split('/')[0]));
                } catch (Exception) { }
                terceros.Add(tercero);
            }
            if (terceros.Where(c => c.DigVerificacion == null && c.TipoPersona == "PJ").Count() > 0)
                throw new Exception("Hay personas jurídicas sin dígito de verificación");

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Tipo persona"].ToString() == "PJ" && dr["Dígito verificación"].ToString() != CalcularDigitoVerificacion(dr["Número Id"].ToString()).ToString())
                    throw new Exception("El dígito de verificación " + dr["Dígito verificación"].ToString() + " no es valido para el número Id: " + dr["Número Id"].ToString());
            }

            

            //Validar existencia Tipo Identificación
            IEnumerable<string> TiposId = terceros.Select(c => c.TipoId).Distinct();
            var TiposIdRepo = ((TipoIdentificacion[])Enum.GetValues(typeof(TipoIdentificacion)))
             .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList();
            foreach (string item in TiposId)
            {
                if (!TiposIdRepo.Select(c=>c.Name).Contains(item))
                    throw new Exception("El tipo de identificación " + item + " no existe");
            }
            return terceros;
        }

        private int CalcularDigitoVerificacion(string NumeroId)
        {
            int n;
            bool isNumeric = int.TryParse(NumeroId, out n);
            if (!isNumeric)
                return 0;
            string unNit = NumeroId;
            string miTemp;
            int miContador;
            int miResiduo;
            int miChequeo;
            int[] miArregloPA = new int[15];
            miArregloPA[0] = 3;
            miArregloPA[1] = 7;
            miArregloPA[2] = 13;
            miArregloPA[3] = 17;
            miArregloPA[4] = 19;
            miArregloPA[5] = 23;
            miArregloPA[6] = 29;
            miArregloPA[7] = 37;
            miArregloPA[8] = 41;
            miArregloPA[9] = 43;
            miArregloPA[10] = 47;
            miArregloPA[11] = 53;
            miArregloPA[12] = 59;
            miArregloPA[13] = 67;
            miArregloPA[14] = 71;
            miChequeo = 0;
            miResiduo = 0;
            for (miContador = 0; miContador < unNit.Length; miContador++)
            {
                miTemp = unNit[(unNit.Length - 1) - miContador].ToString();
                miChequeo = miChequeo + (Convert.ToInt32(miTemp) * miArregloPA[miContador]);
            }
            miResiduo = miChequeo % 11;
            if (miResiduo > 1)
                return 11 - miResiduo;
            return miResiduo;
        }
    }
}
