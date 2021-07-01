namespace LoginandRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FeedbackQuestions", "Question", c => c.String());
            DropColumn("dbo.FeedbackQuestions", "FeedBackQuestion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FeedbackQuestions", "FeedBackQuestion", c => c.String());
            DropColumn("dbo.FeedbackQuestions", "Question");
        }
    }
}
