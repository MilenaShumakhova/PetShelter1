namespace PetShelterClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewColumnInGetterRequests : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GetterRequests", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GetterRequests", "Type");
        }
    }
}
