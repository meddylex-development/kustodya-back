using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.WebApi.Models.Contabilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Kustodya.ApplicationCore.Entities.Contabilidades.Puc;

namespace Kustodya.WebApi.Services.Contabilidades
{
    public interface IPUCOutputModelService
    {
        Task<PUCsOutputModel> GetListaPUCOutputModel(string busqueda, string contabilidad, TiposContabilidad? tipoContabilidad, int pagina, int tamanoPagina);
        Task<IEnumerable<Puc>> GetListaPUC(string busqueda, string contabilidad, TiposContabilidad? tipoContabilidad);
    }
}
