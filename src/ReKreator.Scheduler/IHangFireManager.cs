using System;

namespace ReKreator.Scheduler
{
    public interface IHangFireManager
    {
        void DailyParsing(Action parserMethod);
        void FavoriteContentNotificationSend(Action<string> emailNotification, string userEmail, DateTime notificationDate);
        void NewContentNotificationSend(Action<string> emailNotification, string userEmail, int notificationDate);
    }
}