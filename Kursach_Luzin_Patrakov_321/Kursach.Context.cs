﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Kursach_Luzin_Patrakov_321Entities1 : DbContext
    {
        public Kursach_Luzin_Patrakov_321Entities1()
            : base("name=Kursach_Luzin_Patrakov_321Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<ContactInfo> ContactInfo { get; set; }
        public virtual DbSet<Cosplayers> Cosplayers { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<InvitedUsers> InvitedUsers { get; set; }
        public virtual DbSet<LocationParticipants> LocationParticipants { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Stalls> Stalls { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TicketInfo> TicketInfo { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Vendors> Vendors { get; set; }
    }
}
