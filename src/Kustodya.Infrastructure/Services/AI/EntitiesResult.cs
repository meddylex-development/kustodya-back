using System.Collections.Generic;
using Kustodya.ApplicationCore.Interfaces.AI;

namespace Kustodya.ApplicationCore.Services.AI
{
    public partial class TextAnalyticsService
    {
        public class EntitiesResult : ITextAnalytics.IEntitiesResult
        {
            public IList<string> Entities { get; set; }

            public string ErrorMessage { get; set; }
        }
    }
}
