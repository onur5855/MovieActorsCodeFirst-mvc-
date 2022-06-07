using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieActorsCodeFirst_24042022_5432.Models
{
    public class Actor : BaseClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        // navigationProp 
        // 1 oyuncunun çokça fimi olabilir. Bu yüzden ara tablo oluşacak ve kendi üzerinde ara tablo elemanlarını tutacak.
        public virtual List<MovieActors> MovieActors { get; set; }
    }
}