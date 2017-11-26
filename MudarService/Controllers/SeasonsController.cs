using MudarDB.Models;
using MudarService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace MudarService.Controllers
{
    [RoutePrefix("api")]
    public class SeasonsController : ApiController
    {
        private MudarDBContext db = new MudarDBContext();

        // GET: api/Seasons
        [Route("seasons")]
        public IQueryable<Season> GetSeasons()
        {
            return db.Seasons;
        }

        // GET: api/Seasons/5
        [ResponseType(typeof(Season))]
        [Route("seasons/{id}")]
        public IHttpActionResult GetSeason(int id)
        {
            Season season = db.Seasons.Find(id);
            if (season == null)
            {
                return NotFound();
            }
            season.Products = db.SeasonProducts.Where(x => x.SeasonId == id).ToList();             
            return Ok(season);
        }

        // POST: api/Seasons
        [HttpPost]
        [ResponseType(typeof(Season))]
        [Route("seasons/addUpdate")]
        public IHttpActionResult PostSeason(Season season)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (season.SeasonId == 0)
            {
                season.CreatedBy = "superadmin";
                season.CreatedDate = DateTime.Now;
                db.Seasons.Add(season);
            }
            else
            {
                season.ModifiedBy = "superadmin";
                season.ModifiedDate = DateTime.Now;
                if (season.Products.Count > 0) {
                    var Products = db.SeasonProducts.Where<SeasonProductDetail>(x => x.SeasonId == season.SeasonId);
                    if (Products != null)
                        db.SeasonProducts.RemoveRange(Products);
                    season.Products = season.Products.Select(x => { x.SeasonId = season.SeasonId; return x; }).ToList();
                    db.SeasonProducts.AddRange(season.Products);
                        }
                db.Seasons.Attach(season);
                db.Entry<Season>(season).State = EntityState.Modified;
            }

            db.SaveChanges();
            return Ok("success");
        }

        // DELETE: api/Seasons/5
        [ResponseType(typeof(Season))]
        [Route("seasons/delete/{id}")]
        [HttpPost]
        public IHttpActionResult DeleteSeason(int id)
        {
            Season season = db.Seasons.Find(id);
            if (season == null)
            {
                return NotFound();
            }

            db.Seasons.Remove(season);
            db.SaveChanges();

            return Ok(season);
        }

    }
}