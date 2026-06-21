using Microsoft.AspNetCore.Identity;

namespace WebApplicationGIS46.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Address { get; set; }
    }
}
