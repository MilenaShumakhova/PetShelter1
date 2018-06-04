namespace PetShelterClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        City = c.String(),
                        Payment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StatusID_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Status", t => t.StatusID_ID)
                .Index(t => t.StatusID_ID);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserStatus = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserPets",
                c => new
                    {
                        User_ID = c.Int(nullable: false),
                        Pet_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_ID, t.Pet_ID })
                .ForeignKey("dbo.Users", t => t.User_ID, cascadeDelete: true)
                .ForeignKey("dbo.Pets", t => t.Pet_ID, cascadeDelete: true)
                .Index(t => t.User_ID)
                .Index(t => t.Pet_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "StatusID_ID", "dbo.Status");
            DropForeignKey("dbo.UserPets", "Pet_ID", "dbo.Pets");
            DropForeignKey("dbo.UserPets", "User_ID", "dbo.Users");
            DropIndex("dbo.UserPets", new[] { "Pet_ID" });
            DropIndex("dbo.UserPets", new[] { "User_ID" });
            DropIndex("dbo.Users", new[] { "StatusID_ID" });
            DropTable("dbo.UserPets");
            DropTable("dbo.Status");
            DropTable("dbo.Users");
            DropTable("dbo.Pets");
        }
    }
}
