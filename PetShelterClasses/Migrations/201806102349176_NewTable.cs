namespace PetShelterClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserPets", newName: "ExpectedPets");
            RenameColumn(table: "dbo.ExpectedPets", name: "User_ID", newName: "UserId");
            RenameColumn(table: "dbo.ExpectedPets", name: "Pet_ID", newName: "PetId");
            RenameIndex(table: "dbo.ExpectedPets", name: "IX_User_ID", newName: "IX_UserId");
            RenameIndex(table: "dbo.ExpectedPets", name: "IX_Pet_ID", newName: "IX_PetId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ExpectedPets", name: "IX_PetId", newName: "IX_Pet_ID");
            RenameIndex(table: "dbo.ExpectedPets", name: "IX_UserId", newName: "IX_User_ID");
            RenameColumn(table: "dbo.ExpectedPets", name: "PetId", newName: "Pet_ID");
            RenameColumn(table: "dbo.ExpectedPets", name: "UserId", newName: "User_ID");
            RenameTable(name: "dbo.ExpectedPets", newName: "UserPets");
        }
    }
}
