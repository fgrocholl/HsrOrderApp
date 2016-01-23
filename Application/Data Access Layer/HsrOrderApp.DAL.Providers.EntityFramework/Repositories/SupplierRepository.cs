using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HsrOrderApp.BL.DomainModel.SpecialCases;
using HsrOrderApp.DAL.Data.Repositories;
using HsrOrderApp.DAL.Providers.EntityFramework.Repositories.Adapters;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using HsrOrderApp.DAL.Repositories;
using HsrOrderApp.BL.DomainModel;

namespace HsrOrderApp.DAL.Providers.EntityFramework.Repositories
{
    public class SupplierRepository : RepositoryBase, ISupplierRepository
    {
        public SupplierRepository(HsrOrderAppEntities db)
            : base(db)
        {
        }

        public SupplierRepository(string connectionString) : base(connectionString)
        {
        }

        public SupplierRepository() : base()
        {
        }

        public IQueryable<BL.DomainModel.Supplier> GetAll()
        {
            var suppliers = from o in this.db.Suppliers.Include("Supplier").AsEnumerable()
                         select SupplierAdapter.AdaptSupplier(o);

            return suppliers.AsQueryable();
        }

        public BL.DomainModel.Supplier GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int SaveSupplier(BL.DomainModel.Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public void DeleteSupplier(int id)
        {
            throw new NotImplementedException();
        }
    }
}
