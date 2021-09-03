using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using Kustodya.Medicos.Data.Medicos;

namespace Kustodya.Medicos.Data
{
    public class Medico : BaseEntity
    {
        // public Medico()
        // {

        // }

        public Medico(Guid peticionId) : base(nameof(Medico))
        {
            PeticionId = peticionId;
            _partitionKey = PeticionId.ToString();
            FechaCreacion = DateTime.Now;
            var guid = Guid.NewGuid();
            base.id = $"{nameof(Medico)}|{guid}";
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public TiposDeDocumentoDeIdentificacion? TipoIdentificacion { get; set; }
        public bool? RegistradoEnRethus { get; set; }
        public string NumeroIdentifiacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime UltimaActualizacion { get; set; }
        public DateTime UltimaConsulta { get; set; }
        public string? ErrorEnConsulta { get; set; }
        public List<Detalle> Detalles { get; set; }
        public List<Sancion> Sanciones { get; set; }
        public ICollection<DatoSso> DatosSso { get; set; }
        //public Peticion Peticion { get; set; }
        public string EstadoIdentificacion { get; set; }
        public string _partitionKey { get; private set; }
        public Guid PeticionId { get; set; }
        public string NumeroIdentificacion { get; set; }
        public Guid? CargueId { get; set; }

        public override bool Equals(object otro)
        {
            if (otro is Medico otroRegistro)
            {
                //Check whether the compared object references the same data.
                if (ReferenceEquals(this, otroRegistro)) return true;
                var numeroIdentificacionEste = this.NumeroIdentifiacion ?? this.NumeroIdentificacion;
                var numeroIdentificacionOtro = otroRegistro.NumeroIdentifiacion ?? otroRegistro.NumeroIdentificacion;
                var esIgual =
                    numeroIdentificacionEste.Equals(
                        numeroIdentificacionOtro, StringComparison.OrdinalIgnoreCase) &&
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
            int hashNumeroIdentificacion = NumeroIdentifiacion == null ? 0 : NumeroIdentifiacion.GetHashCode(StringComparison.OrdinalIgnoreCase);

            //Calculate the hash code for the product.
            return hashTipoIdentificacion ^ hashNumeroIdentificacion;
        }

        public static class Nuevo
        {
            public static Medico DePrueba()
            {
                var idDelMedico = Guid.NewGuid();
                Guid idDeLaPeticion = Guid.NewGuid();
                return new Medico(idDelMedico)
                {
                    Detalles = new List<Detalle>
                        {
                            Detalle.Nuevo.DePrueba(idDelMedico), Detalle.Nuevo.DePrueba(idDelMedico)
                        },
                    ErrorEnConsulta = null,
                    NumeroIdentifiacion = "1234567890",
                    FechaCreacion = DateTime.Now.AddDays(-5),
                    PeticionId = idDeLaPeticion,
                    PrimerApellido = "Wan",
                    PrimerNombre = "Obi",
                    RegistradoEnRethus = true,
                    SegundoApellido = "Kenobi",
                    SegundoNombre = string.Empty,
                    TipoIdentificacion = TiposDeDocumentoDeIdentificacion.Cédula_de_Ciudadanía,
                    UltimaActualizacion = DateTime.Now.AddDays(-3),
                    UltimaConsulta = DateTime.Now,
                                        DatosSso = new List<DatoSso> { DatoSso.Nuevo.DePrueba(), DatoSso.Nuevo.DePrueba() },

                    _partitionKey = idDeLaPeticion.ToString()
                };
            }
            
            public static Medico BasicoDePrueba()
            {
                var idDelMedico = Guid.NewGuid();
                Guid idDeLaPeticion = Guid.NewGuid();
                return new Medico(idDelMedico)
                {
                    ErrorEnConsulta = null,
                    NumeroIdentifiacion = "1234567890",
                    FechaCreacion = DateTime.Now.AddDays(-5),
                    PeticionId = idDeLaPeticion,
                    PrimerApellido = "Wan",
                    PrimerNombre = "Obi",
                    RegistradoEnRethus = true,
                    SegundoApellido = "Kenobi",
                    SegundoNombre = string.Empty,
                    EstadoIdentificacion = "Vigente",
                    TipoIdentificacion = TiposDeDocumentoDeIdentificacion.Cédula_de_Ciudadanía,
                    UltimaActualizacion = DateTime.Now.AddDays(-3),
                    UltimaConsulta = DateTime.Now,
                                        DatosSso = new List<DatoSso> { DatoSso.Nuevo.DePrueba(), DatoSso.Nuevo.DePrueba() },

                    _partitionKey = idDeLaPeticion.ToString()
                };
            }
        }
    }
}
