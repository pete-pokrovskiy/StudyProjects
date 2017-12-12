namespace GettingStartedEF6.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModificationHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attachments", "DateModified", c => c.DateTime(nullable: false,  defaultValue: DateTime.Parse("1900-01-01 00:00:00")));
            AddColumn("dbo.Attachments", "DateCreated", c => c.DateTime(nullable: false, defaultValue: DateTime.Parse("1900-01-01 00:00:00")));
            AddColumn("dbo.Emails", "DateModified", c => c.DateTime(nullable: false, defaultValue: DateTime.Parse("1900-01-01 00:00:00")));
            AddColumn("dbo.Emails", "DateCreated", c => c.DateTime(nullable: false, defaultValue: DateTime.Parse("1900-01-01 00:00:00")));
            AddColumn("dbo.Users", "DateModified", c => c.DateTime(nullable: false, defaultValue: DateTime.Parse("1900-01-01 00:00:00")));
            AddColumn("dbo.Users", "DateCreated", c => c.DateTime(nullable: false, defaultValue: DateTime.Parse("1900-01-01 00:00:00")));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "DateCreated");
            DropColumn("dbo.Users", "DateModified");
            DropColumn("dbo.Emails", "DateCreated");
            DropColumn("dbo.Emails", "DateModified");
            DropColumn("dbo.Attachments", "DateCreated");
            DropColumn("dbo.Attachments", "DateModified");
        }
    }
}
