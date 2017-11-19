using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudarService.Models
{
    [Table("tblUserLogin")]
    public class UserLogin : MudarBaseEntity
    {

        public UserLogin()
        {
            //UserRole = new List<UsersInRole>();
            //BuyerInfo = new BuyerDetail();
            //SupplierInfo = new SupplierDetail();
        }
        [Key]
        public Guid UserId { get; set; }

        [Index(IsUnique = true)]
        [Required]
        [Column(TypeName = "nvarchar")]
        public string UserLoginId { get; set; }

        [Required]
        public string UserPassword { get; set; }

        public List<UsersInRole> UserRoles{get;set;}
        public BuyerDetail BuyerInfo { get; set; }
        public SupplierDetail SupplierInfo { get; set; }
        public Employee EmployeeInfo { get; set; }
    }
}