//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Product
    {
        public Product()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
            this.SupplierToProducts = new HashSet<SupplierToProduct>();
        }
    
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Category { get; set; }
        public double QuantityPerUnit { get; set; }
        public decimal ListUnitPrice { get; set; }
        public int UnitsOnStock { get; set; }
        public byte[] Version { get; set; }
    
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<SupplierToProduct> SupplierToProducts { get; set; }
    }
}