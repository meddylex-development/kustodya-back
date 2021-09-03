using Kustodya.Medicos.Models;
using Kustodya.Medicos.Services.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Kustodya.Medicos.Services
{
    public interface IMedicosOutputModelService
    {
        Task<MedicoOutputModel> GetMedicoOutputModel(Registro medicosInputModel, string peticion);
        Task<MedicoOutputModel[]> GetMedicosOutputModel(List<Registro> medicosInputModel, Guid peticionId);
    }
}