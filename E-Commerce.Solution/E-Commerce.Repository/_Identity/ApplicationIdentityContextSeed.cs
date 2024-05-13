using E_Commerce.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository._Identity
{
    public static class ApplicationIdentityContextSeed
    {

        public static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new ApplicationUser
                {
                    DisplayName = "Ahmed Raslan",
                    Email = "ahmedraslan150@gmail.com",
                    UserName = "Ahmed.Raslan",
                    PhoneNumber = "01122334455"
                };

                await userManager.CreateAsync(user, "P@ssw0rd");               
            }
        }
    }
}
