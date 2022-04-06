using Kustodya.ApplicationCore.DTOs.Contabilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Services.Contabilidades
{
    public interface ICentroInputModelService
    {
        Task<IReadOnlyList<CentroInputModel>> GetInputModel(DataTable dt, int entidadId);
    }
}
