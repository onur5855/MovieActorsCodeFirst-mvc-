using MovieActorsCodeFirst_24042022_5432.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MovieActorsCodeFirst_24042022_5432.Mapping
{
    public class MovieActorsMapping: EntityTypeConfiguration<MovieActors>
    {
        public MovieActorsMapping()
        {
            HasKey(a=> new {a.ActorID,a.MovieID});  // hem foreignKey hem primaryKey => composite key
        }
    }
}