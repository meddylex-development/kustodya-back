using System;
using System.Runtime.Serialization;

namespace Kustodya.ApplicationCore.Services
{
    [Serializable]
    public class PucNoExisteException : Exception
    {
        public PucNoExisteException()
        {
        }

        public PucNoExisteException(string message) : base(message)
        {
        }

        public PucNoExisteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PucNoExisteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}