using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MudarService.Models
{
    [Table("tblSeasonProducts")]
    public class SeasonProductDetail
    {
        [Column(Order = 0), Key, ForeignKey("Season")]
        public int SeasonId { get; set; }
        public Season Season { get; set; }

        [Column(Order = 1), Key, ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}