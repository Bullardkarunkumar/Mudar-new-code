using MudarDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using MudarService.Models;
using MudarService.Common;

namespace MudarService.Controllers
{
    [RoutePrefix("api")]
    public class MudarIdentityController : ApiController
    {
        [Route("users")]
        public IHttpActionResult GetUsers()
        {
            List<UserLogin> result = null;

            using (MudarDBContext dbcontext = new MudarDBContext())
            {
                result = dbcontext.UserLogins.ToList();
            }
            return Ok(result);
        }

        [Route("user/{id}")]
        public IHttpActionResult GetUserbyId(string id)
        {
            //UserLogin result = null;

            using (MudarDBContext dbcontext = new MudarDBContext())
            {
                //result = dbcontext.UserLogins.FirstOrDefault(usr => usr.UserId.ToString() == id);

                var result = (from emp in dbcontext.Employees.Include(b => b.BranchInfo)
                              join rol in dbcontext.UserRoles.Include(r => r.UserRole) on emp.EmployeeId equals rol.UserId
                              where emp.EmployeeId.ToString() == id
                              select new
                              {
                                  emp.EmployeeId,
                                  emp.EmployeeFirstName,
                                  emp.EmployeeLastName,
                                  emp.BranchInfo.BranchName,
                                  emp.BranchId,
                                  emp.City,
                                  emp.Mphone,
                                  emp.Phone,
                                  emp.State,
                                  emp.Taluk,
                                  emp.District,
                                  emp.Country,
                                  emp.Address
                              }).FirstOrDefault();
                if (result == null)
                    return BadRequest();
                return Ok(result);
            }
        }

        [Route("suppliers")]
        public IHttpActionResult GetSuppliers()
        {
            List<SupplierDetail> result = null;

            using (MudarDBContext dbcontext = new MudarDBContext())
            {
                result = dbcontext.Suppliers.Include(s => s.UserLoginInfo).ToList();
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(UserLogin usrLogin)
        {
            //UserLogin input = new UserLogin() { UserLoginId = userName, UserPassword = password };
            UserLogin userDetails = null;
            string userroleName = "";
            using (MudarDBContext mdbContext = new MudarDBContext())
            {
                userDetails = mdbContext.UserLogins
                    .Include(s => s.SupplierInfo)
                    .Include(b => b.BuyerInfo)
                    .Include(ur => ur.UserRoles)
                    .FirstOrDefault(usr => usr.UserLoginId == usrLogin.UserLoginId
                               && usr.UserPassword == usrLogin.UserPassword);
                if (userDetails != null)
                {
                    var roleid = userDetails.UserRoles.First().RoleId;
                    userroleName = (from r in mdbContext.Roles
                                    where r.RoleId == roleid
                                    select r.RoleName).First();

                }
            }


            if (userDetails == null)
                return NotFound();
            else
            {
                var result = new
                {
                    userDetails.UserLoginId,
                    userDetails.BuyerInfo,
                    userDetails.SupplierInfo,
                    userDetails.EmployeeInfo,
                    roleName = userroleName
                };
                return Ok(result);
            }
        }

        [HttpGet]
        [Route("roles")]
        public IHttpActionResult GetRoles()
        {
            List<Role> result = null;

            using (MudarDBContext dbcontext = new MudarDBContext())
            {
                result = (from r in dbcontext.Roles
                          where r.RoleName.ToLower() != "superadmin" && r.RoleName.ToLower() != "supplier"
                                && r.RoleName.ToLower() != "buyer"
                          select r).ToList();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("users/{roleName}")]
        public IHttpActionResult GetUsersByRole(string roleName)
        {
            List<UserLogin> result = null;
            if (string.IsNullOrWhiteSpace(roleName))
            {
                return BadRequest();
            }
            else
            {
                using (MudarDBContext dbcontext = new MudarDBContext())
                {
                    if (roleName == MudarRoles.ICSSupplier || roleName == MudarRoles.Branch || roleName == MudarRoles.ICS)
                    {
                        var itms = (from emp in dbcontext.Employees.Include(b => b.BranchInfo)
                                    join rol in dbcontext.UserRoles.Include(r => r.UserRole) on emp.EmployeeId equals rol.UserId
                                    where rol.UserRole.RoleName.ToLower() == roleName.ToLower()
                                    select new
                                    {
                                        emp.EmployeeId,
                                        emp.EmployeeFirstName,
                                        emp.EmployeeLastName,
                                        emp.BranchInfo.BranchName,
                                        emp.BranchId,
                                        emp.City,
                                        emp.Mphone,
                                        emp.Phone,
                                        emp.State,
                                        emp.Taluk,
                                        emp.District,
                                        emp.Country,
                                        emp.Address
                                    }).ToList();

                        return Ok(itms);
                    }

                    result = (from usr in dbcontext.UserLogins
                              join rol in dbcontext.UserRoles.Include(r => r.UserRole) on usr.UserId equals rol.UserId
                              where rol.UserRole.RoleName.ToLower() == roleName.ToLower()
                              select usr).ToList();
                }
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("employees/{type}")]
        public IHttpActionResult AddOrUpdateEmployee(Employee employee, int type)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (MudarDBContext mdbContext = new MudarDBContext())
                    {
                        if (employee.EmployeeId == Guid.Empty)
                        {
                            employee.EmployeeId = Guid.NewGuid();
                            employee.CreatedBy = "superadmin";
                            employee.CreatedDate = DateTime.Now;

                            var userlogin = new UserLogin()
                            {
                                UserId = employee.EmployeeId,
                                UserLoginId = MudarCommon.GenerateULogin(employee.EmployeeFirstName),
                                UserPassword = MudarCommon.GeneratePassword(employee.EmployeeFirstName),
                                CreatedBy = "superadmin",
                                CreatedDate = DateTime.Now
                            };

                            var usrRole = new UsersInRole()
                            {
                                UserId = employee.EmployeeId,
                                RoleId = mdbContext.Roles.First(r => r.BranchRoleValue == type).RoleId,
                                CreatedBy = "superadmin",
                                CreatedDate = DateTime.Now
                            };

                            mdbContext.UserLogins.Add(userlogin);
                            mdbContext.Employees.Add(employee);
                            mdbContext.UserRoles.Add(usrRole);
                        }
                        else
                        {
                            mdbContext.Employees.Attach(employee);
                            mdbContext.Entry<Employee>(employee).State = EntityState.Modified;
                            employee.ModifiedBy = "superadmin";
                            employee.ModifiedDate = DateTime.Now;
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
        [Route("employees/delete/{id}")]
        public IHttpActionResult DeleteUser(string id)
        {

            using (MudarDBContext mdbContext = new MudarDBContext())
            {
                UserLogin usr = mdbContext.UserLogins.FirstOrDefault(u => u.UserId.ToString() == id);
                if (usr == null)
                {
                    return NotFound();
                }

                mdbContext.UserLogins.Remove(usr);
                var emp = mdbContext.Employees.FirstOrDefault(u => u.EmployeeId.ToString() == id);
                mdbContext.Employees.Remove(emp);
                mdbContext.SaveChanges();

                return Ok("success");
            }
        }

    }
}
