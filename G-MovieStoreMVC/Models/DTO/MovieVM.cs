using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace G_MovieStoreMVC.Models.DTO
{
    public class MovieVM
    {
        public int Id { get; set; }
        
        public string? Title { get; set; }
        public string? ReleaseYear { get; set; }

        public string? ImageURL { get; set; }
        
        public string? Cast { get; set; }
        
        public string? Director { get; set; }

        
        public IFormFile? ImageFile { get; set; }
        
        public List<int>? Genres { get; set; }
        
        public IEnumerable<SelectListItem>? GenreList { get; set; }
        
        public string? GenreNames { get; set; }
       

    }
}
