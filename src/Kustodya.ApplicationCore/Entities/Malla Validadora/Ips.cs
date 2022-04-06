using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.MallaValidadora
{
    public class Ips : BaseEntity
    {
        public Ips()
        {
            
        }

        public Ips(string Nit)
        {
            this.Nit = Nit;
        }

        public string Nit { get; set; }

        public Estados? Estado { get; set; }

        public string? CodigoDaneMunicipio { get; set; }

        public enum Estados
        {
            Adscrita = 1,
            NoAdscrita 
        }
    }
}
