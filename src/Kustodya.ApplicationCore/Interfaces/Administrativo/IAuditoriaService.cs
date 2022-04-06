using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces.Administrativo
{
    public interface IAuditoriaService
    {
        Task<Entities.Administracion.Auditoria> CrearAsync(Entities.Administracion.Auditoria auditoria);
    }
}
