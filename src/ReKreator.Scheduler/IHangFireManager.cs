using System;
using System.Collections.Generic;
using ReKreator.Data.Models;

namespace ReKreator.Scheduler
{
    public interface IHangFireManager
    {
        void DailyParsing(Action parserMethod);
        void FavoriteContentNotificationSend(Action<User, string, string> emailNotification, string daysLeftEvent, string eventName, User currentUser, DateTime notificationDate);
        void NewContentNotificationSend(Action<User, List<string>> emailNotification, User currentUser, List<string> eventsList, int notificationDate);
    }
}