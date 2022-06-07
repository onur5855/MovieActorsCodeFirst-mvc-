using System;
using System.Collections.Generic;

namespace MovieActorsCodeFirst_24042022_5432.Models
{
    public class Movie :BaseClass
    {
        public string MovieName { get; set; }
        public DateTime? PublishDate { get; set; }

        // navigation prop
        // 1 filmin 1 yönetmeni olur.

        public int DirectorID { get; set; }
        public virtual Director Director { get; set; }

        // 1 filmin çokça oyuncusu
        public virtual  List<MovieActors> MovieActors { get; set; }
    }
}