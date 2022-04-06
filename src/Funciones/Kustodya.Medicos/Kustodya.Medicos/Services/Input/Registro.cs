using System;
using System.Diagnostics.CodeAnalysis;
using Kustodya.Medicos.Data.Medicos;

namespace Kustodya.Medicos.Services.Input
{
    public class Registro
    {
        public Registro()
        {

        }

        public Registro(string numeroIdentifiacion, TiposDeDocumentoDeIdentificacion tipoIdentificacion)
        {
            NumeroIdentificacion = numeroIdentifiacion;
            TipoIdentificacion = tipoIdentificacion;
        }

        public string NumeroIdentificacion { get; set; }
        public TiposDeDocumentoDeIdentificacion TipoIdentificacion { get; set; }
        /*
        public bool Equals(Registro other)
        {
            //Check whether the compared object is null.
            if (other is null) return false;

            //Check whether the compared object references the same data.
            if (ReferenceEquals(this, other)) return true;

            return NumeroIdentificacion.Equals(other.NumeroIdentificacion, StringComparison.OrdinalIgnoreCase) && TipoIdentificacion.Equals(other.TipoIdentificacion);
        }

        public override int GetHashCode()
        {

            //Get hash code for the Name field if it is not null.
            int hashTipoIdentificacion = TipoIdentificacion == null ? 0 : TipoIdentificacion.GetHashCode();

            //Get hash code for the Code field.
            int hashNumeroIdentificacion = NumeroIdentificacion == null ? 0 : NumeroIdentificacion.GetHashCode(StringComparison.OrdinalIgnoreCase);

            //Calculate the hash code for the product.
            return hashTipoIdentificacion ^ hashNumeroIdentificacion;
        }*/

        public override bool Equals(object otro)
        {
            if (otro is Registro otroRegistro)
            {
                //Check whether the compared object references the same data.
                if (ReferenceEquals(this, otroRegistro)) return true;

                var esIgual = 
                    NumeroIdentificacion.Equals(
                        otroRegistro.NumeroIdentificacion, StringComparison.OrdinalIgnoreCase) && 
                    TipoIdentificacion.Equals(
                        otroRegistro.TipoIdentificacion);

                return esIgual;
            }

            return false;
        }

        public override int GetHashCode()
        {
            //Get hash code for the Name field if it is not null.
            int hashTipoIdentificacion = TipoIdentificacion.GetHashCode();

            //Get hash code for the Code field.
            int hashNumeroIdentificacion = NumeroIdentificacion == null ? 0 : NumeroIdentificacion.GetHashCode(StringComparison.OrdinalIgnoreCase);

            //Calculate the hash code for the product.
            return hashTipoIdentificacion ^ hashNumeroIdentificacion;
        }
    }
}
