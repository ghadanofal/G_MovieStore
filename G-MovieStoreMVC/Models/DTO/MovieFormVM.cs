using G_MovieStoreMVC.Models.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace G_MovieStoreMVC.Models.DTO
{
    public class MovieFormVM
    {
        public int Id { get; set; }
        
        [MaxLength(50)]
        public string? Title { get; set; }
        public string? ReleaseYear { get; set; }

        [Required]
        public string? Cast { get; set; }
        [Required]
        public int DirectorId { get; set; }

        public List<SelectListItem>? Director { get; set; }

        public IFormFile? ImageFile { get; set; }
       
        public List<int>? SelectedGenres { get; set; }= new List<int>();
        
        public IEnumerable<SelectListItem>? GenreList { get; set; }
        
        public string? GenreNames { get; set; }
    }
}
