using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using JupiterTask.Entites;

namespace JupiterTask.Services
{
    public class RoleAndUserService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<UserIdentity> _userManager;

        public RoleAndUserService(RoleManager<IdentityRole> roleManager, UserManager<UserIdentity> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task CreateAdminRoleAndUserAsync()
        {
            
            var roleExist = await _roleManager.RoleExistsAsync("Admin");
            if (!roleExist)
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            // Create "Admin" user if not exists
            var adminUser = await _userManager.FindByEmailAsync("admin@jupiter.com");
            if (adminUser == null)
            {
                var newAdmin = new UserIdentity
                {
                    UserName = "admin@jupiter.com",
                    Email = "admin@jupiter.com",
                    FirstName = "Admin",
                    LastName = "User",
                    PhoneNumber = "1234567890"
                };

                var result = await _userManager.CreateAsync(newAdmin, "AdminPassword123!");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newAdmin, "Admin");
                }
            }
        }
    }
}
