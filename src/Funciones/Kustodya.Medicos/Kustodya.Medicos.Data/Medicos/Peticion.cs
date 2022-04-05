using System;

namespace Kustodya.Medicos.Data
{
    public class Peticion : BaseEntity
    {
        public Peticion(Guid Id) : base(nameof(Peticion))
        {
            FechaCreacion = DateTime.Now;
        }

        public DateTime FechaCreacion { get; set; }
        public Guid MedicoId { get; set; }
    }
}