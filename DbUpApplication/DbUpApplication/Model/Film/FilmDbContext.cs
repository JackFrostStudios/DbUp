using System.Data.Entity;

namespace DbUpApplication.Model
{
    public class FilmDbContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmRating> FilmRatings { get; set; }
        public DbSet<Actor> Actors { get; set; }

        public FilmDbContext(string connectionStringName)
            : base(connectionStringName)
        {
            Database.SetInitializer<FilmDbContext>(null);
        }

        public FilmDbContext()
        {
            
        }
    }
}