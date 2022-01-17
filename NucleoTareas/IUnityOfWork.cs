using EntidadesTareas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NucleoTareas
{
    public interface IUnitOfWork
    {
        IRepository<Correos> CorreosRepository { get; }
        IRepository<CorreoAdjuntos> CorreoAdjuntosRepository { get; }
        string SaveChanges();
    }
}
