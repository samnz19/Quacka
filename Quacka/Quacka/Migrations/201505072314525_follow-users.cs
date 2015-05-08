namespace Quacka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class followusers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserFollowers",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        FollowerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.FollowerId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerId)
                .Index(t => t.UserId)
                .Index(t => t.FollowerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserFollowers", "FollowerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserFollowers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserFollowers", new[] { "FollowerId" });
            DropIndex("dbo.UserFollowers", new[] { "UserId" });
            DropTable("dbo.UserFollowers");
        }
    }
}
