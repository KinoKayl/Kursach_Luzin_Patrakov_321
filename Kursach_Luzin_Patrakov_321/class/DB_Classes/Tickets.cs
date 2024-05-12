using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_Luzin_Patrakov_321
{
    public class Tickets
    {
        public int TicketID { get; set; }
        public int LocatinID { get; set; }
        public string TicketType { get; set; }
        public double Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string UserID { get; set; }
    }
}
