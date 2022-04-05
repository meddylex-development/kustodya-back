using Kustodya.ApplicationCore.DTOs.Contabilidades;
using System;

namespace Kustodya.ApplicationCore.Entities.Contabilidades
{
    public class Puc : BaseEntity
    {
        public Puc(
            string codigo,
            string descripcion,
            Guid contabilidadId,
            TiposContabilidad tipoContabilidad,
            int entidadId)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            ContabilidadId = contabilidadId;
            TipoContabilidad = tipoContabilidad;
            EntidadId = entidadId;
        }
        public string Codigo { get; private set; }
        public string Descripcion { get; private set; }
        public Contabilidad Contabilidad { get; private set; }
        public Guid ContabilidadId { get; private set; }
        public TiposContabilidad TipoContabilidad { get; private set; }

        public enum TiposContabilidad
        {
            Kustodya = 1,
            Otro = 2
        }
        public Puc(PUCInputModel inputModel, Contabilidad contabilidad)
            : this (inputModel.Codigo,
                    inputModel.Descripcion,
                    contabilidad.Id,
                    (TiposContabilidad)Enum.Parse(typeof(TiposContabilidad), "Otro"), inputModel.EntidadId)
        {
            
        }
    }
}
