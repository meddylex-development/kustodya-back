using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces
{
    public interface IExcelService
    {
        Task<byte[]> PUCtoExcel(IEnumerable<Puc> pucs, int entidadId);
        DataTable ExceltoDataTable(MemoryStream archivo);
        Task<byte[]> PlantillaPUC(int entidadId);
        byte[] TercerotoExcel(IEnumerable<Tercero> terceros);
        byte[] PlantillaTerceros();
        Task<byte[]> CentrostoExcel(IEnumerable<CentroCosto> centros, int entidadId);
        Task<byte[]> PlantillaCentroCostos(int entidadId);
        public DataTable csvtoDataTable(MemoryStream archivo);
    }
}
