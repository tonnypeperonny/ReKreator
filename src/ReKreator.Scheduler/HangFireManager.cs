using System;
using Hangfire;

namespace ReKreator.Scheduler
{
    public class HangFireManager : IHangFireManager
    {
        public void DailyParsing(Action parserMethod)
        {
            RecurringJob.AddOrUpdate("DailyParsing",() => parserMethod(), Cron.Daily());
        }

        public void NewContentNotificationSend(Action<string> emailNotification, string userEmail, int notificationDate)
        {
            RecurringJob.AddOrUpdate("ContentNotification", () => emailNotification(userEmail), Cron.DayInterval(notificationDate));
        }

        public void FavoriteContentNotificationSend(Action<string> emailNotification, string userEmail, DateTime notificationDate)
        {
            BackgroundJob.Schedule(() => emailNotification(userEmail), notificationDate);
        }
    }
}
