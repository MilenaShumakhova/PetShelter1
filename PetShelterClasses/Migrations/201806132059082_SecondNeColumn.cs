namespace PetShelterClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondNeColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GetterRequests", "StatusGiver", c => c.String());
            AddColumn("dbo.GetterRequests", "StatusGetter", c => c.String());
            DropColumn("dbo.GetterRequests", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GetterRequests", "Status", c => c.String());
            DropColumn("dbo.GetterRequests", "StatusGetter");
            DropColumn("dbo.GetterRequests", "StatusGiver");
        }
    }
}
