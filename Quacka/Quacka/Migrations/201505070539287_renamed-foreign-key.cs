namespace Quacka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamedforeignkey : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Quacks", name: "ApplicationUser_Id", newName: "Owner_Id");
            RenameIndex(table: "dbo.Quacks", name: "IX_ApplicationUser_Id", newName: "IX_Owner_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Quacks", name: "IX_Owner_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Quacks", name: "Owner_Id", newName: "ApplicationUser_Id");
        }
    }
}
