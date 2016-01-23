using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HsrOrderApp.BL.DomainModel.HelperObjects;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace HsrOrderApp.BL.DomainModel
{
    public class Supplier : DomainObject
    {
        public Supplier()
        {
            this.Products = new List<Product>().AsQueryable();
        }
        public int SupplierId { get; set; }

        public string AccountNumber { get; set; }

        public short CreditRating { get; set; }

        public bool PreferredSupplierFlag { get; set; }

        public bool ActiveFlag { get; set; }

        public string PurchasingWebServiceURL { get; set; }

        public IQueryable<Product> Products { get; set; }
    }
}
