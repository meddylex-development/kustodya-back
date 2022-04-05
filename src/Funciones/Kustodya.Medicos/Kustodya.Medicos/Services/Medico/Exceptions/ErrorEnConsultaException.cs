using System;
using System.Runtime.Serialization;

namespace Kustodya.Medicos.Services
{
    [Serializable]
    internal class ErrorEnConsultaException : Exception
    {
        public ErrorEnConsultaException()
        {
        }

        public ErrorEnConsultaException(string message) : base(message)
        {
        }

        public ErrorEnConsultaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ErrorEnConsultaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}