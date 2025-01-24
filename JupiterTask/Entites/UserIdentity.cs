global using Microsoft.AspNetCore.Identity;

namespace JupiterTask.Entites
{
    public class UserIdentity : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
