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
    
    public partial class Tickets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tickets()
        {
            this.TicketInfo = new HashSet<TicketInfo>();
        }
    
        public int TicketID { get; set; }
        public Nullable<int> LocationID { get; set; }
        public Nullable<int> TicketType { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> PurchaseDate { get; set; }
        public Nullable<int> UserID { get; set; }
    
        public virtual Locations Locations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TicketInfo> TicketInfo { get; set; }
        public virtual Users Users { get; set; }
    }
}
