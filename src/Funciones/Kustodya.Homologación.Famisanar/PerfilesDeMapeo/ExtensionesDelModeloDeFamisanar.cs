using System;

namespace Kustodya.Homologacion.Famisanar.PerfilesDeMapeo
{
    public static class ExtensionesDelModeloDeFamisanar
    {
        public static DateTime? ToDateTime(this string texto)
        {
            if (!long.TryParse(texto, out long timestamp))
                return null;
                
            System.DateTime fecha = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            fecha = fecha.AddMilliseconds(timestamp);
            return fecha;
        }
    }
}
