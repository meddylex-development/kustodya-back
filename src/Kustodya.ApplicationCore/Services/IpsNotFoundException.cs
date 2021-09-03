using System;
using System.Runtime.Serialization;

namespace Kustodya.ApplicationCore
{
    [Serializable]
    public class IpsNotFoundException : Exception
    {
        public IpsNotFoundException()
        {
        }

        public IpsNotFoundException(string message) : base(message)
        {
        }

        public IpsNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IpsNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}