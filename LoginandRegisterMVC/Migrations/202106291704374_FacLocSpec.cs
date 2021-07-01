namespace LoginandRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FacLocSpec : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Localities",
                c => new
                    {
                        LocalityId = c.Int(nullable: false, identity: true),
                        Locality_name = c.String(),
                    })
                .PrimaryKey(t => t.LocalityId);
            
            CreateTable(
                "dbo.Specialities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Speciality_name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ClinicFacilities", "Service", c => c.String());
            AddColumn("dbo.ClinicFacilities", "Isselected", c => c.Boolean(nullable: false));
            AddColumn("dbo.Clinics", "Services", c => c.String(nullable: false));
            AddColumn("dbo.Clinics", "LocalityId", c => c.Int());
            AddColumn("dbo.DoctorDetails", "Speciality_Id", c => c.Int());
            AddColumn("dbo.PatientRecords", "Speciality_Id", c => c.Int());
            AlterColumn("dbo.Clinics", "Specialization", c => c.Int(nullable: false));
            CreateIndex("dbo.Clinics", "Specialization");
            CreateIndex("dbo.Clinics", "LocalityId");
            CreateIndex("dbo.DoctorDetails", "Speciality_Id");
            CreateIndex("dbo.PatientRecords", "Speciality_Id");
            AddForeignKey("dbo.Clinics", "LocalityId", "dbo.Localities", "LocalityId");
            AddForeignKey("dbo.Clinics", "Specialization", "dbo.Specialities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DoctorDetails", "Speciality_Id", "dbo.Specialities", "Id");
            AddForeignKey("dbo.PatientRecords", "Speciality_Id", "dbo.Specialities", "Id");
            DropColumn("dbo.ClinicFacilities", "FacilityName");
            DropColumn("dbo.Clinics", "Facilities");
            DropColumn("dbo.Clinics", "ClinicTiming");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clinics", "ClinicTiming", c => c.String(nullable: false));
            AddColumn("dbo.Clinics", "Facilities", c => c.String(nullable: false));
            AddColumn("dbo.ClinicFacilities", "FacilityName", c => c.String());
            DropForeignKey("dbo.PatientRecords", "Speciality_Id", "dbo.Specialities");
            DropForeignKey("dbo.DoctorDetails", "Speciality_Id", "dbo.Specialities");
            DropForeignKey("dbo.Clinics", "Specialization", "dbo.Specialities");
            DropForeignKey("dbo.Clinics", "LocalityId", "dbo.Localities");
            DropIndex("dbo.PatientRecords", new[] { "Speciality_Id" });
            DropIndex("dbo.DoctorDetails", new[] { "Speciality_Id" });
            DropIndex("dbo.Clinics", new[] { "LocalityId" });
            DropIndex("dbo.Clinics", new[] { "Specialization" });
            AlterColumn("dbo.Clinics", "Specialization", c => c.String(nullable: false));
            DropColumn("dbo.PatientRecords", "Speciality_Id");
            DropColumn("dbo.DoctorDetails", "Speciality_Id");
            DropColumn("dbo.Clinics", "LocalityId");
            DropColumn("dbo.Clinics", "Services");
            DropColumn("dbo.ClinicFacilities", "Isselected");
            DropColumn("dbo.ClinicFacilities", "Service");
            DropTable("dbo.Specialities");
            DropTable("dbo.Localities");
        }
    }
}
