using System;
using System.Collections.Generic;

namespace MijnFilms_MarleinGeoffrey.Entities
{
    public partial class Genre
    {
        public Genre()
        {
            Movie = new HashSet<Movie>();
        }

        public int GenreId { get; set; }
        public string Description { get; set; }

        public ICollection<Movie> Movie { get; set; }
    }
}
