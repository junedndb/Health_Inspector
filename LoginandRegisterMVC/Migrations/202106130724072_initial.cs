namespace LoginandRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BMIs",
                c => new
                    {
                        BMIId = c.Int(nullable: false, identity: true),
                        Height = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        UserId = c.Int(nullable: false),
                        BMIResult = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.BMIId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.DietRecommendations",
                c => new
                    {
                        DietRecommendationId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Recommendation = c.String(),
                    })
                .PrimaryKey(t => t.DietRecommendationId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.FeedbackQuestions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        FeedBackQuestion = c.String(),
                    })
                .PrimaryKey(t => t.QuestionId);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        FeedbackId = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.FeedbackId)
                .ForeignKey("dbo.FeedbackQuestions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.QuestionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Helps",
                c => new
                    {
                        HelpId = c.Int(nullable: false, identity: true),
                        Issue = c.String(),
                        UserId = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.HelpId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ResolveHelps",
                c => new
                    {
                        ResolveId = c.Int(nullable: false, identity: true),
                        HelpId = c.Int(nullable: false),
                        ResolveAnswer = c.String(),
                    })
                .PrimaryKey(t => t.ResolveId)
                .ForeignKey("dbo.Helps", t => t.HelpId, cascadeDelete: true)
                .Index(t => t.HelpId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResolveHelps", "HelpId", "dbo.Helps");
            DropForeignKey("dbo.Helps", "UserId", "dbo.Users");
            DropForeignKey("dbo.Feedbacks", "UserId", "dbo.Users");
            DropForeignKey("dbo.Feedbacks", "QuestionId", "dbo.FeedbackQuestions");
            DropForeignKey("dbo.DietRecommendations", "UserId", "dbo.Users");
            DropForeignKey("dbo.BMIs", "UserId", "dbo.Users");
            DropIndex("dbo.ResolveHelps", new[] { "HelpId" });
            DropIndex("dbo.Helps", new[] { "UserId" });
            DropIndex("dbo.Feedbacks", new[] { "UserId" });
            DropIndex("dbo.Feedbacks", new[] { "QuestionId" });
            DropIndex("dbo.DietRecommendations", new[] { "UserId" });
            DropIndex("dbo.BMIs", new[] { "UserId" });
            DropTable("dbo.ResolveHelps");
            DropTable("dbo.Helps");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.FeedbackQuestions");
            DropTable("dbo.DietRecommendations");
            DropTable("dbo.BMIs");
        }
    }
}
