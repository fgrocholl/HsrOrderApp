﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HsrOrderApp.DAL.Providers.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HsrOrderAppEntities : DbContext
    {
        public HsrOrderAppEntities()
            : base("name=HsrOrderAppEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Address> AddressSet { get; set; }
        public DbSet<Customer> CustomerSet { get; set; }
        public DbSet<OrderDetail> OrderDetailSet { get; set; }
        public DbSet<Order> OrderSet { get; set; }
        public DbSet<Product> ProductSet { get; set; }
        public DbSet<Role> RoleSet { get; set; }
        public DbSet<User> UserSet { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierToProduct> SupplierToProducts { get; set; }
    }
}