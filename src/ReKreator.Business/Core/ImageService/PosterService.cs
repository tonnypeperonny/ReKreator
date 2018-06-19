using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace ReKreator.Business.Core.ImageService
{
    public class PosterService : IPosterService
    {
        private readonly string filePath;

        public PosterService()
        {
            var prefix = ConfigurationManager.AppSettings["imageFilesPrefix"];
            filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + prefix;

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
        }

        public async Task Upload(int id, Url imageLink)
        {
            var path = filePath + id;
            using (var httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromMinutes(2);
                var response = await httpClient.GetAsync(imageLink.Value);

                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    var image = await response.Content.ReadAsByteArrayAsync();

                    var webImage = new WebImage(image);
                    webImage.Save(path, "jpg");
                    webImage = new WebImage(path + ".jpeg");
                    webImage = webImage.Resize(160, 210, true, true);
                    webImage.Save(path + "small", "jpg");
                }
            }
        }

        public void Remove(int id)
        {
            var path = filePath + id;
            if (File.Exists(path + ".jpg"))
                File.Delete(path + ".jpg");
            if (File.Exists(path + ".jpeg"))
                File.Delete(path + ".jpeg");
        }

        public Url GetImage(int id)
        {
            var path = filePath + id + ".jpeg";
            return File.Exists(path) ? new Url(path) : null;
        }

        public Url GetSmallImage(int id)
        {
            var path = filePath + id + "small.jpeg";
            return File.Exists(path) ? new Url(path) : null;
        }
    }
}