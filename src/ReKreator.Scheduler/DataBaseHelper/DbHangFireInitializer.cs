using System;
using System.Data.Entity;
using NLog;

namespace ReKreator.Scheduler.DataBaseHelper
{
    public class DbHangFireInitializer : IDisposable
    {
        private readonly DbContext context;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public DbHangFireInitializer()
        {
            context = new ReKreatorHangFireContext();
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
