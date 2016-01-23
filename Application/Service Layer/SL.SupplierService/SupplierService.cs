using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using HsrOrderApp.BL.BusinessComponents;
using HsrOrderApp.BL.BusinessComponents.DependencyInjection;
using HsrOrderApp.BL.DomainModel;
using HsrOrderApp.BL.DtoAdapters;
using HsrOrderApp.SharedLibraries.DTO.Requests_Responses;
using HsrOrderApp.SharedLibraries.ServiceInterfaces;
using ChangeItem = HsrOrderApp.SharedLibraries.DTO.ChangeSet.ChangeItem;

namespace SL.SupplierService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]

    public class SupplierService:ISupplierService
    {
        public SupplierService()
        {
            Thread.CurrentPrincipal = HttpContext.Current.User;
        }
        public GetSupplierResponse GetSupplierById(GetSupplierRequest request)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                throw new FaultException<NotAuthenticatedFault>(new NotAuthenticatedFault());
            GetSupplierResponse response = new GetSupplierResponse();
            SupplierBusinessComponent bc = DependencyInjectionHelper.GetSupplierBusinessComponent();
            Supplier supplier = bc.GetSupplierById(request.Id);
            response.Supplier = SupplierAdapter.SupplierToDto(supplier);

            return response;
        }

       

        public GetSuppliersResponse GetSupplierBySearchCriteria(GetSuppliersRequest request)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                throw new FaultException<NotAuthenticatedFault>(new NotAuthenticatedFault());
            GetSuppliersResponse response = new GetSuppliersResponse();
            SupplierBusinessComponent bc = DependencyInjectionHelper.GetSupplierBusinessComponent();

            IQueryable<Supplier> suppliers = bc.GetSuppliersByCriteria(request.SearchType, request.SupplierName);
            response.Suppliers =SupplierAdapter.SuppliersToDtos(suppliers);

            return response;
        }

        public StoreSupplierResponse SaveSupplier(StoreSupplierRequest request)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                throw new FaultException<NotAuthenticatedFault>(new NotAuthenticatedFault());
            StoreSupplierResponse response = new StoreSupplierResponse();
            SupplierBusinessComponent bc = DependencyInjectionHelper.GetSupplierBusinessComponent();
            Supplier supplier = SupplierAdapter.DtoToSupplier(request.Supplier);
           // IEnumerable<ChangeItem> changeItems = SupplierAdapter.GetChangeItems(request.Supplier, supplier);
            response.SupplierId = bc.StoreSupplier(supplier);

            return response;
        }

        public DeleteSupplierResponse DeleteSupplier(DeleteSupplierRequest request)
        {
            DeleteSupplierResponse response = new DeleteSupplierResponse();
            SupplierBusinessComponent bc = DependencyInjectionHelper.GetSupplierBusinessComponent();

            bc.DeleteSupplier(request.Id);

            return response;

        }
    }

}
