namespace LoginandRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DoctorDetails", "DoctorId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DoctorDetails", "DoctorId");
        }
    }
}
