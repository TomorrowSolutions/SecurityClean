using Microsoft.AspNetCore.Identity;

namespace SecurityClean3.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? FullName { get; set; }
    }
}
