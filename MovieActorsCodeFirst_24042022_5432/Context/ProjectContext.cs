using MovieActorsCodeFirst_24042022_5432.Mapping;
using MovieActorsCodeFirst_24042022_5432.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieActorsCodeFirst_24042022_5432.Context
{
    public class ProjectContext :DbContext

    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "Server=DESKTOP-95JR298;Database=MovieDb99;Trusted_Connection=True;";
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }

        public DbSet<MovieActors> MovieActors { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MovieMapping());
            modelBuilder.Configurations.Add(new MovieActorsMapping());
            base.OnModelCreating(modelBuilder);
        }


    }
}