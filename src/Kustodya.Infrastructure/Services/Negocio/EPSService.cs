using AutoMapper;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Interfaces.General;
using Kustodya.ApplicationCore.Interfaces.Negocio;
using Kustodya.ApplicationCore.Specifications.Negocio;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Dtos.Negocio;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Specifications;

namespace Kustodya.Infrastructure.Services.Negocio
{
    public class EPSService : IEPSService
    {
        private readonly IDANEService _daneService;
        private readonly IAsyncRepository<TblEps> _epsRepository;
        private readonly IAsyncRepository<UsuarioEPS> _UsuarioEpsRepository;
        private readonly IAsyncRepository<TblUsuarios> _UsuarioRepository;
        private readonly ILoggerService<EPSService> _logger;
        private readonly IMapper _mapper;

        public EPSService(IAsyncRepository<TblEps> epsRepository, IDANEService daneService, ILoggerService<EPSService> logger,
            IMapper mapper, IAsyncRepository<UsuarioEPS> usuarioepsrepository, IAsyncRepository<TblUsuarios> usuario)
        {
            _epsRepository = epsRepository;
            _daneService = daneService;
            _logger = logger;
            _mapper = mapper;
            _UsuarioEpsRepository = usuarioepsrepository;
            _UsuarioRepository = usuario;
        }

        public async Task<IReadOnlyList<EpsModel>> GetAllEPS()
        {
            IReadOnlyList<TblEps> lEps = await _epsRepository.ListAllAsync().ConfigureAwait(false);
            List<EpsModel> result = _mapper.Map<List<EpsModel>>(lEps);
            return result;
        }

        public async Task<EpsModel> GetEPSById(long idEps)
        {
            var spec = new EPSSpec(idEps);
            TblEps eps = await _epsRepository.GetOneAsync(spec).ConfigureAwait(false);
            EpsModel result = _mapper.Map<EpsModel>(eps);
            return result;
        }
        public async Task<IReadOnlyList<UsuarioEPS>> GetAllEPSByUser(int IdUser)
        {
            var epsSpec = new UsuarioEPSSpec(IdUser);
            return await _UsuarioEpsRepository.ListAsync(epsSpec);
            /*List<UsuarioEPS> result = _mapper.Map<List<UsuarioEPS>>(listUsuarioEPS);
            return result;*/
        }
        public async Task<string> CrearUsuarioEPS(UsuarioEPS usuarioEPS) {
            //Validar existencia usuario
            var usuSpec = new ActiveUserSpec(usuarioEPS.TblUsuariosId);
            var usuario = await _UsuarioRepository.GetOneAsync(usuSpec);
            if (usuario == null)
                return "Usuario no existe o se encuentra inactivo";

            //Validar existencia EPS
            var epsSpec = new EPSSpec(usuarioEPS.TblEpsId);
            var eps = await _epsRepository.GetOneAsync(epsSpec);
            if (eps == null)
                return "EPS no existe";

            //Crear usuario EPS
            var usuEpsSpec = new UsuarioEPSSpec(usuarioEPS.TblUsuariosId, usuarioEPS.TblEpsId);
            var listUsuarioEPS = await _UsuarioEpsRepository.ListAsync(usuEpsSpec);
            if (listUsuarioEPS.Count == 0) {
                usuarioEPS.Activo = true;
                await _UsuarioEpsRepository.AddAsync(usuarioEPS);
                return null;
            }

            //Actualizar usuario EPS
            var epsUsrSpec = new UsuarioEPSSpec(usuarioEPS.TblUsuariosId, usuarioEPS.TblEpsId);
            var usueps = await _UsuarioEpsRepository.GetOneAsync(epsUsrSpec);
            if (usueps.Activo)
                return null;
            usueps.Activo = true;
            await _UsuarioEpsRepository.UpdateAsync(usueps);
            return null;
        }
        
        public async Task<string> EliminarUsuarioEPS(UsuarioEPS usuarioEPS)
        {
            //Validar existencia usuario
            var usuSpec = new ActiveUserSpec(usuarioEPS.TblUsuariosId);
            var usuario = await _UsuarioRepository.GetOneAsync(usuSpec);
            if (usuario == null)
                return "Usuario no existe o se encuentra inactivo";

            //Validar existencia EPS
            var epsSpec = new EPSSpec(usuarioEPS.TblEpsId);
            var eps = await _epsRepository.GetOneAsync(epsSpec);
            if (eps == null)
                return "EPS no existe";

            //Eliminar usuario EPS
            var usuEpsSpec = new UsuarioEPSSpec(usuarioEPS.TblUsuariosId, usuarioEPS.TblEpsId);
            var usueps = await _UsuarioEpsRepository.GetOneAsync(usuEpsSpec);
            if (usueps == null) {
                return "No se encontró el usuario EPS indicado";
            }
            usueps.Activo = false;
            await _UsuarioEpsRepository.UpdateAsync(usueps);
            return null;
        }
    }
}