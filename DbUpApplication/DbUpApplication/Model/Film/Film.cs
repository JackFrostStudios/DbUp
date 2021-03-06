﻿using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DbUpApplication.Model
{
    public class Film
    {
        public Guid FilmId { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }

        public Film()
        {
            FilmId = Guid.NewGuid();
            Actors = new HashSet<Actor>();
        }
    }
}