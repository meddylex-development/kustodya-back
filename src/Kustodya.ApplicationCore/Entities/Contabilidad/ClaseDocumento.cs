using System;
using System.Linq;

namespace Kustodya.ApplicationCore.Entities.Contabilidades
{
    public class ClaseDocumento : BaseEntity
    {
        private ClaseDocumento()
        {
            
        }
        public ClaseDocumento(Guid contabilidadId, string? descripcion = null)
        {
            Descripcion = descripcion;
            ContabilidadId = contabilidadId;
        }

        public string Descripcion { get; private set; }
        public Contabilidad Contabilidad { get; set; }
        public Guid ContabilidadId { get; set; }

        public override void Eliminar()
        {
            if(EsUsadaPorAlgunaDepuracionContable())
                throw new EntidadUsadaNoSePuedeEliminarException(this.GetType(), this.Contabilidad.DepuracionesContables.GetType().GenericTypeArguments[0]);
            base.Eliminar();
        }
        
        public void ActualizarDescripcion(string descripcion)
        {
            Descripcion = descripcion;
            Restaurar();
        }

        private bool EsUsadaPorAlgunaDepuracionContable() => 
            Contabilidad.DepuracionesContables.Select(d => d.ClaseDocumentoId).Contains(this.Id);        
    }
}