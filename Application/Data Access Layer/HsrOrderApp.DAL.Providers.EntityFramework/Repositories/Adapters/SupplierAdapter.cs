using System;
using System.Data.Objects.DataClasses;
using System.Linq;

namespace HsrOrderApp.DAL.Providers.EntityFramework.Repositories.Adapters
{
    internal static class SupplierAdapter
    {
        internal static BL.DomainModel.Supplier AdaptSupplier(EntityReference<Supplier> s)
        {
            if (s == null || s.Value == null)
                return null;
            return AdaptSupplier(s.Value, null);
        }
        internal static BL.DomainModel.Supplier AdaptSupplier(Supplier s)
        {
            return AdaptSupplier(s, null);
        }

        internal static BL.DomainModel.Supplier AdaptSupplier(Supplier s, BL.DomainModel.User user)
        {
            BL.DomainModel.Supplier supplier = new BL.DomainModel.Supplier()
            {
                SupplierId = s.SupplierId,
                AccountNumber = s.AccountNumber,
                CreditRating = s.CreditRating,
                PreferredSupplierFlag = s.PreferredSupplierFlag,
                ActiveFlag = s.ActiveFlag,
                PurchasingWebServiceURL = s.PurchasingWebServiceURL,
                Version = s.Version.ToUlong(),
                SupplierName = s.SupplierName
            };
            supplier.SupplierToProducts = AdaptSupplierToProduct(s.SupplierToProducts, supplier);

            return supplier;
        }

        internal static IQueryable<BL.DomainModel.SupplierToProduct> AdaptSupplierToProduct(EntityCollection<SupplierToProduct> supplierToProductCollection, BL.DomainModel.Supplier s)
        {
            if (supplierToProductCollection.IsLoaded == false)
            {
                return null;
            }

            var supplierToProducts = from d in supplierToProductCollection.AsEnumerable()
                               select AdaptSupplierToProduct(d, s);
            return supplierToProducts.AsQueryable();
        }

        internal static BL.DomainModel.SupplierToProduct AdaptSupplierToProduct(SupplierToProduct d)
        {
            return AdaptSupplierToProduct(d, null);
        }

        internal static BL.DomainModel.SupplierToProduct AdaptSupplierToProduct(SupplierToProduct d, BL.DomainModel.Supplier s)
        {
            BL.DomainModel.SupplierToProduct supplierToProduct = new BL.DomainModel.SupplierToProduct
            {
                LastReceiptCost = d.LastReceiptCost,
                LastReceiptDate = d.LastReceiptDate,
                MaxOrderQty = d.MaxOrderQty,
                MinOrderQty = d.MinOrderQty,
                StandardPrice = d.StandardPrice,
                Version = d.Version.ToUlong(),
                Supplier = s ?? AdaptSupplier(d.SupplierReference),
                Product = ProductAdapter.AdaptProduct(d.ProductReference)
            };

            return supplierToProduct;
        }
    }
}
