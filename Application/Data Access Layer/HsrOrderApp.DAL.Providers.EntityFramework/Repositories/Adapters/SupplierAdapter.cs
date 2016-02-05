using System.Data.Objects.DataClasses;

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
                AccountNumber = s.AccountNumber,
                CreditRating = s.CreditRating,
                PreferredSupplierFlag = s.PreferredSupplierFlag,
                ActiveFlag = s.ActiveFlag,
                PurchasingWebServiceURL = s.PurchasingWebServiceURL,
                Version = s.Version.ToUlong(),
                SupplierName = s.SupplierName
            };
            //customer.Orders = OrderAdapter.AdaptOrders(c.Orders, customer);
            //customer.Addresses = AddressAdapter.AdaptAddresses(c.Addresses);
            return supplier;
        }
    }
}
