using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MudarService.Models
{
    [Table("tblSeason")]
    public class Season : MudarBaseEntity
    {
            [Key]
            public int SeasonId { get; set; }
            [Required]
            [StringLength(30)]
            public string SeasonName { get; set; }
            public int SeasonYear { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public ICollection<Product> Products { get; set; }
    }
}