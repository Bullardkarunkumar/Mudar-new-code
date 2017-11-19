using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudarService.Models
{
    [Table("tblBranchDetails")]
    public class Branch : MudarBaseEntity
    {
        [Key]
        public Guid BranchId { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(20)]
        public string BranchCode { get; set; }

        [Column("Bname", TypeName = "nvarchar")]
        [StringLength(40)]
        public string BranchName { get; set; }

        public BranchType BranchType { get; set; } 

        //Sales	bit
        //Export	bit
        //WareHousing	bit
        //Other	bit
        [Column(TypeName = "nvarchar")]
        [StringLength(200)]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(40)]
        public string City { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(40)]
        public string Taluk { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(40)]
        public string District { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(40)]
        public string State { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(40)]
        public string Country { get; set; }

        public Guid BranchHeadCode { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(40)]
        public string Designation { get; set; }

        public bool Default { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        public string Tin { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        public string ContactPerson { get; set; }

        [Column("Phone_Fax", TypeName = "nvarchar")]
        [StringLength(100)]
        public string PhoneFax { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        public string Mobile { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        public string Website { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        public string BankName { get; set; }

        [Column("BankAcct_no", TypeName = "nvarchar")]
        [StringLength(100)]
        public string BankAccountNumber { get; set; }

        [Column("Bank_ADC_Code", TypeName = "nvarchar")]
        [StringLength(100)]
        public string BankADCCode { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        public string IECode { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        public string FDA { get; set; }

        [Column("AP_VAT", TypeName = "nvarchar")]
        [StringLength(100)]
        public string APVAT { get; set; }

        [Column("Organic_Premium")]
        public int OrganicPremium { get; set; }
              
    }
}