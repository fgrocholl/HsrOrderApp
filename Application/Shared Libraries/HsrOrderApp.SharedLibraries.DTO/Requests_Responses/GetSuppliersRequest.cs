using HsrOrderApp.SharedLibraries.SharedEnums;

namespace HsrOrderApp.SharedLibraries.DTO.Requests_Responses
{
    public class GetSuppliersRequest
    {
        public SupplierSearchType SearchType { get; set; }
        public string SupplierName { get; set; }
    }
}