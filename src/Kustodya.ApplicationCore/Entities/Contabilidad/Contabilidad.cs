using Kustodya.ApplicationCore.Entities.Administracion;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kustodya.ApplicationCore.Entities.Contabilidades
{
    public class Contabilidad : BaseEntity
    {
        private Contabilidad()
        {

        }

        public Contabilidad(
            int entidadId,
            string codigo,
            string descripcion,
            Guid? codigoPucCreditoMovimientoPorDefecto = null,
            Guid? codigoPucDebitoMovimientoPorDefecto = null,
            string? referenciaMovimientoPorDefecto = null,
            string? descripcionMovimientoPorDefecto = null,
            Guid? claseDocumentoporDefecto = null,
            Guid? tipoAjusteporDefecto = null
            )
        {
            EntidadId = entidadId;
            Codigo = codigo;
            Descripcion = descripcion;
            CodigoPucCreditoMovimientoPorDefecto = codigoPucCreditoMovimientoPorDefecto;
            CodigoPucDebitoMovimientoPorDefecto = codigoPucDebitoMovimientoPorDefecto;
            ReferenciaMovimientoPorDefecto = referenciaMovimientoPorDefecto ?? string.Empty;
            DescripcionMovimientoPorDefecto = DescripcionMovimientoPorDefecto ?? string.Empty;
            ClaseDocumentoPorDefectoId = claseDocumentoporDefecto;
            TipoAjustePorDefectoId = tipoAjusteporDefecto;
        }

        #region Propiedades
        public string Descripcion { get; set; }
        public string Codigo { get; private set; }
        public int EntidadId { get; private set; }
        public Guid? CodigoPucDebitoMovimientoPorDefecto { get; set; }
        public Guid? CodigoPucCreditoMovimientoPorDefecto { get; set; }
        public string ReferenciaMovimientoPorDefecto { get; set; }
        public string DescripcionMovimientoPorDefecto { get; set; }

        public Puc? PucCreditoPorDefecto { get; private set; }
        public Puc? PucDebitoPorDefecto { get; private set; }
        public List<Puc> Pucs { get; private set; }
        public List<CentroCosto> Centros { get; private set; }
        public ICollection<DepuracionContable> DepuracionesContables { get; private set; }
        public Guid? ClaseDocumentoPorDefectoId { get; set; }
        public ClaseDocumento? ClaseDocumentoPorDefecto { get; private set; }
        public Guid? TipoAjustePorDefectoId { get; set; }
        public TipoAjuste? TipoAjustePorDefecto { get; private set; }

        public Entidad Entidad { get; private set; }


        #endregion

        #region Comportamiento
        public Contabilidad ActualizarValoresPorDefecto(Guid codigoPucCreditoMovimientoPorDefecto, Guid codigoPucDebitoMovimientoPorDefecto)
        {
            CodigoPucCreditoMovimientoPorDefecto = codigoPucCreditoMovimientoPorDefecto;
            CodigoPucDebitoMovimientoPorDefecto = codigoPucDebitoMovimientoPorDefecto;

            return this;
        }

        public void ActualizarPucs(IList<Puc> pucsAgregar)
        {
            Pucs.RemoveAll(c => c.TipoContabilidad == Puc.TiposContabilidad.Otro);
            Pucs.AddRange(pucsAgregar);
        }
        public void EliminarPucs()
        {
            Pucs.RemoveAll(c => c.TipoContabilidad == Puc.TiposContabilidad.Otro);
        }
        public void ActualizarCentros(IList<CentroCosto> centrossAgregar)
        {
            //Centros.RemoveAll(c => c.ContabilidadId == centrossAgregar[0].ContabilidadId);
            Centros.AddRange(centrossAgregar);
        }

        internal void EstablecerClaseDocumentoPorDefecto(Guid? claseDocumentoId)
        {
            this.ClaseDocumentoPorDefectoId = claseDocumentoId;
        }
        internal void EstablecerTipoAjustePorDefecto(Guid? tipoAjusteId)
        {
            this.TipoAjustePorDefectoId = tipoAjusteId;
        }
        #endregion
    }
}
