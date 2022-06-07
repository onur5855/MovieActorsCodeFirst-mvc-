using MovieActorsCodeFirst_24042022_5432.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MovieActorsCodeFirst_24042022_5432.Mapping
{
    public class MovieMapping :EntityTypeConfiguration<Movie>
    {
        public MovieMapping()
        {
            HasKey(a=>a.ID);
            Property(a=>a.MovieName).HasMaxLength(80).IsRequired();
            HasRequired(a=>a.Director).WithMany(a=>a.Movies).HasForeignKey(a=>a.DirectorID);
        }
    }
}