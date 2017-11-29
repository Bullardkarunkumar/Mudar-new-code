using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MudarDB.Models;
using MudarService.Models;
using MudarService.Common;
using System.Linq;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace MudarService.Controllers
{
    [RoutePrefix("api")]
    public class BuyerController : ApiController
    {
        private MudarDBContext db = new MudarDBContext();
        private string createdBy = "superadmin";
        private DateTime createdDate = DateTime.Now;
        // GET: api/Buyer
        [Route("buyers")]
        public IHttpActionResult GetBuyers()
        {
            return Ok(db.Buyers.ToList());
        }

        // GET: api/Buyer/5
        [ResponseType(typeof(BuyerDetail))]
        [Route("buyer/{id}")]
        public IHttpActionResult GetBuyerDetail(Guid id)
        {
            BuyerDetail buyerDetail = db.Buyers.Find(id);
            if (buyerDetail == null)
            {
                return NotFound();
            }

            return Ok(buyerDetail);
        }

        // PUT: api/Buyer/5
        [ResponseType(typeof(void))]
        [Route("buyer/update/{id}")]
        public IHttpActionResult PostBuyerDetail(Guid id, BuyerDetail buyerDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != buyerDetail.BuyerId)
            {
                return BadRequest();
            }

            db.Entry(buyerDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyerDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Buyer
        [ResponseType(typeof(BuyerDetail))]
        [Route("buyer")]
        public IHttpActionResult PostBuyerDetail(BuyerDetail buyerDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    buyerDetail.BuyerId = Guid.NewGuid();
                    var userlogin = new UserLogin()
                    {
                        UserId = buyerDetail.BuyerId,
                        UserLoginId = MudarCommon.GenerateULogin(buyerDetail.BuyerCompanyName),
                        UserPassword = MudarCommon.GeneratePassword(buyerDetail.BuyerCompanyName),
                        CreatedBy = createdBy,
                        CreatedDate = createdDate
                    };

                    db.UserLogins.Add(userlogin);

                    buyerDetail.CreatedBy = createdBy;
                    buyerDetail.CreatedDate = createdDate;

                    db.Buyers.Add(buyerDetail);

                    db.SaveChanges();

                    transaction.Commit();
                }
                catch (DbUpdateException)
                {
                    transaction.Rollback();
                    if (BuyerDetailExists(buyerDetail.BuyerId))
                    {
                        return Conflict();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return BadRequest();
                }
            }

            return Ok(buyerDetail.BuyerId);
        }

        // DELETE: api/Buyer/5
        [ResponseType(typeof(BuyerDetail))]
        public IHttpActionResult DeleteBuyerDetail(Guid id)
        {
            BuyerDetail buyerDetail = db.Buyers.Find(id);
            if (buyerDetail == null)
            {
                return NotFound();
            }

            db.Buyers.Remove(buyerDetail);
            db.SaveChanges();

            return Ok(buyerDetail);
        }

        [Route("buyerProducts/{id}")]
        [HttpGet]
        public IHttpActionResult BuyerProducts(string id)
        {
            var result = (from prod in db.Products
                          join bp in db.BuyerProducts.Include(p => p.BuyerProduct) on prod.ProductId equals bp.ProductId into pbp
                          from oj in pbp.DefaultIfEmpty()
                          select new
                          {
                              ProductId = prod.ProductId,
                              ProductName = prod.ProductName,
                              ProductType = prod.ProductType,
                              ProductCode = prod.ProductCode,
                              CategoryId = prod.CategoryId,
                              CropSeason = prod.CropSeason,
                              Description = prod.Description,
                              BuyerId = oj == null ? Guid.Empty : oj.BuyerId,
                              BuyerProductId = oj == null ? 0 : oj.BuyerProductId,
                              IsBuyerProduct = oj == null ? false : true
                          }).ToList();
            //select new
            //{
            //    ProductId = prod.ProductId,
            //    ProductName = prod.ProductName,
            //    ProductType = prod.ProductType,
            //    ProductCode = prod.ProductCode,
            //    CategoryId = prod.CategoryId,
            //    CropSeason = prod.CropSeason,
            //    Description = prod.Description,
            //    BuyerProductId = oj.ProductId
            //}

            return Ok(result);
        }

        [Route("buyerProducts")]
        [HttpPost]
        public IHttpActionResult PostBuyerProducts(List<BuyerProductDetail> buyerProducts)
        {
            try
            {
                XElement xml = new XElement("BuyerProducts",
                            buyerProducts.Select(i =>
                                new XElement("BuyerProduct",
                                    new XAttribute("BuyerProductId", i.BuyerProductId),
                                    new XAttribute("BuyerId", i.BuyerId),
                                    new XAttribute("ProductId", i.ProductId),
                                    new XAttribute("Delete", i.IsDeleted ? 1 : 0)
                                    ))
                                );

                SqlParameter resultParam = new SqlParameter();
                resultParam.ParameterName = "@Result";
                resultParam.SqlDbType = SqlDbType.Int;
                resultParam.Direction = ParameterDirection.Output;
                db.Database.ExecuteSqlCommand("AddUpdateBuyerProducts @BuyerProducts, @Result OUT", new SqlParameter("@BuyerProducts", xml.ToString()), resultParam);

                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        [Route("buyerTransport")]
        [HttpPost]
        public IHttpActionResult PostBuyerTransportDetail(BuyerTransportDetails buyerTransportDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
               if (buyerTransportDetails.BuyerTransportId != 0)
                {
                    buyerTransportDetails.ModifiedBy = "superadmin";
                    buyerTransportDetails.ModifiedDate = DateTime.Now;
                    db.BuyerTransport.Attach(buyerTransportDetails);
                    db.Entry(buyerTransportDetails).State = EntityState.Modified;
                }
                else
                {
                    db.BuyerTransport.Add(buyerTransportDetails);
                }
                db.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        [ResponseType(typeof(BuyerTransportDetails))]
        [Route("buyerTransport/{id}")]
        public IHttpActionResult GetBuyerTransportDetail(Guid id)
        {
            BuyerTransportDetails buyerTransportDetail = db.BuyerTransport.FirstOrDefault(x => x.BuyerId == id);
            if (buyerTransportDetail == null)
            {
                return NotFound();
            }

            return Ok(buyerTransportDetail);
        }

        [Route("buyerPriceTerm")]
        [HttpPost]
        public IHttpActionResult PostBuyerPriceTerm(BuyerPriceTermDetails buyerPriceTerm)
        {
             if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (buyerPriceTerm.BuyerPriceID != 0)
                {
                    buyerPriceTerm.ModifiedBy = "superadmin";
                    buyerPriceTerm.ModifiedDate = DateTime.Now;
                    db.BuyerPriceTerm.Attach(buyerPriceTerm);
                    db.Entry(buyerPriceTerm).State = EntityState.Modified;
                }
                else
                {
                    db.BuyerPriceTerm.Add(buyerPriceTerm);
                }
                db.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        [ResponseType(typeof(BuyerPriceTermDetails))]
        [Route("buyerPriceTerm/{id}")]
        public IHttpActionResult GetBuyerPriceTerm(Guid id)
        {
            BuyerPriceTermDetails buyerPriceTerm = db.BuyerPriceTerm.FirstOrDefault(x => x.BuyerId == id);
            if (buyerPriceTerm == null)
            {
                return NotFound();
            }

            return Ok(buyerPriceTerm);
        }
        
        [Route("postMailtoBuyer")]
        [HttpPost]
        public IHttpActionResult PostMailtoBuyer()
        {
            var buyerInfo = db.Buyers.Find(new Guid("9c525e3c-03f6-41d9-ad50-99ad66aba1c9"));
            EmailSender email = new EmailSender();
           // email.SendEmail();
            return Ok();
        }

        private bool BuyerDetailExists(Guid id)
        {
            return db.Buyers.Count(e => e.BuyerId == id) > 0;
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}