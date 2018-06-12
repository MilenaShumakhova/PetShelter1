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
                        NameSurname = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        PaymentGetter = c.Double(nullable: false),
                        StartGetter = c.DateTime(),
                        EndGetter = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UsersPets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Payment = c.Double(nullable: false),
                        Start = c.DateTime(),
                        End = c.DateTime(),
                        Getter_ID = c.Int(),
                        Pet_ID = c.Int(),
                        User_ID = c.Int(),
                        User_ID1 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.Getter_ID)
                .ForeignKey("dbo.Pets", t => t.Pet_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .ForeignKey("dbo.Users", t => t.User_ID1)
                .Index(t => t.Getter_ID)
                .Index(t => t.Pet_ID)
                .Index(t => t.User_ID)
                .Index(t => t.User_ID1);
            
            CreateTable(
                "dbo.ExpectedPets",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        PetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.PetId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Pets", t => t.PetId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersPets", "User_ID1", "dbo.Users");
            DropForeignKey("dbo.UsersPets", "User_ID", "dbo.Users");
            DropForeignKey("dbo.UsersPets", "Pet_ID", "dbo.Pets");
            DropForeignKey("dbo.UsersPets", "Getter_ID", "dbo.Users");
            DropForeignKey("dbo.ExpectedPets", "PetId", "dbo.Pets");
            DropForeignKey("dbo.ExpectedPets", "UserId", "dbo.Users");
            DropIndex("dbo.ExpectedPets", new[] { "PetId" });
            DropIndex("dbo.ExpectedPets", new[] { "UserId" });
            DropIndex("dbo.UsersPets", new[] { "User_ID1" });
            DropIndex("dbo.UsersPets", new[] { "User_ID" });
            DropIndex("dbo.UsersPets", new[] { "Pet_ID" });
            DropIndex("dbo.UsersPets", new[] { "Getter_ID" });
            DropTable("dbo.ExpectedPets");
            DropTable("dbo.UsersPets");
            DropTable("dbo.Users");
            DropTable("dbo.Pets");
        }
    }
}
