using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;

namespace Kustodya.Medicos.Nucleo
{
    public sealed class ConsultaMasiva
    {
        public ConsultaMasiva(ICollection<Registro> registros)
        {
            Guard.Against.Zero(registros.Count, nameof(registros));
            Registros = registros;
            Creacion = DateTime.Now;
            Procesar();
        }

        public ICollection<Registro> Registros { get; private set; }
        public DateTime Creacion { get; private set; }
        public DateTime FinalizacionProcesamiento { get; private set; }
        public EstadoDeLaConsulta Estado { get; private set; }

        public ConsultaMasiva Procesar()
        {
            Estado = EstadoDeLaConsulta.Procesando;
            foreach (var registro in Registros)
            {

            }
            return this;
        }

        public ConsultaMasiva Terminar()
        {
            Estado = EstadoDeLaConsulta.Finalizado;
            return this;
        }
    }
}
