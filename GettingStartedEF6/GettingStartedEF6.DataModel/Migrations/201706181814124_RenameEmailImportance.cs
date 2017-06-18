namespace GettingStartedEF6.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameEmailImportance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Emails", "Importance", c => c.Int(nullable: false));
            DropColumn("dbo.Emails", "EmailImportance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Emails", "EmailImportance", c => c.Int(nullable: false));
            DropColumn("dbo.Emails", "Importance");
        }
    }
}
