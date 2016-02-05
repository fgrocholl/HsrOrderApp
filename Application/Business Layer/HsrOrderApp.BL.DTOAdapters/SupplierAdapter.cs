using System.Collections.Generic;
using System.Linq;
using HsrOrderApp.BL.DomainModel;
using HsrOrderApp.SharedLibraries.DTO;

namespace HsrOrderApp.BL.DtoAdapters
{
    public class SupplierAdapter
    {
        public static SupplierDTO SupplierToDto(Supplier s)
        {
            SupplierDTO dto = new SupplierDTO
            {
                Id = s.SupplierId,
                AccountNumber = s.AccountNumber,
                ActiveFlag = s.ActiveFlag,
                CreditRating = s.CreditRating,
                PurchasingWebServiceURL = s.PurchasingWebServiceURL,
                PreferredSupplierFlag = s.PreferredSupplierFlag,
                SupplierName = s.SupplierName
            };
            return dto;
        }



        public static Supplier DtoToSupplier(SupplierDTO dto)
        {
            Supplier supplier = new Supplier
            {
                SupplierId = dto.Id,
                AccountNumber = dto.AccountNumber,
                ActiveFlag = dto.ActiveFlag,
                CreditRating = dto.CreditRating,
                PreferredSupplierFlag = dto.PreferredSupplierFlag,
                PurchasingWebServiceURL = dto.PurchasingWebServiceURL,
                SupplierName = dto.SupplierName
            };
            return supplier;
        }

        public static IList<SupplierDTO> SuppliersToDtos(IQueryable<Supplier> suppliers)
        {
            IQueryable<SupplierDTO> supplierDtos = from p in suppliers
                                                   select SupplierToDto(p);
            return supplierDtos.ToList(); ;
        }
    }
}