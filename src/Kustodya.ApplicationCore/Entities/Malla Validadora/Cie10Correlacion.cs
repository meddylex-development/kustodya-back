using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities.MallaValidadora
{
    public partial class Cie10Correlacion : BaseEntity
    {
        public int Cie10Id { get; set; }
        public string CorrelacionId { get; set; }

        public virtual Diagnostico Diagnostico { get; set; }
    }
}
