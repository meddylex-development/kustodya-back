using Kustodya.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.Api.Models;
using Microsoft.Rest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebApi.Controllers;
using Microsoft.Extensions.Options;
using Kustodya.Infrastructure.Services;

namespace Kustodya.WebApi.Controllers
{
    public class PowerBIController : BaseController
    {
        #region DI
        private readonly IOptions<ConfiguracionPowerBiModel> _appSettings;
        private ILogger _logger { get; set; }
        private IConfiguration _configuration { get; set; }

        public PowerBIController(ILogger<PowerBIController> logger, IConfiguration configuration, IOptions<ConfiguracionPowerBiModel> appSettings)
        {
            _logger = logger;
            _configuration = configuration;
            _appSettings = appSettings;
        }
        #endregion

        [HttpGet]
        [ProducesResponseType(typeof(EmbeddedReportConfig), 200)]
        public async Task<IActionResult> EmbedReport(string groupid, string reportid)
        {
            try
            {
                var proUserToken = await AuthenticateAsync();
                List<EffectiveIdentity> filters = new List<EffectiveIdentity>();

                EmbeddedReportConfig report = await GenerateReport(proUserToken.AccessToken, groupid, reportid, filters);
                return Ok(report);
            }
            catch (ArgumentNullException)
            {
                return StatusCode(500, "Couldn't authenticate with the power BI Service");
            }

        }

        /// <summary>
        /// Returns Embed token, Embed URL, and Embed token expiry to the client
        /// </summary>
        /// <returns>JSON containing parameters for embedding</returns>
        [HttpGet]
        [Route("/api/[Controller]/Grupos/{groupoId:guid}/Reportes/{reporteId:guid}")]
        public object GetEmbedInfo(Guid groupoId, Guid reporteId)
        {
            try
            {
                string configValidationResult = ValidadorDeConfiguracionService.ValidateConfig(_appSettings, reporteId);
                if (configValidationResult != null)
                {
                    HttpContext.Response.StatusCode = 400;
                    return configValidationResult;
                }
                string accessToken = AadService.GetAccessToken(_appSettings);
                var embedInfo = PbiEmbedService.GetEmbedParam(accessToken, _appSettings, reporteId);
                return embedInfo;
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                return ex.Message + "\n\n" + ex.StackTrace;
            }
        }

        #region Helper Methods
        private async Task<EmbeddedReportConfig> GenerateReport(string token, string groupId, string reportId, List<EffectiveIdentity> filters)
        {
            if (string.IsNullOrWhiteSpace(token))
                _logger.LogError("PowerBI token can't be null");

            EmbeddedReportConfig config = null;
            var tokenCredentials = new TokenCredentials(token, "Bearer");

            // Create a Power BI Client object. It will be used to call Power BI APIs.
            using (var client = new PowerBIClient(new Uri("https://api.powerbi.com"), tokenCredentials))
            {
                Report report = client.Reports.GetReportInGroup(new Guid(groupId), new Guid(reportId));
                if (report == null)
                    return config;

                var requestParameters = new GenerateTokenRequest
                {
                    AccessLevel = "View"
                };

                if (filters != null)
                    requestParameters.Identities = filters;

                // Generate EmbedToken This function sends the POST message
                //with all parameters and returns the token
                EmbedToken embedtoken = await client.Reports.GenerateTokenInGroupAsync(
                 new Guid(groupId),
                 new Guid(reportId),
                 requestParameters);

                config = new EmbeddedReportConfig
                {
                    EmbedURL = report.EmbedUrl,
                    GroupID = groupId,
                    ReportData = report,
                    ReportID = reportId,
                    Token = embedtoken?.Token,
                    TokenID = embedtoken?.TokenId.ToString(),
                    Expiration = embedtoken?.Expiration
                };
                return config;
            }
        }

        private async Task<OAuthResult> AuthenticateAsync()
        {
            var oauthEndpoint = new Uri($"https://login.microsoftonline.com/3099065f-8312-4ce9-8214-8e81ac9c6cd2/oauth2/token");

            using (var client = new HttpClient())
            using (var formContent = new FormUrlEncodedContent(new[]
                {
                    GetConfig("resource"),
                    GetConfig("client_id"),
                    GetConfig("client_secret"),
                    GetConfig("grant_type"),
                    GetConfig("username"),
                    GetConfig("password"),
                    GetConfig("scope")
                }))
            {
                var response = await client.PostAsync(oauthEndpoint, formContent);

                var json = await response.Content.ReadAsStringAsync();
                var token = JsonConvert.DeserializeObject<OAuthResult>(json);
                if (string.IsNullOrWhiteSpace(token.AccessToken))
                {
                    _logger.LogError($"❗ Failed to authenticate to PowerBI, with credentials\r\n\t " +
                        $"\r\n\tresource: {GetConfig("resource")}" +
                        $"\r\n\tclient_id: {GetConfig("client_id")}" +
                        $"\r\n\tclient_secret: {GetConfig("client_secret")}" +
                        $"\r\n\tgrant_type: {GetConfig("grant_type")}" +
                        $"\r\n\tusername: {GetConfig("username")}" +
                        $"\r\n\tpassword: {GetConfig("password")}" +
                        $"\r\n\tscope: {GetConfig("scope")}");
                }

                return token;
            }
        }

        [NonAction]
        public KeyValuePair<string, string> GetConfig(string key)
        {
            var config = _configuration.GetSection("PowerBI");
            return new KeyValuePair<string, string>(key, config[key]);
        }
        #endregion    
    }
}