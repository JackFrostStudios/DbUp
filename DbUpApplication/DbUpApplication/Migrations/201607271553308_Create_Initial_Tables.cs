namespace DbUpApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Initial_Tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FilmRatings",
                c => new
                    {
                        FilmRatingId = c.Guid(nullable: false),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(),
                        FilmId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.FilmRatingId)
                .ForeignKey("dbo.Films", t => t.FilmId, cascadeDelete: true)
                .Index(t => t.FilmId);
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        FilmId = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.FilmId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilmRatings", "FilmId", "dbo.Films");
            DropIndex("dbo.FilmRatings", new[] { "FilmId" });
            DropTable("dbo.Films");
            DropTable("dbo.FilmRatings");
        }
    }
}
