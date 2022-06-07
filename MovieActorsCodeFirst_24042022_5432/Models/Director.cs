using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieActorsCodeFirst_24042022_5432.Models
{
    public class Director :BaseClass
    {
        public Director()
        {
            Movies = new List<Movie>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        //navigationProp
        // çokça filmi olabilir

        public virtual List<Movie> Movies { get; set; }   // lazy loading
    }
}