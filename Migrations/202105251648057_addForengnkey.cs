namespace MVCDotNetV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addForengnkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Subcat_subcatId", "dbo.subcats");
            DropForeignKey("dbo.subcats", "Maincat_maincatID", "dbo.maincats");
            DropIndex("dbo.Products", new[] { "Subcat_subcatId" });
            DropIndex("dbo.subcats", new[] { "Maincat_maincatID" });
            RenameColumn(table: "dbo.Products", name: "Subcat_subcatId", newName: "subcatId");
            RenameColumn(table: "dbo.subcats", name: "Maincat_maincatID", newName: "maincatID");
            AlterColumn("dbo.Products", "subcatId", c => c.Int(nullable: false));
            AlterColumn("dbo.subcats", "maincatID", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "subcatId");
            CreateIndex("dbo.subcats", "maincatID");
            AddForeignKey("dbo.Products", "subcatId", "dbo.subcats", "subcatId", cascadeDelete: true);
            AddForeignKey("dbo.subcats", "maincatID", "dbo.maincats", "maincatID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.subcats", "maincatID", "dbo.maincats");
            DropForeignKey("dbo.Products", "subcatId", "dbo.subcats");
            DropIndex("dbo.subcats", new[] { "maincatID" });
            DropIndex("dbo.Products", new[] { "subcatId" });
            AlterColumn("dbo.subcats", "maincatID", c => c.Int());
            AlterColumn("dbo.Products", "subcatId", c => c.Int());
            RenameColumn(table: "dbo.subcats", name: "maincatID", newName: "Maincat_maincatID");
            RenameColumn(table: "dbo.Products", name: "subcatId", newName: "Subcat_subcatId");
            CreateIndex("dbo.subcats", "Maincat_maincatID");
            CreateIndex("dbo.Products", "Subcat_subcatId");
            AddForeignKey("dbo.subcats", "Maincat_maincatID", "dbo.maincats", "maincatID");
            AddForeignKey("dbo.Products", "Subcat_subcatId", "dbo.subcats", "subcatId");
        }
    }
}
