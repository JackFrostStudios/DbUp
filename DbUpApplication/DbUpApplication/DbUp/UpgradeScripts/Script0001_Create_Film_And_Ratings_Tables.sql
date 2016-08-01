CREATE TABLE dbo.Films
(
	FilmId uniqueidentifier NOT NULL,
	Name nvarchar(max),
	Description nvarchar(max)
	CONSTRAINT "PK_dbo.Films" PRIMARY KEY (FilmId)
)

CREATE TABLE dbo.FilmRatings
(
	FilmRatingId uniqueidentifier NOT NULL,
	Rating int NOT NULL,
	Comment nvarchar(max),
	FilmId uniqueidentifier NOT NULL
	CONSTRAINT "PK_dbo.FilmRatings" PRIMARY KEY (FilmRatingId)
	CONSTRAINT "FK_dbo.FilmRatings_dbo.Films_FilmId" FOREIGN KEY (FilmId) REFERENCES dbo.Films (FilmId) ON DELETE CASCADE
)

CREATE INDEX IX_FilmId ON dbo.FilmRatings (FilmId)