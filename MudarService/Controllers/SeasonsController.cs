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
        public IQueryable<Season> GetCategories()
        {
            return db.Seasons;
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
                db.Seasons.Attach(season);
                db.Entry<Season>(season).State = EntityState.Modified;
            }

            db.SaveChanges();
            return Ok("success");
        }

    }
}