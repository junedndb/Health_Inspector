namespace LoginandRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clinics", "AddressSLine");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clinics", "AddressSLine", c => c.String(nullable: false));
        }
    }
}
