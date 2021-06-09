namespace LoginandRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointments", "ClinicName", c => c.String());
            AlterColumn("dbo.Appointments", "DoctorName", c => c.String());
            AlterColumn("dbo.Appointments", "ClinicCity", c => c.String());
            AlterColumn("dbo.Appointments", "PatientName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "PatientName", c => c.String(nullable: false));
            AlterColumn("dbo.Appointments", "ClinicCity", c => c.String(nullable: false));
            AlterColumn("dbo.Appointments", "DoctorName", c => c.String(nullable: false));
            AlterColumn("dbo.Appointments", "ClinicName", c => c.String(nullable: false));
        }
    }
}
