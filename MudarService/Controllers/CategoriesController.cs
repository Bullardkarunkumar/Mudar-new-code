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
    public class CategoriesController : ApiController
    {
        private MudarDBContext db = new MudarDBContext();

        // GET: api/Categories
        [Route("categories")]
        public IQueryable<Category> GetCategories()
        {
            return db.Categories;
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Category))]
        [Route("categories/{id}")]
        public IHttpActionResult GetCategory(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // POST: api/Categories
        [ResponseType(typeof(Category))]
        [Route("categories/addUpdate")]
        public IHttpActionResult PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (category.CategoryId == 0)
            {
                category.CreatedBy = "superadmin";
                category.CreatedDate = DateTime.Now;
                db.Categories.Add(category);
            }
            else
            {
                category.ModifiedBy = "superadmin";
                category.ModifiedDate= DateTime.Now;
                db.Categories.Attach(category);
                db.Entry<Category>(category).State = EntityState.Modified;
            }

            db.SaveChanges();
            return Ok("success");
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Category))]
        [Route("categories/delete/{id}")]
        [HttpPost]
        public IHttpActionResult DeleteCategory(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Categories.Remove(category);
            db.SaveChanges();

            return Ok(category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(int id)
        {
            return db.Categories.Count(e => e.CategoryId == id) > 0;
        }
    }
}