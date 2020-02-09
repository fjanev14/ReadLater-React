namespace ReadLater.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_of_models : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserBookmark1",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        BookmarkId = c.Int(),
                        NumberOfClicks = c.Int(nullable: false),
                        DateClicked = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Bookmarks", t => t.BookmarkId)
                .Index(t => t.BookmarkId);
            
            CreateTable(
                "dbo.UserFriendBookmark1",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        BookmarkId = c.Int(),
                        DateSend = c.DateTime(nullable: false),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Bookmarks", t => t.BookmarkId)
                .Index(t => t.BookmarkId);
            
            DropTable("dbo.TestEntities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TestEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.UserFriendBookmark1", "BookmarkId", "dbo.Bookmarks");
            DropForeignKey("dbo.UserBookmark1", "BookmarkId", "dbo.Bookmarks");
            DropIndex("dbo.UserFriendBookmark1", new[] { "BookmarkId" });
            DropIndex("dbo.UserBookmark1", new[] { "BookmarkId" });
            DropTable("dbo.UserFriendBookmark1");
            DropTable("dbo.UserBookmark1");
        }
    }
}
