namespace PetShelterClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewColumnInGetterRequests1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GetterRequests", "Status", c => c.String());
            DropColumn("dbo.UsersPets", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsersPets", "Status", c => c.String());
            DropColumn("dbo.GetterRequests", "Status");
        }
    }
}
