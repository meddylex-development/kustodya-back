using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.MallaValidadora
{
    public class AfiliadoNotFoundException : Exception
    {
        public AfiliadoNotFoundException(string message) : base(message)
        {
        }

        public AfiliadoNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
