namespace LoginandRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial10 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clinics", "Facilities");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clinics", "Facilities", c => c.String(nullable: false));
        }
    }
}
