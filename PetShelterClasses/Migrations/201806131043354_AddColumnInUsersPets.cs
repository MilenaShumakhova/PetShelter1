namespace PetShelterClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnInUsersPets : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsersPets", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UsersPets", "Status");
        }
    }
}
