using G_MovieStoreMVC.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace G_MovieStoreMVC.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>

    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MovieGenre>().HasKey(e => new
            {
                e.MovieId,
                e.GenreId
            });

            //modelBuilder.Entity<Movie>()
            //  .HasOne(m => m.Director)
            //  .WithMany(d => d.Movies)
            //  .HasForeignKey(m => m.DirectorId);

            // Seed movies
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, GenreName = "Action" },
                new Genre { Id = 2, GenreName = "Drama" },
                new Genre { Id = 3, GenreName = "Comedy" },
                new Genre { Id = 4, GenreName = "Horror" },
                new Genre { Id = 5, GenreName = "Science Fiction" }
            );

            // Seed movies
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "The Matrix",
                    ReleaseYear = "1999",
                    ImageURL = "matrix.jpg",
                    Cast = "Keanu Reeves, Laurence Fishburne",
                    Director = "The Wachowskis",
                    GenreNames = "Science Fiction, Action" // For display purposes (comma-separated)
                },
                new Movie
                {
                    Id = 2,
                    Title = "Inception",
                    ReleaseYear = "2010",
                    ImageURL = "inception.jpg",
                    Cast = "Leonardo DiCaprio, Joseph Gordon-Levitt",
                    Director = "Christopher Nolan",
                    GenreNames = "Science Fiction, Action"
                },
                new Movie
                {
                    Id = 3,
                    Title = "The Godfather",
                    ReleaseYear = "1972",
                    ImageURL = "godfather.jpg",
                    Cast = "Marlon Brando, Al Pacino",
                    Director = "Francis Ford Coppola",
                    GenreNames = "Drama"
                }
            );

            // Seed movie genres (associations)
            modelBuilder.Entity<MovieGenre>().HasData(
                new MovieGenre { Id = 1, MovieId = 1, GenreId = 5 }, // The Matrix - Science Fiction
                new MovieGenre { Id = 2, MovieId = 1, GenreId = 1 }, // The Matrix - Action
                new MovieGenre { Id = 3, MovieId = 2, GenreId = 5 }, // Inception - Science Fiction
                new MovieGenre { Id = 4, MovieId = 2, GenreId = 1 }, // Inception - Action
                new MovieGenre { Id = 5, MovieId = 3, GenreId = 2 }  // The Godfather - Drama
            );
        }
    
        public DbSet<Director> Director { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenre { get; set; }


    }
}
