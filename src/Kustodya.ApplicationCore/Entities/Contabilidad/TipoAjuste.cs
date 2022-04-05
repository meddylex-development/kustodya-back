using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities.Contabilidades
{
    public class TipoAjuste : BaseEntity, IBaseEntity
    {
        private TipoAjuste()
        {

        }
        public TipoAjuste(string descripcion, Guid contabilidadId)
        {
            Descripcion = descripcion;
            ContabilidadId = contabilidadId;
        }

        public string Descripcion { get; private set; }
        public Guid ContabilidadId { get; set; }
        public Contabilidad Contabilidad { get; set; }
        public void ActualizarDescripcion(string descripcion)
        {
            Descripcion = descripcion;
            Restaurar();
        }
    }
}