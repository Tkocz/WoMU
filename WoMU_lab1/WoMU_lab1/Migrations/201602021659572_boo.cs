namespace WoMU_lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class boo : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Carts");
            AddColumn("dbo.Carts", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Carts", "CartId", c => c.String());
            AddPrimaryKey("dbo.Carts", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Carts");
            AlterColumn("dbo.Carts", "CartId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Carts", "ID");
            AddPrimaryKey("dbo.Carts", "CartId");
        }
    }
}
