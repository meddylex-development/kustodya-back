using Kustodya.ApplicationCore.DTOs.Rethus;
using Kustodya.ApplicationCore.Entities.Rethus;
using System;
using System.Collections.Generic;
using System.Data;
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
        IReadOnlyList<CargueInputModel> GetInputModel(DataTable dt);
        Task CrearTareaRobot(IReadOnlyList<CargueInputModel> cargueInputModels, int entidadId);
        Task<List<CargueOutputModel>> GetCargues(int entidadId, int? skip = 0, int? take = 10);
        Task<byte[]> ExportarCargue(int taskId);
        Task<int> TotalCargues(int entidadId);
    }
}
