using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp;
using NLog;

namespace ReKreator.HtmlParser.Core.HtmlProvider
{
    public class HtmlProvider : IHtmlProvider
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public async Task<Stream> GetHtmlPageAsync(Url url)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromMinutes(2);
                var response = await httpClient.GetAsync(url);
                if (response == null)
                    return null;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    Logger.Info($"{url} return status code {response.StatusCode}");
                    return null;
                }
                var result = await response.Content.ReadAsStreamAsync();
                return result;
            }
        }
    }
}