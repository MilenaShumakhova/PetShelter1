namespace PetShelterClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Marks", "Rating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Marks", "Rating");
        }
    }
}
