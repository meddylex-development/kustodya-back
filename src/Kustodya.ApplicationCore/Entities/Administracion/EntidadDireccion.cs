using Kustodya.ApplicationCore.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Administracion
{
    public class EntidadDireccion
    {
        public int Id { get; set; }
        public int EntidadId { get; set; }
        public long DivipolaId { get; set; }
        public Via TipoViaPrincipal { get; set; }
        public int NumeroViaPrincipal { get; set; }
        public string LetraViaPrincipal { get; set; }
        public int NumeroViaSecundaria { get; set; }
        public string LetraViaSecundaria { get; set; }
        public int DistanciaInterseccion { get; set; }
        public string Indicaciones { get; set; }
        public Entidad Entidad{ get; set; }
        public TblDivipola Divipola { get; set; }


    }
}
