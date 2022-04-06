using Kustodya.ApplicationCore.DTOs.Contabilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Services.Contabilidades
{
    public interface ITerceroInputModelService
    {
        IReadOnlyList<TerceroInputModel> GetInputModel(DataTable dt, int entidadId);
    }
}
