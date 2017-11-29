using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MudarService.Models
{
    [Table("tblBuyerTransportDetails")]
    public class BuyerTransportDetails : MudarBaseEntity
    {
        [Key]
        public int BuyerTransportId { get; set; }
        [ForeignKey("Buyer")]
        public Guid BuyerId { get; set; }
        public BuyerDetail Buyer { get; set; }
        public int? ModeofTransport { get; set; }
        public string SeaportName{get;set;}
        public string AirportName { get; set; }
        public string RoadDestination { get; set; }
        public string RailStation { get; set; }
    }
}