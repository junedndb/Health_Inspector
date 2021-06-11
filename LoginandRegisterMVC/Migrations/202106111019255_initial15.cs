namespace LoginandRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clinics", "Specialization", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clinics", "Specialization");
        }
    }
}
