using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using HsrOrderApp.SharedLibraries.DTO.Faults;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.WCF;
using Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF;
using HsrOrderApp.SharedLibraries.DTO.Requests_Responses;

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
        [FaultContract(typeof(ServiceFault))]
        [FaultContract(typeof(ValidationFault))]

        GetSupplierResponse GetSupplierById(GetSupplierRequest request);
    }
}
