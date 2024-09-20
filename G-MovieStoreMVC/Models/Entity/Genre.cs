namespace G_MovieStoreMVC.Models.Entity
{
    public class Genre
    {
        public int Id { get; set; }
        public string? GenreName { get; set; }

        public List<MovieGenre> Movie { get; set; } = new List<MovieGenre>();
    }
}
