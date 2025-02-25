using MedicalEquipmentApp.Data;
using MedicalEquipmentApp.Infrastructure.Data.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalEquipmentApp.Infrastructure.Data.Infrastructure
{
	public static class ApplicationBuilderExtension
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var services = serviceScope.ServiceProvider;

            await RoleSeeder(services);
            await SeedAdministrator(services);

            var dataCategory = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedCategories(dataCategory);

            var dataBrand = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedBrands(dataBrand);

            return app;
        }

        private static async Task RoleSeeder(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = { "Administrator", "Client" };

            IdentityResult roleResult;

            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);

                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        private static async Task SeedAdministrator(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (await userManager.FindByNameAsync("admin") == null)
            {
                ApplicationUser user = new ApplicationUser();

                user.FirstName = "admin";
                user.LastName = "admin";
                user.UserName = "admin";
                user.Email = "admin@admin.com";
                user.Address = "admin address";
                user.PhoneNumber = "0888888888";

                var result = await userManager.CreateAsync(user, "Admin123456");

                if (result.Succeeded) 
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }

        private static void SeedCategories(ApplicationDbContext dataCategory)
        {
            if (dataCategory.Categories.Any())
            {
                return;
            }

            dataCategory.Categories.AddRange(new[]
            {
                new Category {CategoryName="Crypto Currencies"},
                new Category {CategoryName="Metals"},
                new Category {CategoryName="Stocks"}
            });
            dataCategory.SaveChanges();
        }

        private static void SeedBrands(ApplicationDbContext dataBrand)
        {
            if (dataBrand.Brands.Any())
            {
                return;
            }

            dataBrand.Brands.AddRange(new[]
            {
                new Brand {BrandName="BTC"},
                new Brand {BrandName="ETH"},
                new Brand {BrandName="DOGE"},
                new Brand {BrandName="XRP"},
                //new Brand {BrandName="Solana"},
                //new Brand {BrandName="Chainlink"},
                //new Brand {BrandName="BNB"},
                //new Brand {BrandName="Cardano"},

                //Stocks
                new Brand {BrandName="Intel Corporation"},
                new Brand {BrandName="NVIDIA Corporation"},
                new Brand {BrandName="Tesla Inc."},
                new Brand {BrandName="Amazon.com Inc."},
                new Brand {BrandName="Apple Inc."},
                new Brand {BrandName="NIKE Inc."},
                new Brand {BrandName="Meta Platforms"},
                new Brand {BrandName="Mastercard"},

                //Metals
                new Brand {BrandName="Gold"},
                new Brand {BrandName="Silver"},
                new Brand {BrandName="Titanium"},
                new Brand {BrandName="Platinum"}
            });
            dataBrand.SaveChanges();
        }
    }
}