using System.Linq;
using System.ServiceModel;
using HsrOrderApp.BL.DomainModel;
using HsrOrderApp.SharedLibraries.DTO.Faults;
using HsrOrderApp.SharedLibraries.DTO.Requests_Responses;
using Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF;

namespace HsrOrderApp.SharedLibraries.ServiceInterfaces
{
    //[DataContract(Namespace = "http://ins.hsr.ch/")]
    //public class NotAuthenticatedFault
    //{
    //    [DataMember]
    //    public String Message { get; set; }
    //}

    [ServiceContract(Namespace = "http://ch.hsr.HsrOrderApp")]
    [ValidationBehavior]
    public interface ISupplierService
    {
        [OperationContract]
        [FaultContract(typeof (ServiceFault))]
        [FaultContract(typeof (ValidationFault))]
        GetSupplierResponse GetSupplierById(GetSupplierRequest request);

        GetSuppliersResponse GetSupplierBySearchCriteria(GetSuppliersRequest request);

        StoreSupplierResponse SaveSupplier(StoreSupplierRequest request);

        DeleteSupplierResponse DeleteSupplier(DeleteSupplierRequest request);
    }
}