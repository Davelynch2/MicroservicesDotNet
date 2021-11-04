using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlateformService.Models;

namespace PlateformService.Data
    {
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Platforms.AddRange(new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                                           new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                                           new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
                );

                context.SaveChanges(); // do not forget
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}