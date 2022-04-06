namespace Kustodya.Medicos.Data
{
    public class OpcionesCosmosDB
    {
        public string AccountEndpoint { get; set; }
        public string Accountkey { get; set; }
        public string DatabaseName { get; set; }
        public string DefaultContainer { get; internal set; }
    }
}