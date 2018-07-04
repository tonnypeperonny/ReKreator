using System.IO;
using System.Web;
using DotLiquid;
using ReKreator.MailDelivery.EmailModels;

namespace ReKreator.MailDelivery
{
    public  class DotLiquidConfiguration
    {
        public static Template ConfigureDailyTemplate()
        {
            Template.RegisterSafeType(typeof(DailyEmailModel),
                new[] { "ReceiverName", "Content"});

            return Template.Parse(
                new StreamReader(HttpContext.Current.Server.MapPath("~") + "/Views/Shared/NotificationEmailDailyTemplate.cshtml").ReadToEnd()); 
        }

        public static Template ConfigureFeaturedTemplate()
        {
            Template.RegisterSafeType(typeof(NotificationEmailModel),
                new[] { "NotificationEventName", "DaysLeftToEvent", "ReceiverName" });

            return Template.Parse(
                new StreamReader(HttpContext.Current.Server.MapPath("~") + "/Views/Shared/NotificationEmailFavoriteTemplate.cshtml").ReadToEnd());
        }
    }
}
