using Kustodya.ApplicationCore.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Administracion
{
    public class ClienteRedSocial
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public RedSocial TipoRedSocial { get; set; }
        public int UsuarioOLink { get; set; }
        public Cliente Cliente { get; set; }
    }
}
