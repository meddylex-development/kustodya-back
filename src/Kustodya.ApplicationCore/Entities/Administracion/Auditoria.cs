using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Administracion
{
    public class Auditoria
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public TipoAccion Accion { get; set; }
        public int  EntidadId { get; set; }
        public enum TipoAccion : int
        {
            Crear = 1,
            Consultar = 2,
            Actualizar = 3,
            Eliminar = 4,
        }

    }
}
