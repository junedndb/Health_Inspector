namespace LoginandRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial9 : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClinicFacilities");
        }
    }
}
