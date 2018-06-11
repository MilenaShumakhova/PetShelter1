namespace PetShelterClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentGiver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsersPets", "Payment", c => c.Double(nullable: false));
            DropColumn("dbo.Users", "PaymentGiver");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "PaymentGiver", c => c.Double(nullable: false));
            DropColumn("dbo.UsersPets", "Payment");
        }
    }
}
