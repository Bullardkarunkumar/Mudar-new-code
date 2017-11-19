using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudarService.Models
{
    [Table("tblUsersInRoles")]
    public class UsersInRole : MudarBaseEntity
    {

        [Key, ForeignKey("UserRole")]
        [Required]
        [Column(Order = 1, TypeName = "UniqueIdentifier")]
        public Guid RoleId { get; set; }

        public Role UserRole
        { get; set; }

        [Key, ForeignKey("UserLoginDetail")]
        [Required]
        [Column(Order = 2, TypeName = "UniqueIdentifier")]
        public Guid UserId { get; set; }
        public UserLogin UserLoginDetail
        { get; set; }

        
    }
}