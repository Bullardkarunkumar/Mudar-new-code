using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudarService.Models
{
    [Table("tblSupplierDetails")]
    public class SupplierDetail : MudarBaseEntity
    {
        [Key,ForeignKey("UserLoginInfo")]
        public Guid SupplierId { get; set; }
        public string SupplierCompanyName { get; set; }
        public string SupplierFirstName { get; set; }
        public string SupplierLastName { get; set; }
        public string CAddress { get; set; }
        public string CCity { get; set; }
        public string CState { get; set; }
        public string CCountry { get; set; }
        public string Phone { get; set; }
        public string Mphone { get; set; }
        public string TINNumber { get; set; }
        public string CContactPerson { get; set; }
        public string CContactPhoneNo { get; set; }
        public string CPincode { get; set; }
        public string BankName { get; set; }
        public string BankAddress { get; set; }
        public string BankCity { get; set; }
        public string BankCountry { get; set; }
        public string BankContactPerson { get; set; }
        public string BankContactPhoneNo { get; set; }
        public string BankPincode { get; set; }
        public string BankState { get; set; }
        public string MobileforTextingpurpose { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string VAT { get; set; }
        public string CST { get; set; }
        public string SupplierType { get; set; }

        public UserLogin UserLoginInfo
        { get; set; }
    }
}