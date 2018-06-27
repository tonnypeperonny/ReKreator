using System;
using System.Data.Entity;
using NLog;

namespace ReKreator.Data.Context
{
    public class DbStartupInitializer : IDisposable
    {
        private readonly DbContext context;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public DbStartupInitializer()
        {
            context = new ReKreatorContext();
        }

        public void Initialize()
        {
            try
            {
                context.Database.Initialize(false);
            }
            catch (Exception e)
            {
                Logger.Error(e, "An error occured during database initialization.");
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
