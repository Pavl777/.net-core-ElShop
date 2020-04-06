using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdminEShop.Data.Initial
{
    public class AdminInitialaizer
    {
        public static async Task InitializeAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
          
            string eMail = "Eshopp@mail.ru";
            string pass = "234Pavel$$$";

            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }

            if (await userManager.FindByNameAsync(eMail) == null)
            {
                IdentityUser admin = new IdentityUser { Email = eMail, UserName = eMail };
                IdentityResult result = await userManager.CreateAsync(admin, pass);
                if(result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            
            }
        }
    }
}
