namespace LoginandRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Completed", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "Completed");
        }
    }
}
