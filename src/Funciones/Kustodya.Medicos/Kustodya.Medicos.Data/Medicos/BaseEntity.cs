using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Kustodya.Medicos.Data
{
    public abstract class BaseEntity : Kustodya.ApplicationCore.Entities.BaseEntity
    {
        public BaseEntity(string discriminator)
        {
            
        }
        public BaseEntity()
        {
            
        }

        //public Guid id { get; set; }

        [Key]
        public string id { get; set; }
    }
}