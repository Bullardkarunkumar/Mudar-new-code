using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudarService.Models
{
    [Table("tblProductDetails")]
    public class Product : MudarBaseEntity
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductCode { get; set; }
        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }
        [StringLength(200)]
        public string Description { get; set; }

        [StringLength(20)]
        public string ItcHsCode { get; set; }

        public int CropSeason { get; set; }
        public string Specification { get; set; }
        public string ProductType { get; set; }

        [ForeignKey("ProductCategory")]
        public int CategoryId { get; set; }

        public Category ProductCategory { get; set; }
    }
}