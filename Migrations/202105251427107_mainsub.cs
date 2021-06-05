namespace MVCDotNetV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mainsub : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.subcats",
                c => new
                    {
                        subcatId = c.Int(nullable: false, identity: true),
                        subcatName = c.String(),
                        Maincat_maincatID = c.Int(),
                    })
                .PrimaryKey(t => t.subcatId)
                .ForeignKey("dbo.maincats", t => t.Maincat_maincatID)
                .Index(t => t.Maincat_maincatID);
            
            CreateTable(
                "dbo.maincats",
                c => new
                    {
                        maincatID = c.Int(nullable: false, identity: true),
                        maincatName = c.String(),
                    })
                .PrimaryKey(t => t.maincatID);
            
            AddColumn("dbo.Products", "Subcat_subcatId", c => c.Int());
            CreateIndex("dbo.Products", "Subcat_subcatId");
            AddForeignKey("dbo.Products", "Subcat_subcatId", "dbo.subcats", "subcatId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Subcat_subcatId", "dbo.subcats");
            DropForeignKey("dbo.subcats", "Maincat_maincatID", "dbo.maincats");
            DropIndex("dbo.subcats", new[] { "Maincat_maincatID" });
            DropIndex("dbo.Products", new[] { "Subcat_subcatId" });
            DropColumn("dbo.Products", "Subcat_subcatId");
            DropTable("dbo.maincats");
            DropTable("dbo.subcats");
        }
    }
}
