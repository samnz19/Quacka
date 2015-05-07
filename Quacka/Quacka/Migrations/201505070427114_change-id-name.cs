namespace Quacka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeidname : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Quacks", name: "ApplicationUser_Id", newName: "ApplicationUserId_Id");
            RenameIndex(table: "dbo.Quacks", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUserId_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Quacks", name: "IX_ApplicationUserId_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Quacks", name: "ApplicationUserId_Id", newName: "ApplicationUser_Id");
        }
    }
}
