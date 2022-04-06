using Kustodya.ApplicationCore.Constants;
using Kustodya.WebApi.Models;
using Kustodya.WebApi.Models.Rehabilitaciones;
using Kustodya.WebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Services
{
    public class PronosticoViewModelService : IPronosticoViewModelService
    {
        private readonly IEnumExtensions _enumExtensions;

        public PronosticoViewModelService(IEnumExtensions enumExtensions)
        {
            _enumExtensions = enumExtensions;
        }

        public List<EnumValueModel> CreateViewModel()
        {
            List<EnumValueModel> result = _enumExtensions.GetValues<Pronosticos>();

            return result;
        }
    }
}
