using Kustodya.ApplicationCore.Entities.Rethus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Services.Rethus
{
    public interface IRethusModelService
    {
        Task<IEnumerable<tblRethusIdentificationTypes>> GetIdentificaciones();
        Task<IEnumerable<tblRethusData_Main>> GetMedicos(string documento, string tipo, string PrimerNombre, string PrimerApellido);
        Task<IEnumerable<tblRethusData_Academic>> GetAcademicos(int iIDRethusQuery);
        Task<IEnumerable<tblRethusData_Sanctions>> GetSanciones(int iIDRethusQuery);
        Task<IEnumerable<tblRethusData_SSO>> GetSso(int iIDRethusQuery);
        Task AddTask(string typeId, string numberId);
    }
}
