using System;
using System.Collections;
using System.Collections.Generic;

namespace DbUpApplication.Model
{
    public class Actor
    {
        public Guid ActorId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Film> Films { get; set; }

        public Actor()
        {
            ActorId = Guid.NewGuid();
            Films = new HashSet<Film>();
        }
    }
}