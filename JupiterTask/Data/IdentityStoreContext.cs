using JupiterTask.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace JupiterTask.Data
{
    public class IdentityStoreContext : IdentityDbContext<UserIdentity>
    {

        public IdentityStoreContext(DbContextOptions options) :base(options) { }
        
            
    }
}
