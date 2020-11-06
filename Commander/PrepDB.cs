using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Commander
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            SeedData(serviceScope.ServiceProvider.GetService<CommanderContext>());
        }

        private static void SeedData(CommanderContext context)
        {
            Console.WriteLine("Appling migrations ...");
            context.Database.Migrate();

            if (!context.Commands.Any())
            {
                Console.WriteLine("Adding data - seeding ...");
                context.Commands.AddRange(
                    new Command { HowTo = "How to 1", Line = "Line 1", Platform = "Platform 1" },
                    new Command { HowTo = "How to 2", Line = "Line 2", Platform = "Platform 2" },
                    new Command { HowTo = "How to 3", Line = "Line 3", Platform = "Platform 3" },
                    new Command { HowTo = "How to 4", Line = "Line 4", Platform = "Platform 4" }
                    );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Already have data - not seeding");
            }
        }
    }
}