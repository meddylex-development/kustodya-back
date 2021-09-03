using System.Collections.Generic;

namespace Kustodya.Infrastructure.Reportes.Services
{
    public class PowerBICapacityModel
    {
        public Properties properties { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string location { get; set; }
        public Sku sku { get; set; }
        public Tags tags { get; set; }

        public class Administration
        {
            public List<string> members { get; set; }
        }

        public class Properties
        {
            public string provisioningState { get; set; }
            public string state { get; set; }
            public Administration administration { get; set; }
            public string mode { get; set; }
        }

        public class Sku
        {
            public string name { get; set; }
            public string tier { get; set; }
            public int capacity { get; set; }
        }

        public class Tags
        {
        }
    }

}