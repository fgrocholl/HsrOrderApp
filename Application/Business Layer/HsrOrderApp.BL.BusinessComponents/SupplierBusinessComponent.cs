using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using HsrOrderApp.BL.DomainModel;
using HsrOrderApp.DAL.Data.Repositories;
using HsrOrderApp.SharedLibraries.SharedEnums;

namespace HsrOrderApp.BL.BusinessComponents
{
    public class SupplierBusinessComponent
    {
        private ISupplierRepository rep;

        public SupplierBusinessComponent()
        {
        }

        public SupplierBusinessComponent(ISupplierRepository unitOfWork)
        {
            this.rep = unitOfWork;
        }

        #region CRUD Operations

        public Supplier GetSupplierById(int supplierId)
        {
            Supplier supplier = rep.GetById(supplierId);
            return supplier;
        }


        public IQueryable<Supplier> GetSuppliersByCriteria(SupplierSearchType searchType, string supplierName)
        {
            IQueryable<Supplier> suppliers = null;

            switch (searchType)
            {
                case SupplierSearchType.None:
                    suppliers = rep.GetAll();
                    break;
                case SupplierSearchType.ByName:
                    suppliers = rep.GetAll().Where(cu => cu.SupplierName == supplierName);
                    break;
            }

            return suppliers;
        }

        public int StoreSupplier(Supplier supplier)
        {
            int supplierId;
            using (TransactionScope transaction = new TransactionScope())
            {
                supplierId = rep.SaveSupplier(supplier);
                transaction.Complete();
            }

            return supplierId;
        }

        public void DeleteSupplier(int supplierId)
        {
            rep.DeleteSupplier(supplierId);
        }

        #endregion

        public ISupplierRepository Repository
        {
            get { return this.rep; }
            set { this.rep = value; }
        }

        public List<SupplierToProduct> GetAllSupplierToProduct()
        {
            // Not as queriable due to problems with Linq2SQL implementation
            return rep.GetAllSupplierToProduct().ToList();
        }

        public void GetEstimatedSupplierDeliveryTime(int supplierId, out int unitsAvailable, out int estimatedDeliveryTimeInDays)
        {
            unitsAvailable = 1;
            estimatedDeliveryTimeInDays = 1;
            //OrderBusinessComponent orderBC = DependencyInjectionHelper.GetOrderBusinessComponent();
            //Supplier supplier = rep.GetById(supplierId);

            //int unitsOrdered = orderBC.GetAllOrderDetails()
            //    .Where(od => od.Product.ProductId == supplier.ProductId)
            //    .Sum(od => od.QuantityInUnits);

            //unitsAvailable = supplier.UnitsOnStock - unitsOrdered;
            //if ((unitsAvailable) < 0) 
            //    unitsAvailable = 0;

            //estimatedDeliveryTimeInDays = -1;
            // Todo: Implement the logic to calculate the estimatedDelivertyTimeInDays (see SupplierCondition)
        }
    }
}