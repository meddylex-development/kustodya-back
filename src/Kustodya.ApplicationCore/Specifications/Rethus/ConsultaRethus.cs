using Kustodya.ApplicationCore.Entities.Rethus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Rethus
{
    public class ConsultaRethus : BaseSpec<tblRethusData_Main>
    {
        public ConsultaRethus(string documento, string tipo, string PrimerNombre, string PrimerApellido) :
           base(t =>
           (documento != null ? t.tNrodentificacion == documento : true) &&
           (tipo != null ? t.tTipoIdentificacion == tipo : true) &&
           (PrimerNombre == null ? true :
           ((t.tPrimerNombre == null ? "" : t.tPrimerNombre) + " " + (t.tSegundoNombre == null ? "" : t.tSegundoNombre)).Trim().ToLower()
           .Contains(PrimerNombre.ToLower())) &&
           (PrimerApellido == null ? true :
           ((t.tPrimerApellido == null ? "" : t.tPrimerApellido) + " " + (t.tSegundoApellido == null ? "" : t.tSegundoApellido)).Trim().ToLower()
           .Contains(PrimerApellido.ToLower())))
        {
            //AddIncludes(query => query.Include(o => o.RethusData_Academics));
            //base.AddInclude(query => query.Datos);
            //AddIncludes(query => query.Include(o => o.Datos));
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
