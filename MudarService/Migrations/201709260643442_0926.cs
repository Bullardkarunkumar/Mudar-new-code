namespace MudarService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0926 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblBuyerProductDetails",
                c => new
                    {
                        BuyerProductId = c.Int(nullable: false, identity: true),
                        BuyerId = c.Guid(nullable: false),
                        ProductId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        Delete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BuyerProductId)
                .ForeignKey("dbo.tblBuyerDetails", t => t.BuyerId, cascadeDelete: true)
                .ForeignKey("dbo.tblProductDetails", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.BuyerId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblBuyerProductDetails", "ProductId", "dbo.tblProductDetails");
            DropForeignKey("dbo.tblBuyerProductDetails", "BuyerId", "dbo.tblBuyerDetails");
            DropIndex("dbo.tblBuyerProductDetails", new[] { "ProductId" });
            DropIndex("dbo.tblBuyerProductDetails", new[] { "BuyerId" });
            DropTable("dbo.tblBuyerProductDetails");
        }
    }
}
