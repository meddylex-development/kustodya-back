using Kustodya.Medicos.Services.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using Kustodya.Medicos.Data;
using Kustodya.Medicos.Data.Medicos;
namespace Kustodya.Medicos.Specifications
{
    public class MedicosSpec : BaseSpec<Medico>
    {
        public MedicosSpec(ICollection<string> ids, TiposDeDocumentoDeIdentificacion tipo)
            : base(
                  m =>
                  ids.Contains(m.NumeroIdentifiacion)
                  &&
                  m.TipoIdentificacion == tipo)
        {
            //ApplyOrderByDescending(m => m.FechaCreacion);
        }

        public MedicosSpec(List<Registro> models)
                : base(e =>
                    models.Select(m => m.TipoIdentificacion).ToList().Contains(e.TipoIdentificacion.Value) &&
                    models.Select(m => m.NumeroIdentificacion).ToList().Contains(e.NumeroIdentifiacion))
        {
        }

        public MedicosSpec(List<TiposDeDocumentoDeIdentificacion> tipos, List<string> identificaciones)
            : base(m =>
               tipos.Contains(m.TipoIdentificacion.Value) && identificaciones.Contains(m.NumeroIdentifiacion))
        {
        }

        //public MedicosSpec(List<InputModel> models)
        //    : base(m => models.ForEach(model => model.NumeroIdentificacion == m.NumeroIdentifiacion && model.TipoIdentificacion == m.TipoIdentificacion))
        //{
        //}
    }

    public class MedicosExistenteSinErrorSpec : BaseSpec<Medico>
    {
        public MedicosExistenteSinErrorSpec(ICollection<string> ids, TiposDeDocumentoDeIdentificacion tipo)
            : base(
                  m =>
                  (ids.Contains(m.NumeroIdentifiacion) || ids.Contains(m.NumeroIdentificacion)) 
                  && m.TipoIdentificacion == tipo 
                  && m.ErrorEnConsulta == null)
        {
            ApplyOrderByDescending(m => m.UltimaConsulta);
        }

        public MedicosExistenteSinErrorSpec(string numeroIdentifiacion, TiposDeDocumentoDeIdentificacion tipo)
            : base(
                  m =>
                    (
                    m.NumeroIdentifiacion == numeroIdentifiacion
                    || m.NumeroIdentificacion == numeroIdentifiacion
                    )
                  && m.TipoIdentificacion == tipo 
                  && m.ErrorEnConsulta == null)
        {
            // ApplyOrderByDescending(m => m.UltimaConsulta);
        }

        public MedicosExistenteSinErrorSpec(string primerNombre, string primerApellido)
            : base(
                  m =>
                    (
                    m.PrimerNombre == primerNombre
                    || m.PrimerApellido == primerApellido
                    )
                  && m.ErrorEnConsulta == null)
        {
            // ApplyOrderByDescending(m => m.UltimaConsulta);
        }
        public MedicosExistenteSinErrorSpec(string CargueId)
            : base(
                  m =>
                    (
                    m.CargueId == new Guid(CargueId)
                    )
                  && m.ErrorEnConsulta == null)
        {
            // ApplyOrderByDescending(m => m.UltimaConsulta);
        }
    }
}
