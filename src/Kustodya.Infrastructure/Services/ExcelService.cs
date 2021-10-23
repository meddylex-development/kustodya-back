using ClosedXML.Excel;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.Infrastructure.Services
{
    public class ExcelService : IExcelService
    {
        private IAsyncContabilidadRepository<Contabilidad> _repoContabilidad;
        private IAsyncContabilidadRepository<Regional> _repoRegional;
        private IAsyncContabilidadRepository<Segmento> _repoSegmento;
        public ExcelService(IAsyncContabilidadRepository<Contabilidad> repoContabilidad,
            IAsyncContabilidadRepository<Regional> repoRegional, IAsyncContabilidadRepository<Segmento> repoSegmento) {
            _repoContabilidad = repoContabilidad;
            _repoRegional = repoRegional;
            _repoSegmento = repoSegmento;
        }
        public async Task<byte[]> PUCtoExcel(IEnumerable<Puc> pucs, int entidadId){
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    IXLWorksheet worksheet =
                    workbook.Worksheets.Add("puc");
                    worksheet.Cell(1, 1).Value = "Código";
                    worksheet.Cell(1, 2).Value = "Descripción";
                    worksheet.Cell(1, 3).Value = "Contabilidad";
                    worksheet.Cell(1, 4).Value = "Tipo";
                    int index = 1;
                    foreach (Puc item in pucs)
                    {
                        worksheet.Cell(index + 1, 1).Value = item.Codigo;
                        worksheet.Cell(index + 1, 2).Value = item.Descripcion;
                        worksheet.Cell(index + 1, 3).Value = item.Contabilidad.Descripcion;
                        worksheet.Cell(index + 1, 4).Value = item.TipoContabilidad.ToString();
                        index++;
                    }

                    index = 1;
                    var contabilidades = await _repoContabilidad.ListAllAsync();
                    contabilidades = contabilidades.Where(c => c.EntidadId == entidadId).ToList();
                    worksheet = workbook.Worksheets.Add("Instructivo");
                    worksheet.Cell(1, 1).Value = "Códigos de Contabilidad";
                    foreach (Contabilidad item in contabilidades)
                    {
                        worksheet.Cell(index, 1).Value = item.Codigo;
                        index++;
                    }
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        return stream.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                return null;//return Error();
            }

        }
        public DataTable ExceltoDataTable(MemoryStream archivo)
        {
            using (XLWorkbook workBook = new XLWorkbook(archivo))
            {
                //Read the first Sheet from Excel file.
                IXLWorksheet workSheet = workBook.Worksheet(1);

                //Create a new DataTable.
                DataTable dt = new DataTable();

                //Loop through the Worksheet rows.
                bool firstRow = true;
                foreach (IXLRow row in workSheet.Rows())
                {
                    //Use the first row to add columns to DataTable.
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Columns.Add(cell.Value.ToString());
                        }
                        firstRow = false;
                    }
                    else
                    {
                        //Add rows to DataTable.
                        dt.Rows.Add();
                        int i = 0;
                        try
                        {
                            foreach (IXLCell cell in row.Cells(row.FirstCellUsed().Address.ColumnNumber, row.LastCellUsed().Address.ColumnNumber))
                            {
                                dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                                i++;
                            }
                        }
                        catch (Exception ex){
                            continue;
                        }
                    }
                }
                return dt;
            }
        }

        public async Task<byte[]> PlantillaPUC(int entidadId) {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    IXLWorksheet worksheet =
                    workbook.Worksheets.Add("puc");
                    worksheet.Cell(1, 1).Value = "Código Contabilidad";
                    worksheet.Cell(1, 2).Value = "Código PUC";
                    worksheet.Cell(1, 3).Value = "Descripción";

                    int index = 2;
                    var contabilidades = await _repoContabilidad.ListAllAsync();
                    contabilidades = contabilidades.Where(c => c.EntidadId == entidadId).ToList();
                    worksheet = workbook.Worksheets.Add("Instructivo");
                    worksheet.Cell(1, 1).Value = "Códigos de Contabilidad";
                    foreach (Contabilidad item in contabilidades)
                    {
                        worksheet.Cell(index, 1).Value = item.Codigo;
                        index++;
                    }

                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        return stream.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                return null;//return Error();
            }
        }

        public byte[] TercerotoExcel(IEnumerable<Tercero> terceros) {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    IXLWorksheet worksheet =
                    workbook.Worksheets.Add("Terceros");
                    worksheet.Cell(1, 1).Value = "Tipo persona";
                    worksheet.Cell(1, 2).Value = "Tipo Id";
                    worksheet.Cell(1, 3).Value = "Número Id";
                    worksheet.Cell(1, 4).Value = "Razón social";
                    worksheet.Cell(1, 5).Value = "Primer nombre";
                    worksheet.Cell(1, 6).Value = "Segundo nombre";
                    worksheet.Cell(1, 7).Value = "Primer apellido";
                    worksheet.Cell(1, 8).Value = "Segundo apellido";
                    worksheet.Cell(1, 9).Value = "Dígito verificación";
                    int index = 1;
                    foreach (Tercero item in terceros)
                    {
                        worksheet.Cell(index + 1, 1).Value = item.TipoPersona;
                        worksheet.Cell(index + 1, 2).Value = item.TipoId;
                        worksheet.Cell(index + 1, 3).Value = item.NumeroId;
                        worksheet.Cell(index + 1, 4).Value = item.RazonSocial;
                        worksheet.Cell(index + 1, 5).Value = item.PrimerNombre;
                        worksheet.Cell(index + 1, 6).Value = item.SegundoNombre;
                        worksheet.Cell(index + 1, 7).Value = item.PrimerApellido;
                        worksheet.Cell(index + 1, 8).Value = item.SegundoApellido;
                        worksheet.Cell(index + 1, 9).Value = item.DigitoVerificacion;
                        index++;
                    }

                    worksheet = workbook.Worksheets.Add("Instructivo");
                    worksheet.Cell(1, 1).Value = "Tipos de personas";
                    worksheet.Cell(2, 1).Value = "PN";
                    worksheet.Cell(3, 1).Value = "PJ";

                    worksheet.Cell(1, 3).Value = "Tipos de identificación";
                    worksheet.Cell(2, 3).Value = "Cédula de ciudadanía";
                    worksheet.Cell(3, 3).Value = "Nit Empresarial";
                    worksheet.Cell(4, 3).Value = "Nit Extranjeria";
                    worksheet.Cell(5, 3).Value = "Cédula Extranjeria";
                    worksheet.Cell(6, 3).Value = "Pasaporte";
                    worksheet.Cell(7, 3).Value = "Permiso Especial";
                    worksheet.Cell(8, 3).Value = "Registro Civil";
                    worksheet.Cell(9, 3).Value = "Tarjeta Identidad";

                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        return stream.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                return null;//return Error();
            }
        }

        public byte[] PlantillaTerceros()
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    IXLWorksheet worksheet =
                    workbook.Worksheets.Add("Terceros");
                    worksheet.Cell(1, 1).Value = "Tipo persona";
                    worksheet.Cell(1, 2).Value = "Tipo Id";
                    worksheet.Cell(1, 3).Value = "Número Id";
                    worksheet.Cell(1, 4).Value = "Razón social";
                    worksheet.Cell(1, 5).Value = "Primer nombre";
                    worksheet.Cell(1, 6).Value = "Segundo nombre";
                    worksheet.Cell(1, 7).Value = "Primer apellido";
                    worksheet.Cell(1, 8).Value = "Segundo apellido";
                    worksheet.Cell(1, 9).Value = "Dígito verificación";
                    worksheet.Cell(1, 10).Value = "Número Comprobante";
                    worksheet.Cell(1, 11).Value = "Fecha Comprobante (dd/mm/yyyy)";
                    worksheet.Cell(1, 12).Value = "Código Contable";
                    worksheet.Cell(1, 13).Value = "Valor Débito";
                    worksheet.Cell(1, 14).Value = "Valor Crédito";
                    worksheet.Cell(1, 15).Value = "Código Contabilidad";
                    worksheet.Cell(1, 16).Value = "Centro Costo";
                    worksheet.Cell(1, 17).Value = "Fecha Corte (dd/mm/yyyy)";

                    worksheet = workbook.Worksheets.Add("Instructivo");
                    worksheet.Cell(1, 1).Value = "Tipos de personas";
                    worksheet.Cell(2, 1).Value = "PN";
                    worksheet.Cell(3, 1).Value = "PJ";

                    worksheet.Cell(1, 3).Value = "Tipos de identificación";
                    int index = 0;
                    worksheet.Cell(2, 3).Value = "Cédula de ciudadanía";
                    worksheet.Cell(3, 3).Value = "Nit Empresarial";
                    worksheet.Cell(4, 3).Value = "Nit Extranjeria";
                    worksheet.Cell(5, 3).Value = "Cédula Extranjeria";
                    worksheet.Cell(6, 3).Value = "Pasaporte";
                    worksheet.Cell(7, 3).Value = "Permiso Especial";
                    worksheet.Cell(8, 3).Value = "Registro Civil";
                    worksheet.Cell(9, 3).Value = "Tarjeta Identidad";


                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        return stream.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                return null;//return Error();
            }
        }

        public async Task<byte[]> PlantillaCentroCostos(int entidadId)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    IXLWorksheet worksheet =
                    workbook.Worksheets.Add("CentrosCosto");
                    worksheet.Cell(1, 1).Value = "Código Contabilidad";
                    worksheet.Cell(1, 2).Value = "Código";
                    worksheet.Cell(1, 3).Value = "Descripción";
                    worksheet.Cell(1, 4).Value = "Regional";
                    worksheet.Cell(1, 5).Value = "Segmento";
                    
                    int index = 2;
                    var contabilidades = await _repoContabilidad.ListAllAsync();
                    contabilidades = contabilidades.Where(c => c.EntidadId == entidadId).ToList();
                    worksheet = workbook.Worksheets.Add("Instructivo");
                    worksheet.Cell(1, 1).Value = "Códigos de Contabilidad";
                    foreach (Contabilidad item in contabilidades)
                    {
                        worksheet.Cell(index, 1).Value = item.Codigo;
                        index++;
                    }

                    index = 2;
                    var Regionales = await _repoRegional.ListAllAsync();
                    worksheet.Cell(1, 3).Value = "Regionales";
                    foreach (Regional item in Regionales)
                    {
                        worksheet.Cell(index, 3).Value = item.Descripcion;
                        index++;
                    }

                    index = 2;
                    var Segmentos = await _repoSegmento.ListAllAsync();
                    worksheet.Cell(1, 5).Value = "Segmentos";
                    foreach (Segmento item in Segmentos)
                    {
                        worksheet.Cell(index, 5).Value = item.Descripcion;
                        index++;
                    }

                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        return stream.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                return null;//return Error();
            }
        }
        public async Task<byte[]> CentrostoExcel(IEnumerable<CentroCosto> centros, int entidadId)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    IXLWorksheet worksheet =
                    workbook.Worksheets.Add("puc");
                    worksheet.Cell(1, 1).Value = "Código Contabilidad";
                    worksheet.Cell(1, 2).Value = "Código";
                    worksheet.Cell(1, 3).Value = "Descripción";
                    worksheet.Cell(1, 4).Value = "Regional";
                    worksheet.Cell(1, 5).Value = "Segmento";
                    
                    int index = 1;
                    foreach (CentroCosto item in centros)
                    {
                        worksheet.Cell(index + 1, 1).Value = item.Contabilidad.Codigo;
                        worksheet.Cell(index + 1, 2).Value = item.Codigo;
                        worksheet.Cell(index + 1, 3).Value = item.Descripcion;
                        worksheet.Cell(index + 1, 4).Value = item.Regional.Descripcion;
                        worksheet.Cell(index + 1, 5).Value = item.Segmento.Descripcion;
                        
                        index++;
                    }
                    
                    index = 2;
                    var contabilidades = await _repoContabilidad.ListAllAsync();
                    contabilidades = contabilidades.Where(c => c.EntidadId == entidadId).ToList();
                    worksheet = workbook.Worksheets.Add("Instructivo");
                    worksheet.Cell(1, 1).Value = "Códigos de Contabilidad";
                    foreach (Contabilidad item in contabilidades)
                    {
                        worksheet.Cell(index, 1).Value = item.Codigo;
                        index++;
                    }

                    index = 2;
                    var Regionales = await _repoRegional.ListAllAsync();
                    worksheet.Cell(1, 3).Value = "Regionales";
                    foreach (Regional item in Regionales)
                    {
                        worksheet.Cell(index, 3).Value = item.Descripcion;
                        index++;
                    }

                    index = 2;
                    var Segmentos = await _repoSegmento.ListAllAsync();
                    worksheet.Cell(1, 5).Value = "Segmentos";
                    foreach (Segmento item in Segmentos)
                    {
                        worksheet.Cell(index, 5).Value = item.Descripcion;
                        index++;
                    }
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        return stream.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                return null;//return Error();
            }

        }

        public DataTable csvtoDataTable(MemoryStream archivo) {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(archivo))
            {
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(';');
                    if (dt.Rows.Count == 0)
                    {
                        foreach (string header in rows)
                        {
                            dt.Columns.Add(header);
                        }
                    }
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < rows.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
    }
}
