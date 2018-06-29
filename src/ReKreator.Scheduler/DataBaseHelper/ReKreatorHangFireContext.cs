using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
