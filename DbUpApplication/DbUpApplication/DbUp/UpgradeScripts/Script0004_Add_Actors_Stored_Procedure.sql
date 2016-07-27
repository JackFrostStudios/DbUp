CREATE PROCEDURE GetAllActorsForFilm
@FilmId uniqueidentifier
AS
    SELECT
        a.ActorId,
        a.Name
    FROM dbo.Actors a
    JOIN dbo.FilmActors b ON a.ActorId = b.Actor_ActorId
    JOIN dbo.Films c ON b.Film_FilmId = c.FilmId
	WHERE c.FilmId = @FilmId
GO