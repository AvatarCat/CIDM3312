using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MovieContext())
            {
                // Useful tactic ONLY in development.
                // At start of your program, always delete the database and then re-create it
                // This ensures a fresh database everytime you run your program.
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
            
            // Adding a studio: "20th Century Fox" with 4 movies
            using (var db = new MovieContext())
            {
                Studio studio = new Studio
                {
                    Name = "20th Century Fox",
                    Movies = new List<Movie>
                    {
                        new Movie {Title = "Avatar", Genre = "Action"},
                        new Movie {Title = "Deadpool", Genre = "Action"},
                        new Movie {Title = "Apollo 13", Genre = "Drama"},
                        new Movie {Title = "The Martian", Genre = "Sci-Fi"}
                    }
                };

                // Adding a studio: "Universal Pictures" with no movies
                Studio studio2 = new Studio
                {
                    Name = "Universal Pictures"
                };

                db.Add(studio);
                db.Add(studio2);
                db.SaveChanges();
            }

            // Adding a movie: "Jurassic Park" to the Universal Pictures Studio
            using (var db = new MovieContext())
            {
                Movie movie = new Movie
                {
                    Title = "Jurassic Park", Genre = "Action"
                };
                
                Studio studioToUpdate = db.Studios.Include(s => s.Movies).Where(s => s.StudioId == 2).First();
                studioToUpdate.M.Add(movie);
                db.SaveChanges();
            }
        }
    }
}
