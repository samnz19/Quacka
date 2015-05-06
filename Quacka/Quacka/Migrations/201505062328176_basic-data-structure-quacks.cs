namespace Quacka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class basicdatastructurequacks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Quacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(nullable: false, maxLength: 140),
                        CreatedAt = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Quacks", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Quacks", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Quacks");
        }
    }
}
