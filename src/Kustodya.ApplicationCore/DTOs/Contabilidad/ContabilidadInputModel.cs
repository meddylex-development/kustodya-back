using System;

namespace Kustodya.ApplicationCore.DTOs.Contabilidades
{
    public class ContabilidadInputModel
    {
        protected int EntidadId { get; set; }
        
        /// <summary>
        /// Texto que describe la contabilidad
        /// </summary>
        /// <example>Caja menor de Roojo Colombia</example>
        public string Descripcion { get; set; }
        
        /// <summary>
        /// Codigo propio de la contabilidad para cada entidad
        /// </summary>
        /// <example>1289564</example>
        public string Codigo { get; set; }
        
        /// <summary>
        /// Si es verdadero, el valor de contabilidad por defecto de la entidad se actualizara a esta contabilidad
        /// </summary>
        /// <example>false</example>
        public bool EsContabilidadPorDefecto { get; set; }

        /// <summary>
        /// Codigo PUC debito por defecto para los movimientos de esta contabilidad
        /// </summary>
        /// <example>410505</example>
        public string CodigoPucDebitoMovimientoPorDefecto { get; set; }
        
        /// <summary>
        /// Codigo PUC credito por defecto para los movimientos de esta contabilidad
        /// </summary>
        /// <example>410505</example>
        public string CodigoPucCreditoMovimientoPorDefecto { get; set; }
        
        /// <summary>
        /// Texto de referencia por defecto para los movimientos de esta contabilidad
        /// </summary>
        /// <example>A7896</example>
        public string ReferenciaMovimientoPorDefecto { get; set; }
                
        /// <summary>
        /// Texto de descripion por defecto para los movimientos de esta contabilidad
        /// </summary>
        /// <example>Deudas por pagar</example>
        public string DescripcionMovimientoPorDefecto { get; set; }
        public string ClaseDocumentoPorDefecto { get; set; }
        public string TipoAjustePorDefecto { get; set; }
    }
}