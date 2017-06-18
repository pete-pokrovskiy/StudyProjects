namespace GettingStartedEF6.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailImportanceToEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Emails", "EmailImportance", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Emails", "EmailImportance");
        }
    }
}
