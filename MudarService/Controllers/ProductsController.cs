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

namespace MudarService.Controllers
{
    public class ProductsController : ApiController
    {
        private MudarDBContext db = new MudarDBContext();

        [Route("products")]
        // GET: api/Products
        public IHttpActionResult GetProducts()
        {
            var result = from itm in db.Products.Include(c => c.ProductCategory)
                         select new
                         {
                             itm.ProductId,
                             itm.ProductCode,
                             itm.ProductName,
                             itm.ProductType,
                             itm.ProductCategory.CategoryName,
                             itm.CategoryId,
                             itm.Description,
                             itm.Specification,
                             itm.ItcHsCode,
                             itm.CropSeason
                         };
            return Ok(result);
        }

        // GET: api/Products/5
        [Route("products/{id}")]
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            var product = (from prod in db.Products.Include(c => c.ProductCategory)
                           where prod.ProductId == id
                           select prod).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }


        // POST: api/Products
        [Route("products/addupdate")]
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (product.ProductId == 0)
            {
                product.CreatedBy = "superadmin";
                product.CreatedDate = DateTime.Now;
                db.Products.Add(product);
            }
            else
            {
                product.ModifiedBy = "superadmin";
                product.ModifiedDate = DateTime.Now;
                db.Products.Attach(product);
                db.Entry<Product>(product).State = EntityState.Modified;
            }

            db.SaveChanges();

            //return CreatedAtRoute("DefaultApi", new { id = product.ProductId }, product);
            return Ok("success");
        }


        // DELETE: api/Products/5
        [Route("products/delete/{id}")]
        [ResponseType(typeof(Product))]
        [HttpPost]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ProductId == id) > 0;
        }
    }
}