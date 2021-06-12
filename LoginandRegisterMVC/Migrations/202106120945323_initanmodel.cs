namespace LoginandRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initanmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BMIs", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.DietRecommendations", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Feedbacks", "QuestionId", "dbo.FeedbackQuestions");
            DropForeignKey("dbo.Feedbacks", "UserId", "dbo.Users");
            DropForeignKey("dbo.Helps", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.ResolveHelps", "HelpId", "dbo.Helps");
            DropIndex("dbo.BMIs", new[] { "User_UserId" });
            DropIndex("dbo.DietRecommendations", new[] { "User_UserId" });
            DropIndex("dbo.Feedbacks", new[] { "QuestionId" });
            DropIndex("dbo.Feedbacks", new[] { "UserId" });
            DropIndex("dbo.Helps", new[] { "User_UserId" });
            DropIndex("dbo.ResolveHelps", new[] { "HelpId" });
            DropTable("dbo.BMIs");
            DropTable("dbo.DietRecommendations");
            DropTable("dbo.FeedbackQuestions");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Helps");
            DropTable("dbo.ResolveHelps");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ResolveHelps",
                c => new
                    {
                        ResolveId = c.Int(nullable: false, identity: true),
                        HelpId = c.Int(nullable: false),
                        ResolveAnswer = c.String(),
                    })
                .PrimaryKey(t => t.ResolveId);
            
            CreateTable(
                "dbo.Helps",
                c => new
                    {
                        HelpId = c.Int(nullable: false, identity: true),
                        Issue = c.String(),
                        UserId = c.String(),
                        Description = c.String(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.HelpId);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        FeedbackId = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.FeedbackId);
            
            CreateTable(
                "dbo.FeedbackQuestions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        FeedBackQuestion = c.String(),
                    })
                .PrimaryKey(t => t.QuestionId);
            
            CreateTable(
                "dbo.DietRecommendations",
                c => new
                    {
                        DietRecommendationId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Recommendation = c.String(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.DietRecommendationId);
            
            CreateTable(
                "dbo.BMIs",
                c => new
                    {
                        BMIId = c.Int(nullable: false, identity: true),
                        Height = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        UserId = c.String(),
                        BMIResult = c.Double(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.BMIId);
            
            CreateIndex("dbo.ResolveHelps", "HelpId");
            CreateIndex("dbo.Helps", "User_UserId");
            CreateIndex("dbo.Feedbacks", "UserId");
            CreateIndex("dbo.Feedbacks", "QuestionId");
            CreateIndex("dbo.DietRecommendations", "User_UserId");
            CreateIndex("dbo.BMIs", "User_UserId");
            AddForeignKey("dbo.ResolveHelps", "HelpId", "dbo.Helps", "HelpId", cascadeDelete: true);
            AddForeignKey("dbo.Helps", "User_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.Feedbacks", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Feedbacks", "QuestionId", "dbo.FeedbackQuestions", "QuestionId", cascadeDelete: true);
            AddForeignKey("dbo.DietRecommendations", "User_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.BMIs", "User_UserId", "dbo.Users", "UserId");
        }
    }
}
