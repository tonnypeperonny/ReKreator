using DotLiquid;

namespace ReKreator.MailDelivery.EmailModels
{
    public class NotificationEmailModel : Drop
    {
        public string ReceiverName { get; set; }
        public string NotificationEventName { get; set; }
        public string DaysLeftToEvent { get; set; }
    }
}
