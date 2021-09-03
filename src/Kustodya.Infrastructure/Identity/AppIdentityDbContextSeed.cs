using Microsoft.AspNetCore.Identity;
using Prozess.Infrastructure.Identity;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public static class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser { UserName = "demouser@roojo.tech", Email = "demouser@roojo.tech" };
            await userManager.CreateAsync(defaultUser, "Pass@word1");
        }
    }
}