namespace PetShelterClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GiverGetters", "Giver_ID", "dbo.Givers");
            DropForeignKey("dbo.GiverGetters", "Getter_ID", "dbo.Getters");
            DropForeignKey("dbo.UsersPets", "Getter_ID", "dbo.Getters");
            DropForeignKey("dbo.UsersPets", "Giver_ID", "dbo.Givers");
            DropForeignKey("dbo.Getters", "ID", "dbo.Users");
            DropForeignKey("dbo.Givers", "ID", "dbo.Users");
            DropIndex("dbo.Getters", new[] { "ID" });
            DropIndex("dbo.Givers", new[] { "ID" });
            DropIndex("dbo.UsersPets", new[] { "Getter_ID" });
            DropIndex("dbo.UsersPets", new[] { "Giver_ID" });
            DropIndex("dbo.GiverGetters", new[] { "Giver_ID" });
            DropIndex("dbo.GiverGetters", new[] { "Getter_ID" });
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
            
            AddColumn("dbo.UsersPets", "User_ID", c => c.Int());
            AddColumn("dbo.Users", "NameSurname", c => c.String());
            AddColumn("dbo.Users", "PaymentGiver", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Users", "StartGiver", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "EndGiver", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "PaymentGetter", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Users", "StartGetter", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "EndGetter", c => c.DateTime(nullable: false));
            CreateIndex("dbo.UsersPets", "User_ID");
            AddForeignKey("dbo.UsersPets", "User_ID", "dbo.Users", "ID");
            DropColumn("dbo.UsersPets", "Getter_ID");
            DropColumn("dbo.UsersPets", "Giver_ID");
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Users", "Surname");
            DropTable("dbo.Getters");
            DropTable("dbo.Givers");
            DropTable("dbo.GiverGetters");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GiverGetters",
                c => new
                    {
                        Giver_ID = c.Int(nullable: false),
                        Getter_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Giver_ID, t.Getter_ID });
            
            CreateTable(
                "dbo.Givers",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Payment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Getters",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Payment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Users", "Surname", c => c.String());
            AddColumn("dbo.Users", "Name", c => c.String());
            AddColumn("dbo.UsersPets", "Giver_ID", c => c.Int());
            AddColumn("dbo.UsersPets", "Getter_ID", c => c.Int());
            DropForeignKey("dbo.UsersPets", "User_ID", "dbo.Users");
            DropForeignKey("dbo.UserPets", "Pet_ID", "dbo.Pets");
            DropForeignKey("dbo.UserPets", "User_ID", "dbo.Users");
            DropIndex("dbo.UserPets", new[] { "Pet_ID" });
            DropIndex("dbo.UserPets", new[] { "User_ID" });
            DropIndex("dbo.UsersPets", new[] { "User_ID" });
            DropColumn("dbo.Users", "EndGetter");
            DropColumn("dbo.Users", "StartGetter");
            DropColumn("dbo.Users", "PaymentGetter");
            DropColumn("dbo.Users", "EndGiver");
            DropColumn("dbo.Users", "StartGiver");
            DropColumn("dbo.Users", "PaymentGiver");
            DropColumn("dbo.Users", "NameSurname");
            DropColumn("dbo.UsersPets", "User_ID");
            DropTable("dbo.UserPets");
            CreateIndex("dbo.GiverGetters", "Getter_ID");
            CreateIndex("dbo.GiverGetters", "Giver_ID");
            CreateIndex("dbo.UsersPets", "Giver_ID");
            CreateIndex("dbo.UsersPets", "Getter_ID");
            CreateIndex("dbo.Givers", "ID");
            CreateIndex("dbo.Getters", "ID");
            AddForeignKey("dbo.Givers", "ID", "dbo.Users", "ID");
            AddForeignKey("dbo.Getters", "ID", "dbo.Users", "ID");
            AddForeignKey("dbo.UsersPets", "Giver_ID", "dbo.Givers", "ID");
            AddForeignKey("dbo.UsersPets", "Getter_ID", "dbo.Getters", "ID");
            AddForeignKey("dbo.GiverGetters", "Getter_ID", "dbo.Getters", "ID", cascadeDelete: true);
            AddForeignKey("dbo.GiverGetters", "Giver_ID", "dbo.Givers", "ID", cascadeDelete: true);
        }
    }
}
