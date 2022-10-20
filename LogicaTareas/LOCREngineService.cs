using EntidadesTareas;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using SautinSoft.Document;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace LogicaTareas
{
    public class LOCREngineService
    {
        public OCRExtractionMethodModel GetOCRTextByAzureBlobId(string blobId, OCRExtractionMethod ocrExtractMethod)
        {
            var stream = ObtenerContenidoArchivo(blobId);
            var text = string.Empty;
            OCRExtractionMethodModel ocrMethod = new OCRExtractionMethodModel();
            switch (ocrExtractMethod)
            {
                case OCRExtractionMethod.Tesseract:
                    ocrMethod = GetOCRTextWithTesseract(stream);
                    break;
                case OCRExtractionMethod.Azure:
                    //ocrMethod = GetOCRTextWithAzureCognitive(stream, blobId).ConfigureAwait(false);
                    break;
                case OCRExtractionMethod.Google_VisionAI:
                    //ocrMethod = await GetOCRTextWithGoogleVisionAI(stream).ConfigureAwait(false);
                    break;
                case OCRExtractionMethod.iTextSharp:
                    ocrMethod = GetTextFromPDF(stream.ToArray());
                    if (ocrMethod.Sentences[0].Length == 0)
                        ocrMethod = ExtractImagesFromPDF(stream.ToArray());
                    break;
                case OCRExtractionMethod.Word:
                    ocrMethod = GetTextFromDoc(new MemoryStream(stream));
                    break;

                default:
                    //ocrMethod = await GetOCRTextWithAzureCognitive(stream, blobId).ConfigureAwait(false);
                    break;
            }
            return ocrMethod;
        }
        private static OCRExtractionMethodModel GetOCRTextWithTesseract(byte[] imageMemoryStream)
        {
            OCRExtractionMethodModel ocrModel = new OCRExtractionMethodModel();
            IList<string> lPhrases = new List<string>();
            StringBuilder sb = new StringBuilder();
            string text = string.Empty;
            try
            {
                using (var engine = new TesseractEngine(@".\TrainedLanguageData", "spa", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromMemory(imageMemoryStream))
                    {
                        using (var page = engine.Process(img))
                        {
                            using (var iter = page.GetIterator())
                            {
                                iter.Begin();
                                do
                                {
                                    do
                                    {
                                        do
                                        {
                                            do
                                            {
                                                if (iter.IsAtBeginningOf(PageIteratorLevel.Block))
                                                {
                                                    lPhrases.Add(sb.ToString());
                                                    sb.Clear();
                                                }
                                                sb.Append(iter.GetText(PageIteratorLevel.Word)).Append(" ");

                                                if (iter.IsAtFinalOf(PageIteratorLevel.TextLine, PageIteratorLevel.Word))
                                                {
                                                    //Console.WriteLine();
                                                }
                                            } while (iter.Next(PageIteratorLevel.TextLine, PageIteratorLevel.Word));

                                            if (iter.IsAtFinalOf(PageIteratorLevel.Para, PageIteratorLevel.TextLine))
                                            {
                                                //Console.WriteLine();
                                            }
                                        } while (iter.Next(PageIteratorLevel.Para, PageIteratorLevel.TextLine));
                                    } while (iter.Next(PageIteratorLevel.Block, PageIteratorLevel.Para));
                                } while (iter.Next(PageIteratorLevel.Block));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
            }
            ocrModel.Sentences = lPhrases;
            return ocrModel;
        }
        private byte[] ObtenerContenidoArchivo(string nombreArchivo)
        {
            string ftphost = "ftp://win5135.site4now.net/";
            string ftpfullpath = ftphost + nombreArchivo;

            using (WebClient request = new WebClient())
            {
                request.Credentials = new NetworkCredential("calificacionorigen", "Meddylex123");
                return request.DownloadData(ftpfullpath);
            }
        }
        private OCRExtractionMethodModel GetTextFromPDF(byte[] bytes)
        {
            var sb = new StringBuilder();

            try
            {
                var reader = new PdfReader(bytes);
                var numberOfPages = reader.NumberOfPages;

                for (var currentPageIndex = 1; currentPageIndex <= numberOfPages; currentPageIndex++)
                {
                    sb.Append(PdfTextExtractor.GetTextFromPage(reader, currentPageIndex));
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            if (sb.ToString().Length == 0)
            {

            }

            OCRExtractionMethodModel oCRExtractionMethodModel = new OCRExtractionMethodModel
            {
                Sentences = new List<string> { sb.ToString() }
            };
            return oCRExtractionMethodModel;
        }
        private OCRExtractionMethodModel ExtractImagesFromPDF(byte[] sourcepdf)
        {
            // NOTE:  This will only get the first image it finds per page.
            PdfReader pdf = new PdfReader(sourcepdf);
            RandomAccessFileOrArray raf = new RandomAccessFileOrArray(sourcepdf);

            try
            {
                for (int pageNumber = 1; pageNumber <= pdf.NumberOfPages; pageNumber++)
                {
                    PdfDictionary pg = pdf.GetPageN(pageNumber);
                    PdfDictionary res = (PdfDictionary)PdfReader.GetPdfObject(pg.Get(PdfName.RESOURCES));

                    PdfDictionary xobj = (PdfDictionary)PdfReader.GetPdfObject(res.Get(PdfName.XOBJECT));
                    if (xobj != null)
                    {
                        foreach (PdfName name in xobj.Keys)
                        {
                            PdfObject obj = xobj.Get(name);
                            if (obj.IsIndirect())
                            {
                                PdfDictionary tg = (PdfDictionary)PdfReader.GetPdfObject(obj);
                                PdfName type = (PdfName)PdfReader.GetPdfObject(tg.Get(PdfName.SUBTYPE));
                                if (PdfName.IMAGE.Equals(type))
                                {
                                    int XrefIndex = Convert.ToInt32(((PRIndirectReference)obj).Number.ToString(CultureInfo.InvariantCulture));
                                    PdfObject pdfObj = pdf.GetPdfObject(XrefIndex);
                                    PdfStream pdfStrem = (PdfStream)pdfObj;
                                    byte[] bytes = PdfReader.GetStreamBytesRaw((PRStream)pdfStrem);
                                    return GetOCRTextWithTesseract(bytes);
                                }
                            }
                        }
                    }
                }
            }

            catch
            {
                throw;
            }
            finally
            {
                pdf.Close();
                raf.Close();
            }
            return null;
        }
        public OCRExtractionMethodModel GetTextFromDoc(MemoryStream stream)
        {
            DocumentCore dc = null;
            stream.Position = 0;
            dc = DocumentCore.Load(stream, new DocxLoadOptions());
            OCRExtractionMethodModel oCRExtractionMethodModel = new OCRExtractionMethodModel
            {
                Sentences = new List<string> { dc.Content.ToString() }
            };
            return oCRExtractionMethodModel;
        }
    }
}
