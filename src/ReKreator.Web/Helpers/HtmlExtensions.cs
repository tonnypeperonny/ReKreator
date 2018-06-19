using System;
using System.IO;
using System.Web.Mvc;

namespace ReKreator.Web.Helpers
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString Image(this HtmlHelper html, string path)
        {
            var img = $"data:image/jpg;base64,{Convert.ToBase64String(File.ReadAllBytes(path))}";
            return new MvcHtmlString("<img class=\"img-fluid rounded mb-0 mb-md-0\" src='" + img + "' alt=\"\">");
        }
    }
}