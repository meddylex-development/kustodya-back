using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Entities.CalificacionOrigen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces.CalificacionOrigen
{
    public interface ICalificacionOrigenService
    {
        Task<IReadOnlyList<Correo>> ObtenerCorreos(Correo.EstadoCorreo estadoCorreo, string busqueda, long fechaDesde, long fechaHasta, int? pagina, int? tamanoPagina);
        Task<string> ObtenerNombreArchivo(string guid);
        Task<Correo> ObtenerCorreo(int id);
        Task<Carta> ObtenerModeloCarta();
        Task GuardarCarta(string cartaTranscripcion, string formatoWebArl, int correoId);
        Task ActualizarAdjunto (Adjunto adjunto);
        Task<IReadOnlyList<TblDivipola>> ObtenerDivipolas();
        Task<byte[]> ObtenerDocumento(MemoryStream stream, Dictionary<string, string> variables, MemoryStream firmaStream);
        Task ActualizarCorreo(Correo correo);
        Task<Dictionary<string, string>> ObtenerEmpresaDatos(string nombreEmpresa);
        Task ProcesarCorreosCalificacionOrigen();
    }
}
