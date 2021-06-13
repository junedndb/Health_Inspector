namespace LoginandRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DietRecommendations", "User_UserId", "dbo.Users");
            DropIndex("dbo.DietRecommendations", new[] { "User_UserId" });
            DropColumn("dbo.DietRecommendations", "UserId");
            RenameColumn(table: "dbo.DietRecommendations", name: "User_UserId", newName: "UserId");
            AlterColumn("dbo.DietRecommendations", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.DietRecommendations", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.DietRecommendations", "UserId");
            AddForeignKey("dbo.DietRecommendations", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DietRecommendations", "UserId", "dbo.Users");
            DropIndex("dbo.DietRecommendations", new[] { "UserId" });
            AlterColumn("dbo.DietRecommendations", "UserId", c => c.Int());
            AlterColumn("dbo.DietRecommendations", "UserId", c => c.String());
            RenameColumn(table: "dbo.DietRecommendations", name: "UserId", newName: "User_UserId");
            AddColumn("dbo.DietRecommendations", "UserId", c => c.String());
            CreateIndex("dbo.DietRecommendations", "User_UserId");
            AddForeignKey("dbo.DietRecommendations", "User_UserId", "dbo.Users", "UserId");
        }
    }
}
