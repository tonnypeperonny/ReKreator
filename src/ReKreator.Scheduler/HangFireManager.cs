using System;
using System.Collections.Generic;
using Hangfire;
using ReKreator.Data.Models;

namespace ReKreator.Scheduler
{
    public class HangFireManager : IHangFireManager
    {
        public void DailyParsing(Action parserMethod)
        {
            RecurringJob.AddOrUpdate("DailyParsing",() => parserMethod(), Cron.Daily());
        }

        public void FavoriteContentNotificationSend(Action<User, string, string> emailNotification, string daysLeftEvent, string eventName, User currentUser,
            DateTime notificationDate)
        {
            BackgroundJob.Schedule(() => emailNotification(currentUser,eventName,daysLeftEvent), notificationDate);
        }

        public void NewContentNotificationSend(Action<User, List<string>> emailNotification, User currentUser, List<string> eventsList, int notificationDate)
        {
            RecurringJob.AddOrUpdate("ContentNotification", () => emailNotification(currentUser,eventsList), Cron.DayInterval(notificationDate));
        }
    }
}
