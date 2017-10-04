namespace AdminWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsomeedit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "DateCreate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Countries", "DateCreate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Cities", "DataCreate");
            DropColumn("dbo.Countries", "DataCreate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Countries", "DataCreate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cities", "DataCreate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Countries", "DateCreate");
            DropColumn("dbo.Cities", "DateCreate");
        }
    }
}
