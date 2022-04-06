using Kustodya.ApplicationCore.Specifications;
using Roojo.Rethus;

namespace Kustodya.Medicos.Data
{
    public class ConsultaDatosPrincipalesPorId : BaseSpec<Dato>{
        public ConsultaDatosPrincipalesPorId(int id) :
            base(t =>
                t.ConsultaId == id)
        {
            //AddIncludes(query => query.Include(o => o.Consultas)
                //.ThenInclude(i => i.DatosAcademicos));
            // AddIncludes(query => query.Include(o => o.Consultas)
            //     .ThenInclude(i => i.Datos));
            /*AddInclude(query => query.DatosAcademicos);
            AddInclude(query => query.DatosSso);
            AddInclude(query => query.Datos);*/
        }
    }
}