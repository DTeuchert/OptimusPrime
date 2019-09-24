using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OptimusPrime.Server.Entities;

namespace OptimusPrime.Server.Persistences.Extensions
{
    public static class OptimusPrimeDbContextSeedingExtension
    {
        public static void ApplySeedings(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(GetPreconfiguredCategorys());
            modelBuilder.Entity<Transformer>().HasData(GetPreconfiguredTransformers());
        }

        private static IEnumerable<Category> GetPreconfiguredCategorys()
        {
            return new List<Category>()
            {
                new Category { Id = 1, Name = "Main" },
                new Category { Id = 2, Name = "Autobot Cars" },
                new Category { Id = 3, Name = "Mini-Bots" },
                new Category { Id = 4, Name = "Dinobots" },
                new Category { Id = 5, Name = "Aerialbots" },
                new Category { Id = 6, Name = "Protectobots" },
                new Category { Id = 7, Name = "Female Autobots" },
                new Category { Id = 8, Name = "Technobots" },
                new Category { Id = 9, Name = "Throttlebots" },
                new Category { Id = 10, Name = "Targetmasters" },
                new Category { Id = 11, Name = "Headmasters" },
                new Category { Id = 12, Name = "Clonebots" },
                new Category { Id = 13, Name = "Junkions" },
                new Category { Id = 14, Name = "Others" },
            };
        }
        private static IEnumerable<Transformer> GetPreconfiguredTransformers()
        {
            return new List<Transformer>()
            {
                new Transformer
                {
                    Guid = Guid.NewGuid().ToString(),
                    Name = "Optimus Prime",
                    Alliance = Alliance.Autobot,
                    CategoryId = 1
                },
                new Transformer
                {
                    Guid = Guid.NewGuid().ToString(),
                    Name = "Bumblebee",
                    Alliance = Alliance.Autobot,
                    CategoryId = 1
                },
                new Transformer
                {
                    Guid = Guid.NewGuid().ToString(),
                    Name = "Cliffjumper",
                    Alliance = Alliance.Autobot,
                    CategoryId = 1
                },
                new Transformer
                {
                    Guid = Guid.NewGuid().ToString(),
                    Name = "Megatron",
                    Alliance = Alliance.Decepticon,
                    CategoryId = 1
                }
            };
        }
    }
}
