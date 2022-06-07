using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieActorsCodeFirst_24042022_5432.Models
{
    public class MovieActors
    {
        public int MovieID { get; set; }

        public virtual Movie Movie { get; set; }

        public int ActorID { get; set; }

        public virtual Actor Actor { get; set; }
    }
}