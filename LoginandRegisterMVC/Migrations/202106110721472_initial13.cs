namespace LoginandRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial13 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clinics", "Facilities", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clinics", "Facilities", c => c.Boolean(nullable: false));
        }
    }
}
