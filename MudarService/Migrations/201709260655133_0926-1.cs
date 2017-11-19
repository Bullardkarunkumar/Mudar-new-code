namespace MudarService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _09261 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblBuyerDetails", "BankOrConsignee", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblBuyerDetails", "BankOrConsignee", c => c.Int(nullable: false));
        }
    }
}
