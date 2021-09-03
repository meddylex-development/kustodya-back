using Kustodya.ApplicationCore.Entities.CalificacionOrigen;
using Kustodya.BusinessLogic.Services.AI;
using Kustodya.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DatosEmpresas
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var archivos = Directory.GetFiles("C:\\Users\\fabia\\Desktop\\Proyectos\\Kustodia\\Cartas");
            dbProtektoV1Context context = new dbProtektoV1Context();
            OCREngineService oCREngineService = new OCREngineService(null, null, null, null, null, null, null, null, null, null, null);
            List<TextoReconocidoCarta> Cartas = new List<TextoReconocidoCarta>();
            foreach (var nombrearchivo in archivos)
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    Dictionary<string, string> datos = new Dictionary<string, string>();
                    using (FileStream file = new FileStream(nombrearchivo, FileMode.Open, FileAccess.Read))
                        file.CopyTo(ms);
                    ms.Position = 0;
                    var modelo = oCREngineService.GetTextFromDoc(ms);
                    if (modelo.Sentences.Count > 0) {

                        //Archivo
                        datos.Add("Archivo", nombrearchivo.Split("\\")[nombrearchivo.Split("\\").Length - 1]);

                        //Cedula
                        var texto = modelo.Sentences[0].Split("CC")[1].Trim();
                        texto = texto.Split("\n")[0].Trim();
                        datos.Add("CC", texto);

                        //Nombre
                        texto = modelo.Sentences[0].Split("SEÑOR(A):")[1].Trim();
                        texto = texto.Split("\n")[0].Trim();
                        datos.Add("Nombre", texto);

                        //Enfermedad Laboral
                        /*texto = modelo.Sentences[0].Split("EL")[1].Trim();
                        texto = texto.Split("CTO")[0].Trim();
                        datos.Add("EnfermedadLaboral", texto);*/

                        //Enfermedad Laboral
                        texto = modelo.Sentences[0].Split("CTO")[1].Trim();
                        texto = texto.Split("\n")[0].Trim();
                        texto = texto.Replace(":", "");
                        texto = texto.Trim();
                        datos.Add("CTO", texto);

                        //Correo
                        string correo = "";
                        texto = modelo.Sentences[0].Split("AFP")[0].Trim();
                        texto = texto.Split(" ")[texto.Split(" ").Length - 1].Trim();
                        if (texto.Contains("@"))
                        {
                            datos.Add("Correo", texto);
                            correo = texto;
                        }
                        else {
                            datos.Add("Correo", "");
                            correo = "\n";
                        }

                        //Empresa
                        texto = modelo.Sentences[0].Split("EMPLEADOR")[1].Trim();
                        texto = texto.Split(correo)[0].Trim();
                        datos.Add("Empresa", texto);

                        Cartas.Add(new TextoReconocidoCarta {
                            NombreArchivo = datos.GetValueOrDefault("Archivo", "sinnombre"),
                            Cedula = datos.GetValueOrDefault("CC", "sinnombre"),
                            Nombre = datos.GetValueOrDefault("Nombre", "sinnombre"),
                            Contrato = datos.GetValueOrDefault("CTO", "sinnombre"),
                            Empresa = datos.GetValueOrDefault("Empresa", "sinnombre"),
                            EmpresaCorreo = datos.GetValueOrDefault("Correo", "sinnombre"),
                        });
                    }
                }
                catch (Exception) { }
            }
            foreach (var item in Cartas)
            {
                context.TextoReconocidoCartas.Add(item);
            }
            context.SaveChanges();
        }
    }
}
