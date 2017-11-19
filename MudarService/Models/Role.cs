using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudarService.Models
{
    [Table("tblRoles")]
    public class Role : MudarBaseEntity
    {
        [Key, Column(TypeName = "UniqueIdentifier")]
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDisplayName { get; set; }
        public int? BranchRoleValue { get; set; }
    }

}