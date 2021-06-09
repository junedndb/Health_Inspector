namespace LoginandRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial6 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Appointments");
            AlterColumn("dbo.Appointments", "AppointmentId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Appointments", "AppointmentId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Appointments");
            AlterColumn("dbo.Appointments", "AppointmentId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Appointments", "AppointmentId");
        }
    }
}
