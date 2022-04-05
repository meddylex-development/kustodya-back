using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kustodya.Medicos.Data
{
    public class CargueMasivo : BaseEntity
    {
        //public CargueMasivo() : base(nameof(CargueMasivo))
        //{
        //}

        public CargueMasivo(Guid peticionId) : base(nameof(CargueMasivo))
        {
            PeticionId = peticionId;
            _partitionKey = PeticionId.ToString();
            var guid = Guid.NewGuid();
            base.id = $"{nameof(CargueMasivo)}|{guid}";
        }

        public string _partitionKey { get; set; }
        public Guid PeticionId { get; set; }
        public string NombreArchivo { get; set; }
        public DateTime Creado { get; set; }
        public int TotalSubido { get; set; }
        public int Validos { get; set; }
        public int Unicos { get; set; }
        public int TotalDuplicados { get; set; }
        public int RegistradosEnRethus { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Medicos.Estado Estado { get; set; }
        [NotMapped]
        public object Duplicados { get; set; }
        public string NombreUsuario { get; internal set; }
        public DateTime? Actualizado { get; set; }
        public int? Reintentos { get; set; }
    }
}