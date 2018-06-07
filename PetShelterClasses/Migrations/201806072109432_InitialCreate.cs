namespace PetShelterClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Getters",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Payment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Givers",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Payment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.UsersPets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Getter_ID = c.Int(),
                        Giver_ID = c.Int(),
                        Pet_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Getters", t => t.Getter_ID)
                .ForeignKey("dbo.Givers", t => t.Giver_ID)
                .ForeignKey("dbo.Pets", t => t.Pet_ID)
                .Index(t => t.Getter_ID)
                .Index(t => t.Giver_ID)
                .Index(t => t.Pet_ID);
            
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
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.GiverGetters",
                c => new
                    {
                        Giver_ID = c.Int(nullable: false),
                        Getter_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Giver_ID, t.Getter_ID })
                .ForeignKey("dbo.Givers", t => t.Giver_ID, cascadeDelete: true)
                .ForeignKey("dbo.Getters", t => t.Getter_ID, cascadeDelete: true)
                .Index(t => t.Giver_ID)
                .Index(t => t.Getter_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Givers", "ID", "dbo.Users");
            DropForeignKey("dbo.Getters", "ID", "dbo.Users");
            DropForeignKey("dbo.UsersPets", "Pet_ID", "dbo.Pets");
            DropForeignKey("dbo.UsersPets", "Giver_ID", "dbo.Givers");
            DropForeignKey("dbo.UsersPets", "Getter_ID", "dbo.Getters");
            DropForeignKey("dbo.GiverGetters", "Getter_ID", "dbo.Getters");
            DropForeignKey("dbo.GiverGetters", "Giver_ID", "dbo.Givers");
            DropIndex("dbo.GiverGetters", new[] { "Getter_ID" });
            DropIndex("dbo.GiverGetters", new[] { "Giver_ID" });
            DropIndex("dbo.UsersPets", new[] { "Pet_ID" });
            DropIndex("dbo.UsersPets", new[] { "Giver_ID" });
            DropIndex("dbo.UsersPets", new[] { "Getter_ID" });
            DropIndex("dbo.Givers", new[] { "ID" });
            DropIndex("dbo.Getters", new[] { "ID" });
            DropTable("dbo.GiverGetters");
            DropTable("dbo.Users");
            DropTable("dbo.Pets");
            DropTable("dbo.UsersPets");
            DropTable("dbo.Givers");
            DropTable("dbo.Getters");
        }
    }
}
