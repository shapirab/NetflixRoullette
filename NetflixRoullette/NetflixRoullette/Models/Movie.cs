using System;
using System.Collections.Generic;
using System.Text;

namespace NetflixRoullette.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CoverUrl { get; set; }
        List<Actor> Actors { get; set; }
    }
}
