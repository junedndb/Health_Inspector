namespace LoginandRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initanmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClinicFacilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FacilityName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Appointments", "TimeOfAppointment", c => c.String(nullable: false));
            AddColumn("dbo.Clinics", "Specialization", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clinics", "Specialization");
            DropColumn("dbo.Appointments", "TimeOfAppointment");
            DropTable("dbo.ClinicFacilities");
        }
    }
}
