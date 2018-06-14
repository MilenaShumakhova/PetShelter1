namespace PetShelterClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewName : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Marks", name: "Request_ID", newName: "IRequest_ID");
            RenameIndex(table: "dbo.Marks", name: "IX_Request_ID", newName: "IX_IRequest_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Marks", name: "IX_IRequest_ID", newName: "IX_Request_ID");
            RenameColumn(table: "dbo.Marks", name: "IRequest_ID", newName: "Request_ID");
        }
    }
}
