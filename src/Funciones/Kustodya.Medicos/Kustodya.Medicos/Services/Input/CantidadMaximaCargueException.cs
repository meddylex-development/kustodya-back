using System;

namespace Kustodya.Medicos.Services
{
    [Serializable]
    public class CantidadMaximaCargueException : Exception
    {
        public CantidadMaximaCargueException(int topeRegistros) : base ($"La cantidad máxima de registro permitida es {topeRegistros} registros")
        {
        }
    }
}