namespace LoginandRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clinics", "Facilities", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clinics", "Facilities");
        }
    }
}
