namespace WoMU_lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReBoot3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "OrderCity", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Orders", "OrderTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "OrderFName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Orders", "OrderSName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Orders", "OrderAddress", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.Orders", "OrderZipCode", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Orders", "OrderPhone", c => c.String(nullable: false, maxLength: 24));
            DropColumn("dbo.Orders", "Total");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "OrderPhone", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "OrderZipCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "OrderAddress", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "OrderSName", c => c.String());
            AlterColumn("dbo.Orders", "OrderFName", c => c.String());
            DropColumn("dbo.Orders", "OrderTotal");
            DropColumn("dbo.Orders", "OrderCity");
            DropColumn("dbo.Orders", "OrderDate");
        }
    }
}
