using System.Data.Objects.DataClasses;

namespace HsrOrderApp.DAL.Providers.EntityFramework.Repositories.Adapters
{
    internal static class SupplierAdapter
    {
        internal static BL.DomainModel.Supplier AdaptSupplier(EntityReference<Supplier> c)
        {
            if (c == null || c.Value == null)
                return null;
            return AdaptSupplier(c.Value, null);
        }
        internal static BL.DomainModel.Supplier AdaptSupplier(Supplier o)
        {
            return AdaptSupplier(o, null);
        }

        internal static BL.DomainModel.Supplier AdaptSupplier(Supplier c, BL.DomainModel.User user)
        {
            BL.DomainModel.Supplier supplier = new BL.DomainModel.Supplier()
            {
                AccountNumber = c.AccountNumber,
                CreditRating = c.CreditRating,
                PreferredSupplierFlag = c.PreferredSupplierFlag,
                ActiveFlag = c.ActiveFlag,
                PurchasingWebServiceURL = c.PurchasingWebServiceURL,
                Version = c.Version.ToUlong(),
            };
            //customer.Orders = OrderAdapter.AdaptOrders(c.Orders, customer);
            //customer.Addresses = AddressAdapter.AdaptAddresses(c.Addresses);
            return supplier;
        }
    }
}
