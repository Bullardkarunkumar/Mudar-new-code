namespace MudarService.Migrations
{
    using Models;
    using MudarDB.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MudarDB.Models.MudarDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MudarDBContext context)
        {
            List<Role> masterRoles = new List<Role>() {
                new Role() {
                    RoleId = new Guid("526AE5FC-7B4A-4307-973E-CB5E5731F921"),
                    RoleName = "SuperAdmin",
                    RoleDisplayName="Super Admin",
                    CreatedBy = "superadmin",
                    CreatedDate = DateTime.Now,
                    BranchRoleValue=null,
                    IsDeleted = false,
                    ModifiedBy = null,
                    ModifiedDate = null
                },
                new Role() {
                    RoleId = new Guid("7761BE81-E90D-40D0-8214-DB7990F8D1DC"),
                    RoleName = "Supplier",
                    RoleDisplayName="Supplier",
                    BranchRoleValue=null,
                    CreatedBy = "superadmin",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    ModifiedBy = null,
                    ModifiedDate = null
                },
                new Role() {
                    RoleId = new Guid("5163ECCD-9FE4-498E-A0EE-0F7863D05C69"),
                    RoleName = "Buyer",
                    RoleDisplayName="Buyer",
                    BranchRoleValue=null,
                    CreatedBy = "superadmin",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    ModifiedBy = null,
                    ModifiedDate = null
                },
                 new Role() {
                    RoleId = new Guid("47324C9D-FD86-41FF-8AB6-ACF59B72D762"),
                    RoleName = "Branch",
                    RoleDisplayName="Branch",
                    BranchRoleValue=1,
                    CreatedBy = "superadmin",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    ModifiedBy = null,
                    ModifiedDate = null
                },
                  new Role() {
                    RoleId = new Guid("4B3B6F4F-7667-43D7-918D-21CF99C81242"),
                    RoleName = "ICS",
                    RoleDisplayName="ICS",
                    BranchRoleValue=0,
                    CreatedBy = "superadmin",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    ModifiedBy = null,
                    ModifiedDate = null
                },
                  new Role() {
                    RoleId = new Guid("C34D79DF-F5D8-4847-B60C-439D71D174EE"),
                    RoleName = "ICSSupplier",
                    RoleDisplayName="ICS Supplier",
                    BranchRoleValue=2,
                    CreatedBy = "superadmin",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    ModifiedBy = null,
                    ModifiedDate = null
                }
            };


            UserLogin superadminUser = new UserLogin()
            {
                UserId = new Guid("9313E2EB-94D4-461C-B679-958981B5E881"),
                UserLoginId = "superadmin",
                UserPassword = "superadmin",
                CreatedBy = "superadmin",
                CreatedDate = DateTime.Now,
                ModifiedBy = null,
                ModifiedDate = null,
                IsDeleted = false
            };

            UsersInRole usrRole = new UsersInRole()
            {
                RoleId = masterRoles.First().RoleId,
                UserId = superadminUser.UserId,
                CreatedDate = DateTime.Now,
                CreatedBy = "superadmin",
                ModifiedBy = null,
                ModifiedDate = null,
                IsDeleted = false
            };

            context.Roles.AddOrUpdate(masterRoles.ToArray());
            context.UserLogins.AddOrUpdate(superadminUser);
            context.UserRoles.AddOrUpdate(usrRole);

            base.Seed(context);
        }
    }
}
