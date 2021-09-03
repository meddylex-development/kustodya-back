using AutoMapper;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Interfaces.General;
using Kustodya.ApplicationCore.Specifications.Negocio;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Dtos.Negocio.RH;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kustodya.BusinessLogic.Services.Negocio
{
    public class EmpleadosService : IEmpleadosService
    {
        private readonly IAsyncRepository<TblEmpleados> _empleadosRepository;
        private readonly IMapper _mapper;

        public EmpleadosService(
            IMapper mapper,
            IAsyncRepository<TblEmpleados> empleadosRepository
            )
        {
            _mapper = mapper;
            _empleadosRepository = empleadosRepository;
        }

        public async Task<EmpleadosModel> AddEmpleado(TblEmpleados empleado)
        {
            var empleadodb = await _empleadosRepository.AddAsync(empleado).ConfigureAwait(false);
            var model = _mapper.Map<EmpleadosModel>(empleadodb);
            return model;
        }

        public async Task<EmpleadosModel> GetEmpleadoByIdCargoAndCedula(long idcargo, long cedula)
        {
            EmpleadosSpec empleadoSpec = new EmpleadosSpec(idcargo, cedula);
            var Empleado = await _empleadosRepository.GetOneAsync(empleadoSpec).ConfigureAwait(false);
            return _mapper.Map<EmpleadosModel>(Empleado);
        }

        public Task<ICollection<EmpleadosModel>> GetEmpleadosByIdCargoAndName(long idcargo, string name) => throw new NotImplementedException();
    }
}