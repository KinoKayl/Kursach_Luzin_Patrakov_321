using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_Luzin_Patrakov_321
{
    internal class Reviews
    {
        public int ReviewID { get; set; }
        public int UserID { get; set; }
        public int LocationID { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
    }
}
