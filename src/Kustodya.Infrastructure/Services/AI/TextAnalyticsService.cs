using Microsoft.Extensions.Configuration;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using System;
using System.Text;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Interfaces.AI;
using System.Linq;

namespace Kustodya.ApplicationCore.Services.AI
{
    public partial class TextAnalyticsService : ITextAnalytics
    {
        #region Dependency Injection

        private readonly IConfiguration _config;

        public TextAnalyticsService(IConfiguration config)
        {
            _config = config;
            Authenticate();
        }

        private void Authenticate()
        {
            string key = _config.GetSection("CognitiveServices")["TextAnalytics:Key"];
            string endpoint = _config.GetSection("CognitiveServices")["TextAnalytics:Endpoint"];
            client = new TextAnalyticsClient(new ApiKeyServiceClientCredentials(key))
            { Endpoint = endpoint };
        }

        private TextAnalyticsClient client { get; set; }
        #endregion

        public async Task<ITextAnalytics.IEntitiesResult> ExtractEntitiesAsync(string text)
        {
            var entities = await client.EntitiesAsync(text, language: "es").ConfigureAwait(false);
            return new EntitiesResult
            {
                Entities = entities.Entities.Select(e => e.Name).ToList(),
                ErrorMessage = entities.ErrorMessage
            };
        }
    }
}
