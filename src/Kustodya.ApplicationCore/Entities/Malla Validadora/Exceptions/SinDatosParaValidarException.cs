using System;
using System.Runtime.Serialization;

namespace Kustodya.ApplicationCore.Entities.MallaValidadora
{
    [Serializable]
    public class SinDatosParaValidarException : Exception
    {
        public SinDatosParaValidarException()
        {
        }

        public SinDatosParaValidarException(string message) : base(message)
        {
        }

        public SinDatosParaValidarException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SinDatosParaValidarException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}