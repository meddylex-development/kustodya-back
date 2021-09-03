namespace Kustodya.Infrastructure.Reportes.Services
{
    public class ConfiguracionAad
    {
        public const string Seccion = "ConfiguracionAad";
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string[] Scope { get; set; }
        public string AuthorityUri { get; set; }
    }
}