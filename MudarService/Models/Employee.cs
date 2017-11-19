using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudarService.Models
{
    [Table("tblEmployeeDetails")]
    public class Employee : MudarBaseEntity
    {
        [Key, ForeignKey("UserLoginInfo")]
        public Guid EmployeeId { get; set; }

        [Column(TypeName = "nvarchar")]
        public string EmployeeFirstName { get; set; }
        [Column(TypeName = "nvarchar")]
        public string EmployeeLastName { get; set; }

        [ForeignKey("BranchInfo")]
        [Column(TypeName = "uniqueidentifier")]
        public Guid BranchId { get; set; }

        [Column(TypeName = "nvarchar")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar")]
        public string Taluk { get; set; }

        [Column(TypeName = "nvarchar")]
        public string City { get; set; }

        [Column(TypeName = "nvarchar")]
        public string District { get; set; }

        [Column(TypeName = "nvarchar")]
        public string State { get; set; }

        [Column(TypeName = "nvarchar")]
        public string Country { get; set; }

        [Column(TypeName = "nvarchar")]
        public string Phone { get; set; }

        [Column(TypeName = "nvarchar")]
        public string Mphone { get; set; }

        public Branch BranchInfo { get; set; }
        public UserLogin UserLoginInfo
        { get; set; }
        
    }
}