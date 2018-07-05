using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReKreator.Web.Models;

namespace ReKreator.Web.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public ActionResult DisplayHttpError(HttpStatusCode? id)
        {
            var httpStatusCode = (int)(id ?? HttpStatusCode.InternalServerError);
            Response.StatusCode = httpStatusCode;

            var error = new ErrorModel
            {
                Message = Resources.Resources.ResourceManager.GetString($"HttpError{httpStatusCode}Message"),
                ErrorTitle = Resources.Resources.ResourceManager.GetString($"HttpError{httpStatusCode}Title")
            };

            return View("DisplayHttpError",error);
        }
    }
}