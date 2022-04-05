using Kustodya.ApplicationCore.DTOs.Contabilidades;
using Kustodya.WebApi.Models.Contabilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Services.Contabilidades
{
    public interface IPUCInputModelService
    {
        Task<IReadOnlyList<PUCInputModel>> GetInputModel(DataTable dt, int entidadId);
    }
}
