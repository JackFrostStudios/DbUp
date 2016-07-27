using System;

namespace DbUpApplication.Model
{
    public class Film
    {
        public Guid FilmId { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }

        public Film()
        {
            FilmId = Guid.NewGuid();
        }
    }
}