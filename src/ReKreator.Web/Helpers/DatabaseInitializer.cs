using ReKreator.Data.Context;

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
        }
    }
}