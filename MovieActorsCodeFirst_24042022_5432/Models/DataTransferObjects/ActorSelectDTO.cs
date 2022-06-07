using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieActorsCodeFirst_24042022_5432.Models.DataTransferObjects
{
    public class ActorSelectDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName { get => FirstName + " " + LastName; }

        public int ID { get; set; }

        public bool IsSelected { get; set; }
    }
}