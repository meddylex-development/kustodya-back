using System;
using System.Collections.Generic;
using System.Text;
using Kustodya.ApplicationCore.Interfaces;

namespace WebApi.Services
{
    public class Utilidades
    {
        public static string TextoNormalizado(string texto)
        {
            if (texto == null) {
                return " ";
            }
            if (texto.Length == 0)
            {
                return " ";
            }
            else {
                return " " + texto + " ";
            }
        }
    }
}
