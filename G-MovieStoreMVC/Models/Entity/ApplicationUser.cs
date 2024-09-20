using Microsoft.AspNetCore.Identity;

namespace G_MovieStoreMVC.Models.Entity
{
    public class ApplicationUser: IdentityUser
    {
        public string? Name { get; set; }
    }
}
