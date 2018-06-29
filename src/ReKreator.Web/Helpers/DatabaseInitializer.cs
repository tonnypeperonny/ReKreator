using ReKreator.Data.Context;
using ReKreator.Scheduler;
using ReKreator.Scheduler.DataBaseHelper;

namespace ReKreator.Web.Helpers
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            using (var init = new DbStartupInitializer())
            {
                init.Initialize();
            }

            using (var init = new DbHangFireInitializer())
            {
                init.Initialize();
            }
        }
    }
}