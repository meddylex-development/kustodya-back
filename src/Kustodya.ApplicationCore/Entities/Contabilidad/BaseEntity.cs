using System;

namespace Kustodya.ApplicationCore.Entities.Contabilidades
{
    public interface IBaseEntity
    {
        Guid Id { get; }
        bool Eliminado { get; }
        int EntidadId { get; set; }

        void Eliminar();
        void Restaurar();
    }

    public class BaseEntity : IBaseEntity
    {
        public Guid Id { get; private set; }
        public bool Eliminado { get; protected set; } = false;
        public int EntidadId { get; set; }

        public virtual void Eliminar()
        {
            Eliminado = true;
        }

        public void Restaurar()
        {
            Eliminado = false;
        }
    }
}

