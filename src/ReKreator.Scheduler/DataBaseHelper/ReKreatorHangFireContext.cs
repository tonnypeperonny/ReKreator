using System.Data.Entity;

namespace ReKreator.Scheduler.DataBaseHelper
{
    public class ReKreatorHangFireContext : DbContext
    {
        public static ReKreatorHangFireContext Create()
        {
            return new ReKreatorHangFireContext();
        }

        public ReKreatorHangFireContext()
            : base("ReKreatorSheduler")
        {

        }
    }
}
