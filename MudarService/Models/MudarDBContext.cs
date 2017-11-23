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
        public DbSet<Season> Seasons { get; set; }
    }
    
}