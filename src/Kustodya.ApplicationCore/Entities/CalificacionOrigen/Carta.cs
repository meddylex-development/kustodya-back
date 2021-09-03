using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.CalificacionOrigen
{
    public class Carta
    {
        public int Id { get; set; }
        public string TextoTranscripcion { get; set; }
        public string FormatoWebArl { get; set; }
        public string ObtenerTextoTranscripcion(string fecha, string nombre, string identificacion,
                string telefono, string ciudad, string enfermedadLaboral, string contrato,
                string eps, string empresa, string empresaCorreo, string afp, string edad, string cargo, string fechaCovid)
        {
            //var dtFechaCovid = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(fechaCovid).ToShortDateString();

            string texto = TextoTranscripcion.Replace("{{fecha}}", fecha);
            texto = texto.Replace("{{nombre}}", nombre);
            texto = texto.Replace("{{identificacion}}", identificacion);
            texto = texto.Replace("{{telefono}}", telefono);
            texto = texto.Replace("{{ciudad}}", ciudad);
            texto = texto.Replace("{{enfermedadlaboral}}", enfermedadLaboral);
            texto = texto.Replace("{{contrato}}", contrato);
            texto = texto.Replace("{{eps}}", eps);
            texto = texto.Replace("{{empresa}}", empresa);
            texto = texto.Replace("{{empresacorreo}}", empresaCorreo);
            texto = texto.Replace("{{afp}}", afp);
            texto = texto.Replace("{{edad}}", edad);
            texto = texto.Replace("{{cargo}}", cargo);
            texto = texto.Replace("{{fechacovid}}", fechaCovid);

            
            return texto;
        }
        public string ObtenerFormatoWebArl(string fecha, string nombre, string identificacion,
                string telefono, string ciudad, string enfermedadLaboral, string contrato,
                string eps, string empresa, string empresaCorreo, string afp, string edad, string cargo, string fechaCovid)
        {
            //var dtFechaCovid = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(fechaCovid).ToShortDateString();
            string texto = FormatoWebArl.Replace("{{fecha}}", fecha);
            texto = texto.Replace("{{nombre}}", nombre);
            texto = texto.Replace("{{identificacion}}", identificacion);
            texto = texto.Replace("{{telefono}}", telefono);
            texto = texto.Replace("{{ciudad}}", ciudad);
            texto = texto.Replace("{{enfermedadlaboral}}", enfermedadLaboral);
            texto = texto.Replace("{{contrato}}", contrato);
            texto = texto.Replace("{{eps}}", eps);
            texto = texto.Replace("{{empresa}}", empresa);
            texto = texto.Replace("{{empresacorreo}}", empresaCorreo);
            texto = texto.Replace("{{afp}}", afp);
            texto = texto.Replace("{{empresa}}", empresa);
            texto = texto.Replace("{{edad}}", edad);
            texto = texto.Replace("{{cargo}}", cargo);
            texto = texto.Replace("{{fechacovid}}", fechaCovid);
            return texto;
        }
    }
    
}
