namespace LoginandRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientName = c.String(),
                        Age = c.String(),
                        Gender = c.String(),
                        VisitDate = c.String(),
                        DoctorName = c.String(),
                        DoctorID = c.Int(nullable: false),
                        AppointmentId = c.Int(nullable: false),
                        DoctorSpecialization = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PatientTreatmentRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientName = c.String(nullable: false),
                        PatientId = c.Int(nullable: false),
                        Symptoms = c.String(nullable: false),
                        Diagnosis = c.String(nullable: false),
                        TreatmentPlanned = c.String(nullable: false),
                        Prescription = c.String(nullable: false),
                        RevisitRequired = c.String(),
                        NextRevisitDate = c.String(),
                        NextRevisitTime = c.String(),
                        FrequencyRevisit = c.Int(nullable: false),
                        DoctorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Gender", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Gender");
            DropTable("dbo.PatientTreatmentRecords");
            DropTable("dbo.PatientRecords");
        }
    }
}
