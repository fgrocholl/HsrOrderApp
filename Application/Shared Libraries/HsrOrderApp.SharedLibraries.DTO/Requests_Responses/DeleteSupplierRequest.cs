using HsrOrderApp.SharedLibraries.DTO.Requests_Responses.Base;

namespace HsrOrderApp.SharedLibraries.DTO.Requests_Responses
{
    public class DeleteSupplierRequest:RequestType
    {
        public int Id { get; set; }
    }
}