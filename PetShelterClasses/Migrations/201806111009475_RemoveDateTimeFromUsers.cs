namespace PetShelterClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDateTimeFromUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsersPets", "Start", c => c.DateTime());
            AddColumn("dbo.UsersPets", "End", c => c.DateTime());
            DropColumn("dbo.Users", "StartGiver");
            DropColumn("dbo.Users", "EndGiver");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "EndGiver", c => c.DateTime());
            AddColumn("dbo.Users", "StartGiver", c => c.DateTime());
            DropColumn("dbo.UsersPets", "End");
            DropColumn("dbo.UsersPets", "Start");
        }
    }
}
