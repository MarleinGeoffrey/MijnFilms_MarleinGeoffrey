using System;
using System.Collections.Generic;

namespace MijnFilms_MarleinGeoffrey.Entities
{
    public partial class Person
    {
        public Person()
        {
            Movie = new HashSet<Movie>();
            MovieActor = new HashSet<MovieActor>();
        }

        public int PersonId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public ICollection<Movie> Movie { get; set; }
        public ICollection<MovieActor> MovieActor { get; set; }
    }
}
