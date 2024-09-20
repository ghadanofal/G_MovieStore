using System.ComponentModel.DataAnnotations;

namespace G_MovieStoreMVC.Models.Entity
{
    public class Director
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
		
        //A director can have many movies
		//public List<Movie> Movies { get; set; } = new List<Movie>();

	}
}
