using LogicaTareas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaCorreos
{
    class Program
    {
        static void Main(string[] args)
        {
            LCalificacionOrigen lCalificacionOrigen = new LCalificacionOrigen();
            lCalificacionOrigen.ProcesarCorreosCalificacionOrigen();
        }
    }
}
