using System;
using System.Collections.Generic;
using System.Text;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Entities;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Specifications;

namespace Kustodya.ApplicationCore.Services
{
    public class ValidateUser : IValidateUser
    {
        private readonly IAsyncRepository<TblUsuarios> _usuariosRepo;

        public ValidateUser(IAsyncRepository<TblUsuarios> usuariosRepo)
        {
            _usuariosRepo = usuariosRepo;
        }
        public async Task Validar(int id)
        {
            var spec = new CambioPasswordSpec(id);
            TblUsuarios u = await _usuariosRepo.GetOneAsync(spec);
            if (u == null)
                throw new Exception("Usuario no encontrado");
            return;
        }
    }
}
