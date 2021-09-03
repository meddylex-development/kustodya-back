using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.WebApi.Models.Contabilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Services.Contabilidades
{
    public interface ITerceroOutputModelService
    {
        Task<TercerosOutputModel> GetListaTercerosOutputModel(string busqueda, TiposPersona? tipoPersona, int pagina, int tamanoPagina);
        Task<IEnumerable<Tercero>> GetListaTerceros(string busqueda, TiposPersona? tipoContabilidad);
    }
}
