﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ToDoApp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ToDoEntitiesConnectionStringDB : DbContext
    {
        public ToDoEntitiesConnectionStringDB()
            : base("name=ToDoEntitiesConnectionStringDB")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<isler> islers { get; set; }
        public virtual DbSet<kullanicilar> kullanicilars { get; set; }
    }
}
