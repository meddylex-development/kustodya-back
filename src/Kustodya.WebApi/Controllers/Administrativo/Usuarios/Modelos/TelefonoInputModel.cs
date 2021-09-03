﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Administrativo.Usuarios.Modelos
{
    public class TelefonoInputModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public long Numero { get; set; }
        public string Extension { get; set; }
        public string Descripcion { get; set; }
    }
}
