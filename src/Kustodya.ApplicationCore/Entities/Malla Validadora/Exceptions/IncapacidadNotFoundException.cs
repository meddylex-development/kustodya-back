using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.MallaValidadora
{
    public class IncapacidadNotFoundException : Exception
    {
        public IncapacidadNotFoundException(string message) : base(message)
        {
        }

        public IncapacidadNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
