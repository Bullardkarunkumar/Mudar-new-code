using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MudarService.Models
{
    [Table("tblBuyerPriceTermsDetails")]
    public class BuyerPriceTermsDetails
    {
        [Key]
        public int BuyerPriceID { get; set; }


        public bool CIF_Seaport {
           get { return false; }
        set { value == 0 ? false : true; }
        }
        public string FOB_India { set; get; }
        public string CIF_Sea_By { set; get; }
        public string CIF_Air_By_EuropeandEastUSA { set; get; }
        public string CIF_AIR_By_WEST_USA { set; get; }
        [Column("100%advance")]
        public string bpt_100_advance { set; get; }
        [Column("50%adv+50%againstDocs")]
        public string bpt_50_adv_50_againstDocs { set; get; }
        [Column("100%againstDocs")]
        public string bpt_100_againstDocs { set; get; }
        public string No_of_Days_Count_fromInvoice { set; get; }
        public string NoofDaysfromInvoice { set; get; }
        public string CreatedBy { set; get; }
        public string CreatedDate { set; get; }
        public string ModifiedBy { set; get; }
        public string ModifiedDate { set; get; }
        public string Delete { set; get; }

        [ForeignKey("ProductCategory")]
        public Guid BuyerId { get; set; }

        public Category ProductCategory { get; set; }

        public ICollection<BuyerDetail> BuyerDetail { get; set; }
    }
}