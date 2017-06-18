namespace GettingStartedEF6.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefaultIds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attachments", "EmailId", "dbo.Emails");
            DropForeignKey("dbo.Emails", "AuthorId", "dbo.Users");
            DropPrimaryKey("dbo.Attachments");
            DropPrimaryKey("dbo.Emails");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Attachments", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Emails", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Users", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Attachments", "Id");
            AddPrimaryKey("dbo.Emails", "Id");
            AddPrimaryKey("dbo.Users", "Id");
            AddForeignKey("dbo.Attachments", "EmailId", "dbo.Emails", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Emails", "AuthorId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Emails", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.Attachments", "EmailId", "dbo.Emails");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Emails");
            DropPrimaryKey("dbo.Attachments");
            AlterColumn("dbo.Users", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Emails", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Attachments", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.Emails", "Id");
            AddPrimaryKey("dbo.Attachments", "Id");
            AddForeignKey("dbo.Emails", "AuthorId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Attachments", "EmailId", "dbo.Emails", "Id", cascadeDelete: true);
        }
    }
}
