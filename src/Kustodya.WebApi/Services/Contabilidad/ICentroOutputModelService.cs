using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.WebApi.Models.Contabilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Services.Contabilidades
{
    public interface ICentroOutputModelService
    {
        Task<CentrosOutputModel> GetListaCentrosOutputModel(string busqueda, int pagina, int tamanoPagina);
        Task<IEnumerable<CentroCosto>> GetListaCentros(string busqueda);
    }
}
