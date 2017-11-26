using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MudarService.Models
{
    [Table("tblBuyerProductDetails")]
    public class BuyerProductDetail : MudarBaseEntity
    {
        [Key]        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BuyerProductId { get; set; }

        [ForeignKey("Buyer")]
        public Guid BuyerId { get; set; }

        public BuyerDetail Buyer { get; set; }

        [ForeignKey("BuyerProduct")]
        public int? ProductId { get; set; }

        public Product BuyerProduct { get; set; }
    }
}