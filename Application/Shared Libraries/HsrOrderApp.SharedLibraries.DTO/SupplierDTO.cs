using HsrOrderApp.SharedLibraries.DTO.Base;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace HsrOrderApp.SharedLibraries.DTO
{
    public class SupplierDTO : DTOParentObject
    {
        private string _accountNumber;
        private int _creditRating;
        private string _purchasingWebServiceURL;
        private string _supplierName;
        //private IList<ConditionDTO> _conditions;
        
        [DataMember]
        [NotNullValidator]
        [StringLengthValidator(1, 50)]
        public string AccountNumber
        {
            get { return _accountNumber; }
            set
            {
                if (value != _accountNumber)
                {
                    this._accountNumber = value;
                    OnPropertyChanged(() => AccountNumber);
                }
            }
        }

        [DataMember]
        [NotNullValidator]
        [RangeValidator(1, RangeBoundaryType.Inclusive, 5, RangeBoundaryType.Ignore)]
        public int CreditRating
        {
            get { return _creditRating; }
            set
            {
                if (value != _creditRating)
                {
                    this._creditRating = value;
                    OnPropertyChanged(() => CreditRating);
                }
            }
        }

        [DataMember]
        public bool PreferredSupplierFlag { get; set; }

        [DataMember]
        public bool ActiveFlag { get; set; }

        [DataMember]
        [NotNullValidator]
        [StringLengthValidator(1, 255)]
        public string PurchasingWebServiceURL
        {
            get { return _purchasingWebServiceURL; }
            set
            {
                if (value != _purchasingWebServiceURL)
                {
                    this._purchasingWebServiceURL = value;
                    OnPropertyChanged(() => PurchasingWebServiceURL);
                }
            }
        }

        [DataMember]
        [NotNullValidator]
        [StringLengthValidator(1, 255)]
        public string SupplierName
        {
            get { return _supplierName; }
            set
            {
                if (value != _supplierName)
                {
                    this._supplierName = value;
                    OnPropertyChanged(() => SupplierName);
                }
            }
        }

        //[DataMember]
        //[ObjectCollectionValidator(typeof(ConditionDTO))]
        //public IList<AddressDTO> SupplierConditions
        //{
        //    get { return _conditions; }
        //    set
        //    {
        //        if (value != _conditions)
        //        {
        //            this._conditions = value;
        //            OnPropertyChanged(() => Addresses);
        //        }
        //    }
        //}
    }
}
