using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudarService.Models
{
    [Table("tblCategory")]
    public class Category : MudarBaseEntity
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(30)]
        public string CategoryName { get; set; }

        [StringLength(60)]
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}