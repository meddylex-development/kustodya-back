using Kustodya.ApplicationCore.Specifications;
using Roojo.Rethus;

namespace Kustodya.Medicos.Data
{
    public class ConsultaRethusPorTipoIdyNumId : BaseSpec<Consulta>{
        public ConsultaRethusPorTipoIdyNumId(TipoIdentificacionRethus? tipoId, string numId) :
            base(t =>
                t.TipoIdentificacion == tipoId && t.NumeroIdentificacion == numId && t.EstaEnRethus == true)
        {
            //base.AddInclude(query => query.Datos);
            AddIncludes(query => query.Include(o => o.Datos));
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