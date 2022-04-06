using System;

namespace Kustodya.Core.Entities
{
    public class BaseEntity
    {
        public BaseEntity(string nombre, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            // this.id = $"{nombre}|{Id.ToString()}";
        }

        public Guid Id { get; private set; }
        // public string id { get; private set; }
    }
}