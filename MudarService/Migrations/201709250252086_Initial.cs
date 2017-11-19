namespace MudarService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblBranchDetails",
                c => new
                    {
                        BranchId = c.Guid(nullable: false),
                        BranchCode = c.String(maxLength: 20),
                        Bname = c.String(maxLength: 40),
                        BranchType = c.Int(nullable: false),
                        Address = c.String(maxLength: 200),
                        City = c.String(maxLength: 40),
                        Taluk = c.String(maxLength: 40),
                        District = c.String(maxLength: 40),
                        State = c.String(maxLength: 40),
                        Country = c.String(maxLength: 40),
                        BranchHeadCode = c.Guid(nullable: false),
                        Designation = c.String(maxLength: 40),
                        Default = c.Boolean(nullable: false),
                        Tin = c.String(maxLength: 100),
                        ContactPerson = c.String(maxLength: 100),
                        Phone_Fax = c.String(maxLength: 100),
                        Mobile = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        Website = c.String(maxLength: 100),
                        BankName = c.String(maxLength: 100),
                        BankAcct_no = c.String(maxLength: 100),
                        Bank_ADC_Code = c.String(maxLength: 100),
                        IECode = c.String(maxLength: 100),
                        FDA = c.String(maxLength: 100),
                        AP_VAT = c.String(maxLength: 100),
                        Organic_Premium = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        Delete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BranchId);
            
            CreateTable(
                "dbo.tblBuyerDetails",
                c => new
                    {
                        BuyerId = c.Guid(nullable: false),
                        BuyerCompanyName = c.String(),
                        BuyerFirstName = c.String(),
                        BuyerLastName = c.String(),
                        CAddressLine1 = c.String(),
                        CAddressLine2 = c.String(),
                        CCity = c.String(),
                        CState = c.String(),
                        CPincode = c.String(),
                        CCountry = c.String(),
                        TINNumber = c.String(),
                        VAT = c.String(),
                        CST = c.String(),
                        GST = c.String(),
                        Phone = c.String(),
                        Mphone = c.String(),
                        CContactPerson = c.String(),
                        CContactPhoneNo = c.String(),
                        MobileforTextingpurpose = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                        NotifyName = c.String(),
                        NAddressLine1 = c.String(),
                        NAddressLine2 = c.String(),
                        NCity = c.String(),
                        NState = c.String(),
                        NContactPhoneNo = c.String(),
                        NPincode = c.String(),
                        NCountry = c.String(),
                        BankOrConsignee = c.Int(nullable: false),
                        BankName = c.String(),
                        BankAddressLine1 = c.String(),
                        BankAddressLine2 = c.String(),
                        BankCity = c.String(),
                        BankState = c.String(),
                        BankPincode = c.String(),
                        BankCountry = c.String(),
                        BuyerCode = c.String(),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Apporval = c.Boolean(nullable: false),
                        FairTrade = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FairTradPremium = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Lotsample = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        Delete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BuyerId)
                .ForeignKey("dbo.tblUserLogin", t => t.BuyerId)
                .Index(t => t.BuyerId);

            CreateTable(
                "dbo.tblProductDetails",
                c => new
                {
                    ProductId = c.Int(nullable: false, identity: true),
                    ProductCode = c.String(),
                    ProductName = c.String(nullable: false, maxLength: 50),
                    Description = c.String(maxLength: 200),
                    ItcHsCode = c.String(maxLength: 20),
                    CropSeason = c.Int(nullable: false),
                    Specification = c.String(),
                    ProductType = c.String(),
                    CategoryId = c.Int(nullable: false),
                    CreatedBy = c.String(),
                    CreatedDate = c.DateTime(),
                    ModifiedBy = c.String(),
                    ModifiedDate = c.DateTime(),
                    Delete = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.tblCategory", t => t.CategoryId, cascadeDelete: true)                
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.tblCategory",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 30),
                        Description = c.String(maxLength: 60),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        Delete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.tblUserLogin",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        UserLoginId = c.String(nullable: false, maxLength: 4000),
                        UserPassword = c.String(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        Delete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.UserLoginId, unique: true);
            
            CreateTable(
                "dbo.tblEmployeeDetails",
                c => new
                    {
                        EmployeeId = c.Guid(nullable: false),
                        EmployeeFirstName = c.String(maxLength: 4000),
                        EmployeeLastName = c.String(maxLength: 4000),
                        BranchId = c.Guid(nullable: false),
                        Address = c.String(maxLength: 4000),
                        Taluk = c.String(maxLength: 4000),
                        City = c.String(maxLength: 4000),
                        District = c.String(maxLength: 4000),
                        State = c.String(maxLength: 4000),
                        Country = c.String(maxLength: 4000),
                        Phone = c.String(maxLength: 4000),
                        Mphone = c.String(maxLength: 4000),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        Delete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.tblBranchDetails", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.tblUserLogin", t => t.EmployeeId)
                .Index(t => t.EmployeeId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.tblSupplierDetails",
                c => new
                    {
                        SupplierId = c.Guid(nullable: false),
                        SupplierCompanyName = c.String(),
                        SupplierFirstName = c.String(),
                        SupplierLastName = c.String(),
                        CAddress = c.String(),
                        CCity = c.String(),
                        CState = c.String(),
                        CCountry = c.String(),
                        Phone = c.String(),
                        Mphone = c.String(),
                        TINNumber = c.String(),
                        CContactPerson = c.String(),
                        CContactPhoneNo = c.String(),
                        CPincode = c.String(),
                        BankName = c.String(),
                        BankAddress = c.String(),
                        BankCity = c.String(),
                        BankCountry = c.String(),
                        BankContactPerson = c.String(),
                        BankContactPhoneNo = c.String(),
                        BankPincode = c.String(),
                        BankState = c.String(),
                        MobileforTextingpurpose = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                        VAT = c.String(),
                        CST = c.String(),
                        SupplierType = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        Delete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierId)
                .ForeignKey("dbo.tblUserLogin", t => t.SupplierId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.tblUsersInRoles",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        Delete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.tblUserLogin", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.tblRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.tblRoles",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        RoleName = c.String(),
                        RoleDisplayName = c.String(),
                        BranchRoleValue = c.Int(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        Delete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblBuyerDetails", "BuyerId", "dbo.tblUserLogin");
            DropForeignKey("dbo.tblUsersInRoles", "RoleId", "dbo.tblRoles");
            DropForeignKey("dbo.tblUsersInRoles", "UserId", "dbo.tblUserLogin");
            DropForeignKey("dbo.tblSupplierDetails", "SupplierId", "dbo.tblUserLogin");
            DropForeignKey("dbo.tblEmployeeDetails", "EmployeeId", "dbo.tblUserLogin");
            DropForeignKey("dbo.tblEmployeeDetails", "BranchId", "dbo.tblBranchDetails");            
            DropForeignKey("dbo.tblProductDetails", "CategoryId", "dbo.tblCategory");
            DropIndex("dbo.tblUsersInRoles", new[] { "UserId" });
            DropIndex("dbo.tblUsersInRoles", new[] { "RoleId" });
            DropIndex("dbo.tblSupplierDetails", new[] { "SupplierId" });
            DropIndex("dbo.tblEmployeeDetails", new[] { "BranchId" });
            DropIndex("dbo.tblEmployeeDetails", new[] { "EmployeeId" });
            DropIndex("dbo.tblUserLogin", new[] { "UserLoginId" });            
            DropIndex("dbo.tblProductDetails", new[] { "CategoryId" });
            DropIndex("dbo.tblBuyerDetails", new[] { "BuyerId" });
            DropTable("dbo.tblRoles");
            DropTable("dbo.tblUsersInRoles");
            DropTable("dbo.tblSupplierDetails");
            DropTable("dbo.tblEmployeeDetails");
            DropTable("dbo.tblUserLogin");
            DropTable("dbo.tblCategory");
            DropTable("dbo.tblProductDetails");
            DropTable("dbo.tblBuyerDetails");
            DropTable("dbo.tblBranchDetails");
        }
    }
}
