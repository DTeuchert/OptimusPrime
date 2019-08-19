using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OptimusPrime.Server.Entities;
using OptimusPrime.Server.Persistences.Extensions;

namespace OptimusPrime.Server.Persistences
{
    public class OptimusPrimeDbContext : DbContext
    {
        public DbSet<Transformer> Transformers { get; set; }

        public OptimusPrimeDbContext(DbContextOptions<OptimusPrimeDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();

            #region Data seeding
            var categories = new List<(int id, string name)>
            {
                (id: 1, name: "Main Autobots"),
            };
            foreach (var (id, name) in categories)
            {
                modelBuilder.Entity<Category>().HasData(
                    new Category { Id = id, Name = name });
            }

            modelBuilder.Entity<Transformer>().HasData(
                new Transformer
                {
                    Guid = Guid.NewGuid().ToString(),
                    Name = "Bumblebee",
                    Alliance = Alliance.Autobot,
                    CategoryId = 1
                });
            #endregion
        }
    }
}
