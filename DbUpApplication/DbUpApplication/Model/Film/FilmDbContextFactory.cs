using System.Data.Entity.Infrastructure;

namespace DbUpApplication.Model
{
    public class FilmDbContextFactory : IDbContextFactory<FilmDbContext>
    {
        public FilmDbContext Create()
        {
            return new FilmDbContext("FilmDb");
        }
    }
}