using System;
using System.Runtime.Serialization;

namespace Kustodya.ApplicationCore.Services
{
    [Serializable]
    public class EntidadYaExisteException : Exception
    {
        public EntidadYaExisteException()
        {
        }

        public EntidadYaExisteException(string nombre, string id) : base($"La entidad {nombre} con id {id} ya existe")
        {
        }

        public EntidadYaExisteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntidadYaExisteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}