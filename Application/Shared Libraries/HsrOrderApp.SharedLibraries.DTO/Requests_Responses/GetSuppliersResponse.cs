using System.Collections.Generic;

namespace HsrOrderApp.SharedLibraries.DTO.Requests_Responses
{
    public class GetSuppliersResponse
    {
        public IList<SupplierDTO> Suppliers { get; set; }
    }
}