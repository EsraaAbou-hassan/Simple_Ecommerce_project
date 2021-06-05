namespace MVCDotNetV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminCart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartAdmins",
                c => new
                    {
                        CartAdminID = c.Int(nullable: false, identity: true),
                        BuyerID = c.String(),
                        BuyerName = c.String(),
                        CartContent = c.String(),
                        AddTime = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                        IsActionTaken = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CartAdminID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CartAdmins");
        }
    }
}
