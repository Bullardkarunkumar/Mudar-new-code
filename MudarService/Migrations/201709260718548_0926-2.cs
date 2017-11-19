namespace MudarService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _09262 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblBuyerProductDetails", "ProductId", "dbo.tblProductDetails");
            DropIndex("dbo.tblBuyerProductDetails", new[] { "ProductId" });
            AlterColumn("dbo.tblBuyerProductDetails", "ProductId", c => c.Int());
            CreateIndex("dbo.tblBuyerProductDetails", "ProductId");
            AddForeignKey("dbo.tblBuyerProductDetails", "ProductId", "dbo.tblProductDetails", "ProductId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblBuyerProductDetails", "ProductId", "dbo.tblProductDetails");
            DropIndex("dbo.tblBuyerProductDetails", new[] { "ProductId" });
            AlterColumn("dbo.tblBuyerProductDetails", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.tblBuyerProductDetails", "ProductId");
            AddForeignKey("dbo.tblBuyerProductDetails", "ProductId", "dbo.tblProductDetails", "ProductId", cascadeDelete: true);
        }
    }
}
