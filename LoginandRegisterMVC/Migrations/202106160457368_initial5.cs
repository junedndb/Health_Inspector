namespace LoginandRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial5 : DbMigration
    {
        public override void Up()
        {
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
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PatientTreatmentRecords");
        }
    }
}
