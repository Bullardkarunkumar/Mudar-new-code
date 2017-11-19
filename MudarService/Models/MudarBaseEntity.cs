using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudarService.Models
{
    public class MudarBaseEntity
    {
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [Column("Delete")]
        public bool IsDeleted { get; set; }
    }

    //0 - ICS, 1- Branch, 2- ICS Supplier
    public enum BranchType
    {
        ICS,
        Branch,
        ICSSupplier
    }
}