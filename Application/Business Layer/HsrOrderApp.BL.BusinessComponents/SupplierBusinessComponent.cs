using System.Collections.Generic;
using System.Linq;
using HsrOrderApp.BL.DomainModel;
using HsrOrderApp.DAL.Repositories;
using HsrOrderApp.SharedLibraries.SharedEnums;

namespace HsrOrderApp.BL.BusinessComponents
{
    public class SupplierBusinessComponent
    {
        private ISupplierRepository _repository;

        public SupplierBusinessComponent(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public ISupplierRepository SupplierRepository { get; set; }



        public Supplier GetSupplierById(int supplierId)
        {
            Supplier supplier = _repository.GetById(supplierId);
            return supplier;
        }

        public IQueryable<Supplier> GetSuppliersByCriteria(SupplierSearchType searchType, string supplierName)
        {
            IQueryable<Supplier> suppliers = new List<Supplier>().AsQueryable();
            switch (searchType)
            {
                case SupplierSearchType.None:
                    suppliers = _repository.GetAll();
                    break;
                case SupplierSearchType.ByName:
                    suppliers= _repository.GetAll().Where(su=>su.SupplierName==supplierName);
                    break;
            }
            return suppliers;
        }

        public int StoreSupplier(Supplier supplier)
        {
           return  _repository.SaveSupplier(supplier);
        }

        public void DeleteSupplier(int supplierId)
        {
            _repository.DeleteSupplier(supplierId);
        }
    }
}