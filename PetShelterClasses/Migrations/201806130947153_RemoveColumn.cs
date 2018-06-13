namespace PetShelterClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GetterRequests", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GetterRequests", "Type", c => c.String());
        }
    }
}
