using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieActorsCodeFirst_24042022_5432.Models
{
    public class BaseClass
    {
        public int ID { get; set; }

        public bool IsActive { get; set; } = true;
    }
}