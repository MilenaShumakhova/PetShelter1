namespace PetShelterClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewColumn1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Rating", c => c.Double(nullable: false));
            DropColumn("dbo.Marks", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Marks", "Rating", c => c.Double(nullable: false));
            DropColumn("dbo.Users", "Rating");
        }
    }
}
