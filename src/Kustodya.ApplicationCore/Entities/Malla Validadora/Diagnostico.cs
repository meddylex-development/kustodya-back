using Kustodya.ApplicationCore.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kustodya.ApplicationCore.Entities.MallaValidadora
{
    public partial class Diagnostico : BaseEntity
    {
        public Diagnostico()
        {

        }
        public Diagnostico(string CodigoCie10, string Descripcion)
        {
            this.CodigoCie10 = CodigoCie10;
            this.Descripcion = Descripcion;
        }

        public new int Id { get; set; }
        public string CodigoCie10 { get; set; }
        public string Descripcion { get; set; }
        public string Capitulo { get; set; }
        public string TituloCapitulo { get; set; }
        public string Caracter { get; set; }
        public string Categoria { get; set; }
        public string Cie { get; set; }
        public int? DiasMaxConsulta { get; set; }
        public int? DiasMaxAcumulados { get; set; }
        public Sexos? Sexo { get; set; }
        public int? EdadMinima { get; set; }
        public int? EdadMaxima { get; set; }
        public int? EspecialidadMedicaId { get; set; }

        public virtual TipoCIE? TipoCie { get; set; }
        // public virtual ICollection<Incapacidad> Incapacidades { get; set; }
        public virtual ICollection<GrupoDiagnostico> GrupoDiagnosticos { get; set; }
    }
}
