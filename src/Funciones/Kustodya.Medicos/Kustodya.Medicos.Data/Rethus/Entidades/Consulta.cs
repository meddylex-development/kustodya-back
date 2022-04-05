using System;
using System.Collections.Generic;
using Kustodya.ApplicationCore.Entities;

namespace Roojo.Rethus
{
    public partial class Consulta : BaseEntity
    {
        public Consulta()
        {
            DatosAcademicos = new HashSet<DatoAcademico>();
            Datos = new HashSet<Dato>();
            Sanciones = new HashSet<Sancion>();
        }

        public int Id { get; set; }
        public int TareaId { get; set; }
        // public int TipoBusquedaId { get; set; }
        // public int EstadoId { get; set; }
        // public int? TipoIdentificacionId { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool EstaEnRethus { get; set; }

        public virtual Estados Estado { get; set; }
        public virtual Roojo.Rethus.TipoIdentificacionRethus? TipoIdentificacion { get; set; }
        public virtual TipoDeBusqueda TipoBusqueda { get; set; }
        public virtual ICollection<DatoAcademico> DatosAcademicos { get; set; }
        public virtual ICollection<Dato> Datos { get; set; }
        public virtual ICollection<Sancion> Sanciones { get; set; }
        public virtual ICollection<DatoSso> DatosSso { get; set; }
        public virtual Tarea Tarea { get; set; }

        public static partial class Nueva
        {
            public static Consulta DesdeDocumento(string numeroIdentificacion, Rethus.TipoIdentificacionRethus tipoIdentificacion)
            {
                return new Consulta
                {
                    NumeroIdentificacion = numeroIdentificacion,
                    TipoIdentificacion = tipoIdentificacion,
                    TipoBusqueda = TipoDeBusqueda.PorDocumentoDeIdentificacion,
                    Estado = Consulta.Estados.PorHacer
                };
            }

            public static Consulta PorNombres(string primerNombre, string primerApellido)
            {
                return new Consulta
                {
                    Nombre = primerNombre,
                    Apellido = primerApellido,
                    TipoBusqueda = TipoDeBusqueda.PorNombre,
                    Estado = Consulta.Estados.PorHacer,
                    // TODO: Quitar esta asignación PK-1070
                    // TipoIdentificacion = TipoIdentificacionRethus.Cedula
                };
            }

            public static Consulta DePrueba(int idDeLaTarea)
            {
                int idDeLaConsulta = 40;
                return new Consulta
                {
                    Id = idDeLaConsulta,
                    Apellido = "Kenobi",
                    Datos = new List<Dato> { Dato.Nuevo.DePrueba(idDeLaConsulta), Dato.Nuevo.DePrueba(idDeLaConsulta) },
                    DatosAcademicos = new List<DatoAcademico> { DatoAcademico.Nuevo.DePrueba(idDeLaConsulta), DatoAcademico.Nuevo.DePrueba(idDeLaConsulta) },
                    DatosSso = new List<DatoSso> { DatoSso.Nuevo.DePrueba(idDeLaConsulta), DatoSso.Nuevo.DePrueba(idDeLaConsulta) },
                    Estado = Estados.Exitoso,
                    EstaEnRethus = true,
                    Nombre = "Obi",
                    NumeroIdentificacion = "123456aA",
                    Sanciones = new List<Sancion> { Sancion.Nueva.DePrueba(idDeLaConsulta) },
                    TareaId = idDeLaTarea,
                    TipoBusqueda = TipoDeBusqueda.PorDocumentoDeIdentificacion,
                    TipoIdentificacion = Roojo.Rethus.TipoIdentificacionRethus.Cédule_de_Ciudadanía
                };
            }
        }

        public enum TipoDeBusqueda : int
        {
            PorDocumentoDeIdentificacion = 1,
            PorNombre = 2
        }

        public enum Estados
        {
            PorHacer = 5,
            EnProgreso = 6,
            Exitoso = 7,
            EnPausa = 8
        }
    }
}
