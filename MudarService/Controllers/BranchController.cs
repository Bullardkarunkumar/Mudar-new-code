using MudarDB.Models;
using MudarService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MudarService.Controllers
{
    [RoutePrefix("api")]
    public class BranchController : ApiController
    {
        [Route("branchesandics")]
        public IHttpActionResult GetBranchesAndICS()
        {
            List<Branch> result = null;
            using (MudarDBContext mdbContext = new MudarDBContext())
            {
                result = mdbContext.Branches.ToList();
            }

            return Ok(result);
        }

        [Route("branches/type/{branchtype}")]
        public IHttpActionResult GetBranches(int branchtype)
        {
            List<Branch> result = null;
            using (MudarDBContext mdbContext = new MudarDBContext())
            {
                IQueryable<Branch> items = from branch in mdbContext.Branches
                                           where (int)branch.BranchType == branchtype
                                           select branch;

                result = items.ToList();
            }

            return Ok(result);
        }

        [Route("branches/{id}")]
        public IHttpActionResult GetBranchesOrICSById(string id)
        {
            Branch result = null;
            using (MudarDBContext mdbContext = new MudarDBContext())
            {
                result = mdbContext.Branches.SingleOrDefault(b => b.BranchId.ToString() == id);
            }
            if (result == null)
                return BadRequest("Branch Not Found");
            else
                return Ok(result);
        }

        [HttpPost]
        [Route("addUpdateBranch")]
        public IHttpActionResult AddUpdateBranchOrICS(Branch branch)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (MudarDBContext mdbContext = new MudarDBContext())
                    {
                        if (branch.BranchId == Guid.Empty)
                        {
                            branch.BranchId = Guid.NewGuid();
                            mdbContext.Branches.Add(branch);
                        }
                        else
                        {
                            mdbContext.Branches.Attach(branch);
                            mdbContext.Entry<Branch>(branch).State = EntityState.Modified;
                        }
                        mdbContext.SaveChanges();
                    }
                    return Ok("success");
                }
                else
                {
                    return BadRequest("failed");
                }
            }
            catch (Exception)
            {
                return BadRequest("failed");
            }

        }

        [HttpPost]
        [Route("BranchDelete/{id}")]
        public IHttpActionResult BranchDelete(string id)
        {
            try
            {
                using (MudarDBContext mdbContext = new MudarDBContext())
                {
                    var item = mdbContext.Branches.SingleOrDefault(b => b.BranchId.ToString() == id);
                    if (item == null)
                    {
                        return BadRequest("Branch/ICS Not found");
                    }
                    else
                    {
                        mdbContext.Branches.Remove(item);
                        mdbContext.SaveChanges();
                    }
                    return Ok("Success fully delete the Branch/ICS");
                }

            }
            catch (Exception ex)
            {
                return BadRequest("Failed to delete Branch/ICS");
            }
        }
    }
}
