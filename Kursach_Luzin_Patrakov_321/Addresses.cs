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
    
    public partial class Addresses
    {
        public int AddressID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
    
        public virtual Users Users { get; set; }
    }
}