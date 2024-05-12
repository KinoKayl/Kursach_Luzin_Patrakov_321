using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_Luzin_Patrakov_321
{
    public class Schedule
    {
        public int ScheduleID { get; set; }
        public int LocationID { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string Event { get; set; }

    }
}
