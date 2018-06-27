using System.Collections.Generic;
using System.Web.Mvc;

namespace ReKreator.Web.Helpers
{
    public static class ModelStateErrorExtension
    {
        public static void AddError(this ModelStateDictionary model, List<string> errorList)
        {
            foreach (var error in errorList)
            {
                model.AddModelError(string.Empty, error);
            }
        }
    }
}