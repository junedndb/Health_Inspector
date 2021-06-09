namespace LoginandRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Fque", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Sque", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Tque", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Tque");
            DropColumn("dbo.Users", "Sque");
            DropColumn("dbo.Users", "Fque");
        }
    }
}
