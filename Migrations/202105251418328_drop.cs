namespace MVCDotNetV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class drop : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "MainCategory");
            DropColumn("dbo.Products", "SubCategory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "SubCategory", c => c.String());
            AddColumn("dbo.Products", "MainCategory", c => c.String());
        }
    }
}
