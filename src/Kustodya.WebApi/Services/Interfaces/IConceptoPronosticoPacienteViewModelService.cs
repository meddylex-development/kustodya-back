using Kustodya.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Services.Interfaces
{
    public interface IConceptoPronosticoPacienteViewModelService
    {
        List<EnumValueModel> CreateViewModel();
    }
}
