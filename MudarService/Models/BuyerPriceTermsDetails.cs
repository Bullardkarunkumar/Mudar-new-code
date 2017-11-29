using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MudarService.Models
{
    [Table("tblBuyerPriceTermsDetails")]
    public class BuyerPriceTermDetails
    {
        [Key]
        public int BuyerPriceID { get; set; }
        [ForeignKey("Buyer")]
        public Guid BuyerId { get; set; }
        public BuyerDetail Buyer { get; set; }

        [Column("CIF_Seaport")]
        public bool CIF_Seaport { set; get; }
        [Column("FOB_India")]
        public bool FOB_India { set; get; }
        [Column("CIF_Sea_By")]
        public bool CIF_Sea_By { set; get; }
        [Column("CIF_Air_By_EuropeandEastUSA")]
        public bool CIF_Air_By_EuropeandEastUSA { set; get; }
        [Column("CIF_AIR_By_WEST_USA")]
        public bool CIF_AIR_By_WEST_USA { set; get; }
        [Column("100%advance")]
        public bool bpt_100_advance { set; get; }
        [Column("50%adv+50%againstDocs")]
        public string bpt_50_adv_50_againstDocs { set; get; }
        [Column("100%againstDocs")]
        public bool bpt_100_againstDocs { set; get; }
        [Column("No_of_Days_Count_fromInvoice")]
        public bool No_of_Days_Count_fromInvoice { set; get; }
        [Column("NoofDaysfromInvoice")]
        public bool NoofDaysfromInvoice { set; get; }
        public string CreatedBy { set; get; }
        public DateTime? CreatedDate { set; get; }
        public string ModifiedBy { set; get; }
        public DateTime? ModifiedDate { set; get; }
        public string Delete { set; get; }        
    }
}