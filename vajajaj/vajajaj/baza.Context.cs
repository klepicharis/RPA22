﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace vajajaj
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BazaZaVajeEntities : DbContext
    {
        public BazaZaVajeEntities()
            : base("name=BazaZaVajeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DOBAVITELJ> DOBAVITELJ { get; set; }
        public virtual DbSet<KUPEC> KUPEC { get; set; }
        public virtual DbSet<PRODUKT> PRODUKT { get; set; }
        public virtual DbSet<RAČUN> RAČUN { get; set; }
        public virtual DbSet<VRSTICA> VRSTICA { get; set; }
    }
}
