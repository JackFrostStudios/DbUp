CREATE TABLE dbo.Actors
(
	ActorId uniqueidentifier NOT NULL,
	Name nvarchar(max),
	CONSTRAINT "PK_dbo.Actors" PRIMARY KEY (ActorId)
)

CREATE TABLE dbo.FilmActors
(
	Film_FilmId uniqueidentifier NOT NULL,
	Actor_ActorId uniqueidentifier NOT NULL,
	CONSTRAINT "PK_dbo.FilmActors" PRIMARY KEY (Film_FilmId, Actor_ActorId),
    CONSTRAINT "FK_dbo.FilmActors_dbo.Actors_Actor_ActorId" FOREIGN KEY (Actor_ActorId) REFERENCES dbo.Actors (ActorId),
    CONSTRAINT "FK_dbo.FilmActors_dbo.Films_Film_FilmId" FOREIGN KEY (Film_FilmId) REFERENCES dbo.Films (FilmId)
    
)