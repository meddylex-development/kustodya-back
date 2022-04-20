using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Entities.Concepto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces.Incapacidades
{
    public interface IPacienteService
    {
        Task<TblPacientes> GetPacienteById(int IIdpaciente);

        Task<TblPacientes> GetPacienteByNumeroDocumento(int IIdTipoIdentificacion, string tNumeroDocumento);
        Task<TblPacientes> ValidarPacientePorNumeroDocumento(int iIdTipoDocumento, string tNumeroDocumento);
        Task<IReadOnlyList<PacientesPorEmitir>> PacientesPorEmitir(PacientesPorEmitir.EstadoConcepto? estado, int usuario, string busqueda, int? skip = null, int? take = null);// se incluye filtro de usuario
    }
}