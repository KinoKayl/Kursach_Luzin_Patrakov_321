//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kursach_Luzin_Patrakov_321
{
    using System;
    using System.Collections.Generic;
    
    public partial class PurchasedItems
    {
        public int PurchaseID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string Item { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<System.DateTime> PurchaseDate { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
