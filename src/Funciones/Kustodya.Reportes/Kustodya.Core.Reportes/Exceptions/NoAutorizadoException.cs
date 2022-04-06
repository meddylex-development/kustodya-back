using System;
using System.Runtime.Serialization;

namespace Kustodya.Core.Reportes.Exceptions
{
    [Serializable]
    public class NoAutorizadoException : Exception
    {
        public NoAutorizadoException()
        {
        }

        public NoAutorizadoException(string message) : base(message)
        {
        }

        public NoAutorizadoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoAutorizadoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}