namespace PetShelterClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTypeOfPayment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "PaymentGiver", c => c.Double(nullable: false));
            AlterColumn("dbo.Users", "PaymentGetter", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "PaymentGetter", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Users", "PaymentGiver", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
