namespace GettingStartedEF6.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity:true, defaultValueSql: "newsequentialid()"),
                        FileName = c.String(),
                        FileSize = c.Double(nullable: false),
                        FileType = c.Int(nullable: false),
                        EmailId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Emails", t => t.EmailId, cascadeDelete: true)
                .Index(t => t.EmailId);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        Subject = c.String(),
                        Body = c.String(),
                        AuthorId = c.Guid(nullable: false),
                        ToStr = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        Name = c.String(),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Emails", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.Attachments", "EmailId", "dbo.Emails");
            DropIndex("dbo.Emails", new[] { "AuthorId" });
            DropIndex("dbo.Attachments", new[] { "EmailId" });
            DropTable("dbo.Users");
            DropTable("dbo.Emails");
            DropTable("dbo.Attachments");
        }
    }
}
