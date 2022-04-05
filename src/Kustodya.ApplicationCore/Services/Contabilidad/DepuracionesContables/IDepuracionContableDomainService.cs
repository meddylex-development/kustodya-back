using Kustodya.ApplicationCore.DTOs.DepuracionesContables;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Services.DepuracionesContables
{
    public interface IDepuracionContableDomainService : IDomainService<DepuracionContable, DepuracionContableInputModel>
    {
    }
}