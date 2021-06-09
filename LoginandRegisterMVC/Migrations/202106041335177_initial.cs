namespace LoginandRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Clinics");
            DropPrimaryKey("dbo.DoctorDetails");
            AlterColumn("dbo.Clinics", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.DoctorDetails", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Clinics", "Id");
            AddPrimaryKey("dbo.DoctorDetails", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.DoctorDetails");
            DropPrimaryKey("dbo.Clinics");
            AlterColumn("dbo.DoctorDetails", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Clinics", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.DoctorDetails", "Id");
            AddPrimaryKey("dbo.Clinics", "Id");
        }
    }
}
