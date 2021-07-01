namespace LoginandRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dd : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.DoctorDetails", new[] { "Speciality_Id" });
            DropColumn("dbo.DoctorDetails", "Specialization");
            RenameColumn(table: "dbo.DoctorDetails", name: "Speciality_Id", newName: "Specialization");
            AlterColumn("dbo.DoctorDetails", "Specialization", c => c.Int());
            CreateIndex("dbo.DoctorDetails", "Specialization");
        }
        
        public override void Down()
        {
            DropIndex("dbo.DoctorDetails", new[] { "Specialization" });
            AlterColumn("dbo.DoctorDetails", "Specialization", c => c.String(nullable: false));
            RenameColumn(table: "dbo.DoctorDetails", name: "Specialization", newName: "Speciality_Id");
            AddColumn("dbo.DoctorDetails", "Specialization", c => c.String(nullable: false));
            CreateIndex("dbo.DoctorDetails", "Speciality_Id");
        }
    }
}
