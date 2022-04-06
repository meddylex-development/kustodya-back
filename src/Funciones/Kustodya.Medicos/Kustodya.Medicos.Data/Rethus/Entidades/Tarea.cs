using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using Kustodya.ApplicationCore.Entities;

namespace Roojo.Rethus
{
    public partial class Tarea : BaseEntity
    {
        public Tarea()
        {
            Consultas = new HashSet<Consulta>();
        }

        public int Id { get; set; }
        public int UsuarioAsignadorId { get; set; }
        public int? RobotAsignadoId { get; set; }
        public int? Prioridad { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinalizacion { get; set; }

        public virtual Robot RobotAsignado { get; set; }
        public virtual EstadosTareas Estado { get; set; }
        public virtual TiposDeTarea TipoTarea { get; set; }
        public virtual ICollection<Consulta> Consultas { get; set; }

        public static partial class Nueva
        {
            public static Tarea DesdeDocumento(string numeroIdentificacion, TipoIdentificacionRethus tipoidentificacion)
            {
                var tarea = new Tarea
                {
                    TipoTarea = TiposDeTarea.Individual,
                    FechaAsignacion = DateTime.Now,
                    Estado = EstadosTareas.PorHacer,
                    Prioridad = 1
                    // TODO: Agregar usuario creador
                    // UsuarioAsignadorId = usuarioId
                };

                var consulta = Consulta.Nueva.DesdeDocumento(numeroIdentificacion, tipoidentificacion);
                tarea.Consultas.Add(consulta);
                return tarea;
            }

            public static Tarea PorNombres(string primerNombre, string primerApellido)
            {
                var tarea = new Tarea
                {
                    TipoTarea = TiposDeTarea.Individual,
                    FechaAsignacion = DateTime.Now,
                    Estado = EstadosTareas.PorHacer,
                    Prioridad = 1
                    // TODO: Agregar usuario creador
                    // UsuarioAsignadorId = usuarioId
                };

                var consulta = Consulta.Nueva.PorNombres(primerNombre, primerApellido);
                tarea.Consultas.Add(consulta);
                return tarea;
            }

            public static Tarea DePrueba()
            {
                int idDeLaTarea = 500;
                return new Tarea
                {
                    Id = idDeLaTarea,
                    Consultas = new List<Consulta> { Consulta.Nueva.DePrueba(idDeLaTarea), Consulta.Nueva.DePrueba(idDeLaTarea) },
                    Estado = EstadosTareas.Exitoso,
                    FechaAsignacion = DateTime.Now.AddMinutes(-5),
                    FechaFinalizacion = DateTime.Now.AddMinutes(-2),
                    FechaInicio = DateTime.Now.AddMinutes(-4),
                    RobotAsignado = Robot.Nuevo.DePrueba(),
                    TipoTarea = TiposDeTarea.Multiple,

                };
            }

        }

        public enum TiposDeTarea
        {
            Individual = 1,
            Multiple = 2
        }
    }
}
