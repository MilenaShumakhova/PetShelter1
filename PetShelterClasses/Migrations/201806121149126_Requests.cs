namespace PetShelterClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Requests : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsersPets", "User_ID", "dbo.Users");
            AddColumn("dbo.UsersPets", "Getter_ID", c => c.Int());
            AddColumn("dbo.UsersPets", "User_ID1", c => c.Int());
            CreateIndex("dbo.UsersPets", "Getter_ID");
            CreateIndex("dbo.UsersPets", "User_ID1");
            AddForeignKey("dbo.UsersPets", "Getter_ID", "dbo.Users", "ID");
            AddForeignKey("dbo.UsersPets", "User_ID1", "dbo.Users", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersPets", "User_ID1", "dbo.Users");
            DropForeignKey("dbo.UsersPets", "Getter_ID", "dbo.Users");
            DropIndex("dbo.UsersPets", new[] { "User_ID1" });
            DropIndex("dbo.UsersPets", new[] { "Getter_ID" });
            DropColumn("dbo.UsersPets", "User_ID1");
            DropColumn("dbo.UsersPets", "Getter_ID");
            AddForeignKey("dbo.UsersPets", "User_ID", "dbo.Users", "ID");
        }
    }
}
