using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_Luzin_Patrakov_321
{
    public class PurchasedItems
    {
        public int PurchaseID { get; set; }
        public int UserID { get; set; }
        public int Item { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
