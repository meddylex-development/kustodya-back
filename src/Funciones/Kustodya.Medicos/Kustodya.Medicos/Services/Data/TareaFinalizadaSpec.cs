using Kustodya.ApplicationCore.Specifications;
using Roojo.Rethus;
using Kustodya.Medicos.Data.Medicos;
using Kustodya.ApplicationCore.Helpers;

namespace Kustodya.Medicos.Data
{
    public class TareaFinalizadaSpec : BaseSpec<Tarea>
    {
        private int tareaId;

        public TareaFinalizadaSpec(int tareaId) :
            base(t =>
                t.Estado == EstadosTareas.Exitoso && t.Id == tareaId)
        {
            AddIncludes(query => query.Include(o => o.Consultas)
                .ThenInclude(i => i.DatosAcademicos));
            // AddIncludes(query => query.Include(o => o.Consultas)
            //     .ThenInclude(i => i.Datos));
            // AddInclude("Consultas.DatosAcademicos")
        }
    }
}