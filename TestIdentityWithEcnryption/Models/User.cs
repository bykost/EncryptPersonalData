using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class User : IdentityUser
    {
        public string City { get; set; }

        [ProtectedPersonalData]
        public string ProtectedString { get; set; }
    }
}
