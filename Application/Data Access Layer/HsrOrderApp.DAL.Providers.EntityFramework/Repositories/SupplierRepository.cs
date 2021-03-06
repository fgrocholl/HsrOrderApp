﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HsrOrderApp.BL.DomainModel.SpecialCases;
using HsrOrderApp.DAL.Data.Repositories;
using HsrOrderApp.DAL.Providers.EntityFramework.Repositories.Adapters;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

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
            // Include("Supplier").
            var suppliers = from o in this.db.Suppliers.AsEnumerable()
                         select SupplierAdapter.AdaptSupplier(o);

            return suppliers.AsQueryable();
        }

        public BL.DomainModel.Supplier GetById(int id)
        {
            try
            {
                var suppliers = from s in this.db.Suppliers.AsEnumerable()
                                where s.SupplierId == id
                                select SupplierAdapter.AdaptSupplier(s);

                return suppliers.First();
            }
            catch (ArgumentNullException ex)
            {
                if (ExceptionPolicy.HandleException(ex, "DA Policy: Supplier")) throw;
                return new MissingSupplier();
            }
        }

        public int SaveSupplier(BL.DomainModel.Supplier supplier)
        {
            try
            {
                string setname = "Suppliers";
                Supplier dbSupplier;

                bool isNew = false;
                if (supplier.SupplierId == default(int) || supplier.SupplierId <= 0)
                {
                    isNew = true;
                    dbSupplier = new Supplier();
                }
                else
                {
                    dbSupplier = new Supplier() { SupplierId = supplier.SupplierId, Version = supplier.Version.ToTimestamp() };
                    dbSupplier.EntityKey = db.CreateEntityKey(setname, dbSupplier);
                    db.AttachTo(setname, dbSupplier);
                }

                dbSupplier.AccountNumber = supplier.AccountNumber;
                dbSupplier.ActiveFlag = supplier.ActiveFlag;
                dbSupplier.CreditRating = Convert.ToInt16(supplier.CreditRating);
                dbSupplier.PreferredSupplierFlag = supplier.PreferredSupplierFlag;
                dbSupplier.ActiveFlag = supplier.ActiveFlag;
                dbSupplier.PurchasingWebServiceURL = supplier.PurchasingWebServiceURL;
                dbSupplier.SupplierName = supplier.SupplierName;
                if (isNew)
                {
                    db.AddToSuppliers(dbSupplier);
                }
                db.SaveChanges();

                supplier.SupplierId = dbSupplier.SupplierId;
                return dbSupplier.SupplierId;
            }
            catch (OptimisticConcurrencyException ex)
            {
                if (ExceptionPolicy.HandleException(ex, "DA Policy: Supplier")) throw;
                return default(int);
            }
        }

        public void DeleteSupplier(int id)
        {
            Supplier su = db.Suppliers.First(s => s.SupplierId == id);
            if (su != null)
            {
                db.DeleteObject(su);
                db.SaveChanges();
            }
        }

        public IQueryable<BL.DomainModel.SupplierToProduct> GetAllSupplierToProduct()
        {
            var supplierToProducts = from od in this.db.SupplierToProducts.Include("Product").Include("Supplier").AsEnumerable()
                               select SupplierAdapter.AdaptSupplierToProduct(od);

            return supplierToProducts.AsQueryable();
        }

        public int SaveSupplierToProduct(BL.DomainModel.SupplierToProduct detail, BL.DomainModel.Supplier forThisSupplier)
        {
            throw new NotImplementedException();
        }

        public void DeleteSupplierToProduct(int id)
        {
            SupplierToProduct cu = db.SupplierToProducts.FirstOrDefault(c => c.SupplierToProductId == id);
            if (cu != null)
            {
                db.DeleteObject(cu);
                db.SaveChanges();
            }
        }
    }
}
