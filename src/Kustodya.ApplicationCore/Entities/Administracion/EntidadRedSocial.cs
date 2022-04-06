using Kustodya.ApplicationCore.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Administracion
{
    public class EntidadRedSocial
    {
        public int Id { get; set; }
        public int EntidadId { get; set; }
        public RedSocial TipoRedSocial { get; set; }
        public string usuarioOLink { get; set; }
        public Entidad Entidad { get; set; }
    }
}
