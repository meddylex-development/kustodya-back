using System;
using System.Runtime.Serialization;

namespace Kustodya.ApplicationCore.Entities.Contabilidades
{
    [Serializable]
    public class EntidadUsadaNoSePuedeEliminarException : Exception
    {

        public EntidadUsadaNoSePuedeEliminarException(Type entidad, Type entidadAsociada) 
            : base($"La entidad {entidad.Name} no se puede eliminar porque tiene una o mas entidades de tipo {entidadAsociada.Name} asociadas")
        {
        }

        public EntidadUsadaNoSePuedeEliminarException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntidadUsadaNoSePuedeEliminarException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}