using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Kustodya.ApplicationCore.Constants;

namespace Kustodya.ApplicationCore.DTOs.MallaValidadora.ModelosDeEntrada
{
    public class IncapacidadInputModel 
    //: IEquatable<ModeloDeEntradaDeIncapacidad>
    {
        public DateTime? FechaAfiliacion { get; set; }
        public DateTime? FechaRadicacion { get; set; }
        public bool? Prorroga { get; set; }
        // public int Dias { get; set; }
        public DateTime? FechaFin { get; set; }
        // public int? DiasAcumulados { get; set; }
        // public int? EspecialidadMedicaId { get; set; }
        public string IpsNit { get; set; }
        public AfiliadoInputModel Afiliado { get; set; }
        public DateTime? FechaInicio { get; set; }
        public string CodigoCie10 { get; set; }
        public IpsInputModel Ips { get; set; }

        // public bool Equals([AllowNull] ModeloDeEntradaDeIncapacidad otro)
        // {
        //     if(otro is null) return false;
        //     if(ReferenceEquals(this, otro)) return true;
        //     if(!(otro is ModeloDeEntradaDeIncapacidad otroModelo)) return false;

        //     return this.Afiliado.Equals(otroModelo.Afiliado) 
        //     && this.FechaRadicacion.Equals(otro.FechaRadicacion) 
        //     && this.IpsNit.Equals(otro.IpsNit);
        // }}
    }
}
