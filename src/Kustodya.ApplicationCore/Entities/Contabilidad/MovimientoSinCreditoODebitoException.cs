using System;
using System.Runtime.Serialization;

namespace Kustodya.ApplicationCore.Entities.Contabilidades
{
    [Serializable]
    internal class MovimientoSinCreditoODebitoException : Exception
    {
        public MovimientoSinCreditoODebitoException()
        {
        }

        public MovimientoSinCreditoODebitoException(string message) : base(message)
        {
        }

        public MovimientoSinCreditoODebitoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MovimientoSinCreditoODebitoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}