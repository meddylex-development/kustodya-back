using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Interfaces.Administrativo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.Infrastructure.Services.Auditoria
{
    public class AuditoriaService : IAuditoriaService
    {
        #region Dependency Injection
        private readonly IAsyncRepository<ApplicationCore.Entities.Administracion.Auditoria> _repoAuditoria;
        #endregion

        public AuditoriaService(
            IAsyncRepository<ApplicationCore.Entities.Administracion.Auditoria> repoAuditoria)
        {
            _repoAuditoria = repoAuditoria;
        }

        public async Task<ApplicationCore.Entities.Administracion.Auditoria> CrearAsync(ApplicationCore.Entities.Administracion.Auditoria auditoria) {
            return await _repoAuditoria.AddAsync(auditoria);
        }
    }
}
