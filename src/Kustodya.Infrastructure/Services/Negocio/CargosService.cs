using AutoMapper;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Specifications.Negocio;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Dtos.Negocio.RH;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Interfaces.Negocio;
using Kustodya.ApplicationCore.Interfaces.General;

namespace Kustodya.BusinessLogic.Services.Negocio
{
    public class CargosService : ICargosService
    {
        private readonly IAsyncRepository<TblCargos> _cargosRepository;
        private readonly IEmpleadosService _empleadosService;
        private readonly IMapper _mapper;

        public CargosService(
            IAsyncRepository<TblCargos> cargosRepository,
            IEmpleadosService empleadosService,
            IMapper mapper)
        {
            _empleadosService = empleadosService;
            _cargosRepository = cargosRepository;
            _mapper = mapper;
        }

        public async Task<EmpleadosModel> AddMedico(EmpleadosModel medico)
        {
            var cargoMedico = await GetCargoByName("Médico").ConfigureAwait(false);
            TblEmpleados empleado = _mapper.Map<TblEmpleados>(medico);
            empleado.IIdcargo = cargoMedico.IIdcargo;
            var nuevoMedico = await _empleadosService.AddEmpleado(empleado).ConfigureAwait(false);
            return nuevoMedico;
        }

        public async Task<EmpleadosModel> GetMedicoByCedula(long cedula)
        {
            //TODO Change String literal
            CargosSpec cargosSpec = new CargosSpec("Médico");
            var cargoMedico = await _cargosRepository.GetOneAsync(cargosSpec).ConfigureAwait(false);
            return await _empleadosService.GetEmpleadoByIdCargoAndCedula(cargoMedico.IIdcargo, cedula).ConfigureAwait(false);
        }

        public async Task<ICollection<EmpleadosModel>> GetMedicosByName(string name)
        {
            CargosSpec cargosSpec = new CargosSpec("Médico");
            var cargoMedico = await _cargosRepository.GetOneAsync(cargosSpec).ConfigureAwait(false);
            return await _empleadosService.GetEmpleadosByIdCargoAndName(cargoMedico.IIdcargo, name).ConfigureAwait(false);
        }

        private async Task<TblCargos> GetCargoByName(string name)
        {
            CargosSpec cargosSpec = new CargosSpec(name);
            var cargo = await _cargosRepository.GetOneAsync(cargosSpec).ConfigureAwait(false);
            return cargo;
        }
    }
}