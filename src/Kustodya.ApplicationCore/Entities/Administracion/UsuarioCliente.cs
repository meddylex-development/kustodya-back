using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Administracion
{
    public class UsuarioCliente
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }
        public TblUsuarios Usuario { get; set; }
        public Cliente Cliente { get; set; }
    }
}
