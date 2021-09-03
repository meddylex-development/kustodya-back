using System;
namespace Kustodya.Medicos.Nucleo
{
    public sealed class Registro
    {
        public Registro(string numeroDeDocumento, TipoDeDocumento tipoDeDocumento)
        {


            NumeroDeDocumento = numeroDeDocumento;
            TipoDeDocumento = tipoDeDocumento;
        }

        public string NumeroDeDocumento { get; private set; }
        public TipoDeDocumento TipoDeDocumento { get; private set; }
        public Medico Medico { get; private set; }
    }
}
