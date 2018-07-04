using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using DotLiquid;
using ReKreator.Data.Models;
using ReKreator.MailDelivery.EmailModels;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ReKreator.MailDelivery
{
    public class EmailManager
    {
        public static async Task SendNewContentNotification(User user, List<string> eventsList)
        {
            var client = new SendGridClient(ConfigurationManager.AppSettings["SendGridApi"]);
            var from = new EmailAddress("rekreatorgodeltech@gmail.com","Rekreator team");
            var to = new EmailAddress(user.Email,user.UserName);
            var template = DotLiquidConfiguration.ConfigureDailyTemplate();
            var emailModel = new DailyEmailModel {Content = eventsList, ReceiverName = user.UserName};
            var htmlContent = template.Render(Hash.FromAnonymousObject(emailModel));
            var msg = MailHelper.CreateSingleEmail(from, to, EmailResources.Resources.NewContentNotification, string.Empty, htmlContent);
            await client.SendEmailAsync(msg);
        }

        public static async Task SendFavoriteEventNotification(User user, string daysLeftToEvent, string eventName)
        {
            var client = new SendGridClient(ConfigurationManager.AppSettings["SendGridApi"]);
            var from = new EmailAddress("rekreatorgodeltech@gmail.com", "Rekreator team");
            var to = new EmailAddress(user.Email, user.UserName);
            var template = DotLiquidConfiguration.ConfigureFeaturedTemplate();
            var emailModel = new NotificationEmailModel { NotificationEventName = eventName, ReceiverName = user.UserName, DaysLeftToEvent = daysLeftToEvent };
            var htmlContent = template.Render(Hash.FromAnonymousObject(emailModel));
            var msg = MailHelper.CreateSingleEmail(from, to, EmailResources.Resources.FeaturedEvent, string.Empty, htmlContent);
            await client.SendEmailAsync(msg);
        }
    }
}
