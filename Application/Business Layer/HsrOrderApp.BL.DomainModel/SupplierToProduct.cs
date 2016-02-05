#region

using System;
using HsrOrderApp.BL.DomainModel.HelperObjects;
using HsrOrderApp.BL.DomainModel.SpecialCases;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

#endregion

namespace HsrOrderApp.BL.DomainModel
{
    public class SupplierToProduct : DomainObject
    {
        public SupplierToProduct()
        {
            this.Supplier = new UnknownSupplier();
            this.Product = new UnknownProduct();
            this.SupplierToProductId = default(int);
            this.StandardPrice = default(decimal);
            this.LastReceiptCost = default(decimal);
            this.LastReceiptDate = default(DateTime);
            this.MinOrderQty = default(int);
            this.MaxOrderQty = default(int);
        }

        public int SupplierToProductId { get; set; }

        public Supplier Supplier { get; set; }

        public Product Product { get; set; }

        [RangeValidator(typeof(decimal), "0.0", RangeBoundaryType.Inclusive, "0.0", RangeBoundaryType.Ignore)]
        public decimal StandardPrice { get; set; }

        [RangeValidator(typeof(decimal), "0.0", RangeBoundaryType.Inclusive, "0.0", RangeBoundaryType.Ignore)]
        public decimal LastReceiptCost { get; set; }

        public DateTime? LastReceiptDate { get; set; }

        [RangeValidator(0, RangeBoundaryType.Exclusive, int.MaxValue, RangeBoundaryType.Ignore)]
        public int MinOrderQty { get; set; }

        [RangeValidator(0, RangeBoundaryType.Exclusive, int.MaxValue, RangeBoundaryType.Ignore)]
        public int MaxOrderQty { get; set; }
    }
}