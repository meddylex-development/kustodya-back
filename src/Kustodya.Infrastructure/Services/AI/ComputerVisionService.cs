using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Threading;
using Kustodya.ApplicationCore.Dtos.Incapacidades;
using Kustodya.ApplicationCore.Interfaces.AI;

namespace Kustodya.BusinessLogic.Services.AI
{
    public class ComputerVisionService : IComputerVision
    {
        #region Dependency Injection
        public ComputerVisionService(IConfiguration config)
        {
            _config = config;
            //_transcriptionService = transcription;
            Authenticate();
        }

        private readonly IConfiguration _config;
       // private readonly ITranscripcionesService _transcriptionService;
        private ComputerVisionClient client { get; set; }
        #endregion

        private void Authenticate()
        {
            string key = _config.GetSection("CognitiveServices")["ComputerVision:Key"];
            string endpoint = _config.GetSection("CognitiveServices")["ComputerVision:Endpoint"];
            client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(key))
            { Endpoint = endpoint };
        }

        public async Task<OCRExtractionMethodModel> ReadPrintedTextAsync(MemoryStream streamImage, string uuid)
        {
            if (streamImage == null || streamImage.Length == 0)
            {
                throw new ArgumentNullException($"Null Object ({nameof(streamImage)})");
            }

            OCRExtractionMethodModel ocrModel = new OCRExtractionMethodModel();

            IList<string> text = null;
            streamImage.Seek(0, SeekOrigin.Begin);

            var textHeaders = await client.BatchReadFileInStreamAsync(streamImage).ConfigureAwait(false);

            const int numberOfCharsInOperationId = 36;
            string operationLocation = textHeaders.OperationLocation;

            string operationId = operationLocation.Substring(operationLocation.Length - numberOfCharsInOperationId);

            int i = 0;
            int maxRetries = 10;
            ReadOperationResult results;
            do
            {
                results = await client.GetReadOperationResultAsync(operationId).ConfigureAwait(false);
                await Task.Delay(1000).ConfigureAwait(false);
            }
            while ((results.Status == TextOperationStatusCodes.Running ||
                results.Status == TextOperationStatusCodes.NotStarted) && i++ < maxRetries);

            var recognitionResults = results.RecognitionResults;

            var json = JsonConvert.SerializeObject(results.RecognitionResults);
            ocrModel.RawOcrResponse = json;

            text = new List<string>();

            foreach (TextRecognitionResult result in recognitionResults)
            {
                foreach (Line line in result.Lines)
                {
                    text.Add(line.Text);
                }

            }
            ocrModel.Sentences = text;
            return ocrModel;
        }
    }
}
