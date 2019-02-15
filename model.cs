using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab6
{
    public class MovieContext : DbContext // ":" means inheritance
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = database.db");
        }

        public DbSet<Movie> Movies {get; set;}
        public DbSet<Studio> Studios {get; set;}
    }    
        
    public class Studio
    {
        public int StudioId {get; set;}
        public string Name {get; set;}

        public List<Movie> Movies {get; set;}

        public override string ToString()
        {
            return $"Studio: {Name}";
        }
    }
    public class Movie
    {
        public int MovieID {get; set;}
        public string Title {get; set;}
        public string Genre {get; set;}
        public int StudioId {get; set;}
        public Studio Studio {get; set;}

        public override string ToString()
        {
            return $"Movie: {Title}\tGenre: {Genre}";
        }
    }



}