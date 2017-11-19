using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudarService.Models
{
    [Table("tblBuyerDetails")]
    public class BuyerDetail : MudarBaseEntity
    {
        [Key, ForeignKey("UserLoginInfo")]
        public Guid BuyerId { get; set; }

        //Step 1 Begin
        public string BuyerCompanyName { get; set; }
        public string BuyerFirstName { get; set; }
        public string BuyerLastName { get; set; }
        public string CAddressLine1 { get; set; }
        public string CAddressLine2 { get; set; }
        public string CCity { get; set; }
        public string CState { get; set; }
        public string CPincode { get; set; }
        public string CCountry { get; set; }
        public string TINNumber { get; set; }
        public string VAT { get; set; }
        public string CST { get; set; }
        public string GST { get; set; }

        // Step 1 End

        public string Phone { get; set; }
        public string Mphone { get; set; }

        //Step 2 Begin
        public string CContactPerson { get; set; }
        public string CContactPhoneNo { get; set; }
        public string MobileforTextingpurpose { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

        //Step 2 End

        //Step 3 
        public ICollection<Product> Products { get; set; }

        //Step 4 Begin
        public string NotifyName { get; set; }
        //public string NContactPerson { get; set; }
        public string NAddressLine1 { get; set; }
        public string NAddressLine2 { get; set; }
        public string NCity { get; set; }
        public string NState { get; set; }
        public string NContactPhoneNo { get; set; }
        public string NPincode { get; set; }
        public string NCountry { get; set; }

        //Step 4 End

        //Step 5 Begin

        public int? BankOrConsignee { get; set; }
        public string BankName { get; set; }
        public string BankAddressLine1 { get; set; }
        public string BankAddressLine2 { get; set; }
        public string BankCity { get; set; }
        public string BankState { get; set; }
        public string BankPincode { get; set; }
        public string BankCountry { get; set; }

        //public string BankContactPerson { get; set; }
        //public string BankContactPhoneNo { get; set; }

        //Step 5 End

        //Step 6 Begin

        //Step 6 End

        public string BuyerCode { get; set; }
        public decimal Discount { get; set; }
        public bool Apporval { get; set; }
        public decimal FairTrade { get; set; }
        public decimal FairTradPremium { get; set; }
        public bool Lotsample { get; set; }
        public UserLogin UserLoginInfo
        { get; set; }
    }
}