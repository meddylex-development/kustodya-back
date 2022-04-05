namespace Kustodya.Core.Reportes.Services
{
    public class ConfiguracionPowerBiClient
    {
        public ConfiguracionPowerBiClient()
        {
            
        }

        public string BaseAddress { get; set; }
        public string SubscriptionId { get; set; }
        public string ResourceGroupName { get; set; }
        public string DedicatedCapacityName { get; set; }
    }
}