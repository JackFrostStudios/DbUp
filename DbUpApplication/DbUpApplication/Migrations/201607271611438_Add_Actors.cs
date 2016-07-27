namespace DbUpApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Actors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        ActorId = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ActorId);
            
            CreateTable(
                "dbo.FilmActors",
                c => new
                    {
                        Film_FilmId = c.Guid(nullable: false),
                        Actor_ActorId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Film_FilmId, t.Actor_ActorId })
                .ForeignKey("dbo.Films", t => t.Film_FilmId, cascadeDelete: true)
                .ForeignKey("dbo.Actors", t => t.Actor_ActorId, cascadeDelete: true)
                .Index(t => t.Film_FilmId)
                .Index(t => t.Actor_ActorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilmActors", "Actor_ActorId", "dbo.Actors");
            DropForeignKey("dbo.FilmActors", "Film_FilmId", "dbo.Films");
            DropIndex("dbo.FilmActors", new[] { "Actor_ActorId" });
            DropIndex("dbo.FilmActors", new[] { "Film_FilmId" });
            DropTable("dbo.FilmActors");
            DropTable("dbo.Actors");
        }
    }
}
