using System;
using System.Runtime.Serialization;

namespace Kustodya.ApplicationCore.Services
{
    [Serializable]
    public class EntidadNoExisteException : Exception
    {
        public EntidadNoExisteException(string nombre) : base ($"La entidad {nombre} no existe")
        {
        }

        public EntidadNoExisteException(string nombre, string id) : base($"La entidad {nombre} con id {id} no existe")
        {
        }

        public EntidadNoExisteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntidadNoExisteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}