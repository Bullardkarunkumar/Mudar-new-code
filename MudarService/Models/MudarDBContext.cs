using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Migrations;
using MudarService.Models;

namespace MudarDB.Models
{
    public class MudarDBContext : DbContext
    {
        public MudarDBContext() : base("name=MudarDBContext")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<MudarDBContext, MudarService.Migrations.Configuration>("MudarDBContext"));
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<UsersInRole> UserRoles { get; set; }
        public DbSet<SupplierDetail> Suppliers { get; set; }
        public DbSet<BuyerDetail> Buyers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BuyerProductDetails> BuyerProducts { get; set; }
    }

    //public class MudarDBInitializer : DropCreateDatabaseIfModelChanges<MudarDBContext>
    //{        
    //    protected override void Seed(MudarDBContext context)
    //    {            
    //        List<Role> masterRoles = new List<Role>() {
    //            new Role() {
    //                RoleId = Guid.NewGuid(),
    //                RoleName = "SuperAdmin",
    //                RoleDisplayName="Super Admin",
    //                CreatedBy = "superadmin",
    //                CreatedDate = DateTime.Now,
    //                BranchRoleValue=null,
    //                IsDeleted = false,
    //                ModifiedBy = null,
    //                ModifiedDate = null
    //            },
    //            new Role() {
    //                RoleId = Guid.NewGuid(),
    //                RoleName = "Supplier",
    //                RoleDisplayName="Supplier",
    //                BranchRoleValue=null,
    //                CreatedBy = "superadmin",
    //                CreatedDate = DateTime.Now,
    //                IsDeleted = false,
    //                ModifiedBy = null,
    //                ModifiedDate = null
    //            },
    //            new Role() {
    //                RoleId = Guid.NewGuid(),
    //                RoleName = "Buyer",
    //                RoleDisplayName="Buyer",
    //                BranchRoleValue=null,
    //                CreatedBy = "superadmin",
    //                CreatedDate = DateTime.Now,
    //                IsDeleted = false,
    //                ModifiedBy = null,
    //                ModifiedDate = null
    //            },
    //             new Role() {
    //                RoleId = Guid.NewGuid(),
    //                RoleName = "Branch",
    //                RoleDisplayName="Branch",
    //                BranchRoleValue=1,
    //                CreatedBy = "superadmin",
    //                CreatedDate = DateTime.Now,
    //                IsDeleted = false,
    //                ModifiedBy = null,
    //                ModifiedDate = null
    //            },
    //              new Role() {
    //                RoleId = Guid.NewGuid(),
    //                RoleName = "ICS",
    //                RoleDisplayName="ICS",
    //                BranchRoleValue=0,
    //                CreatedBy = "superadmin",
    //                CreatedDate = DateTime.Now,
    //                IsDeleted = false,
    //                ModifiedBy = null,
    //                ModifiedDate = null
    //            },
    //              new Role() {
    //                RoleId = Guid.NewGuid(),
    //                RoleName = "ICSSupplier",
    //                RoleDisplayName="ICS Supplier",
    //                BranchRoleValue=2,
    //                CreatedBy = "superadmin",
    //                CreatedDate = DateTime.Now,
    //                IsDeleted = false,
    //                ModifiedBy = null,
    //                ModifiedDate = null
    //            }
    //        };


    //        UserLogin superadminUser = new UserLogin()
    //        {
    //            UserId = Guid.NewGuid(),
    //            UserLoginId = "superadmin",
    //            UserPassword = "superadmin",
    //            CreatedBy = "superadmin",
    //            CreatedDate = DateTime.Now,
    //            ModifiedBy = null,
    //            ModifiedDate = null,
    //            IsDeleted = false
    //        };

    //        UsersInRole usrRole = new UsersInRole()
    //        {
    //            RoleId = masterRoles.First().RoleId,
    //            UserId = superadminUser.UserId,
    //            CreatedDate = DateTime.Now,
    //            CreatedBy = "superadmin",
    //            ModifiedBy = null,
    //            ModifiedDate = null,
    //            IsDeleted = false
    //        };

    //        context.Roles.AddOrUpdate(masterRoles.ToArray());
    //        context.UserLogins.AddOrUpdate(superadminUser);
    //        context.UserRoles.AddOrUpdate(usrRole);

    //        base.Seed(context);
    //    }
    //}
}