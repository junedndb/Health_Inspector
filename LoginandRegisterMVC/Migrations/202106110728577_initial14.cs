namespace LoginandRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "TimeOfAppointment", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "TimeOfAppointment");
        }
    }
}
