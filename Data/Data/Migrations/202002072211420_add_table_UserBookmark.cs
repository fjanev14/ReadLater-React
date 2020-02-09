namespace ReadLater.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table_UserBookmark : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserBookmarks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        BookmarkId = c.Int(),
                        NumberOfClicks = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Bookmarks", t => t.BookmarkId)
                .Index(t => t.BookmarkId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserBookmarks", "BookmarkId", "dbo.Bookmarks");
            DropIndex("dbo.UserBookmarks", new[] { "BookmarkId" });
            DropTable("dbo.UserBookmarks");
        }
    }
}
