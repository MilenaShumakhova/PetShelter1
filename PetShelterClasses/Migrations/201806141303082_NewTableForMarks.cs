namespace PetShelterClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTableForMarks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Grade = c.Int(nullable: false),
                        RatedUser_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.RatedUser_ID)
                .Index(t => t.RatedUser_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Marks", "RatedUser_ID", "dbo.Users");
            DropIndex("dbo.Marks", new[] { "RatedUser_ID" });
            DropTable("dbo.Marks");
        }
    }
}
