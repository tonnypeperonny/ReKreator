using System.Collections.Generic;
using DotLiquid;

namespace ReKreator.MailDelivery.EmailModels
{
    public class DailyEmailModel : Drop
    {
        public string ReceiverName { get; set; }
        public List<string> Content { get; set; }
    }
}
