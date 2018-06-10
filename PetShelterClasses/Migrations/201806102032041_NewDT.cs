namespace PetShelterClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDT : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "StartGiver", c => c.DateTime());
            AlterColumn("dbo.Users", "EndGiver", c => c.DateTime());
            AlterColumn("dbo.Users", "StartGetter", c => c.DateTime());
            AlterColumn("dbo.Users", "EndGetter", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "EndGetter", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "StartGetter", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "EndGiver", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "StartGiver", c => c.DateTime(nullable: false));
        }
    }
}
