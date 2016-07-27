using System;

namespace DbUpApplication.Model
{
    public class FilmRating
    {
        public Guid FilmRatingId { get; private set; }
        public int Rating { get; set; }

        public string Comment { get; set; }

        public Guid FilmId { get; set; }
        public virtual Film Film { get; set; }

        public FilmRating()
        {
            FilmRatingId = Guid.NewGuid();
        }
    }
}