using Microsoft.EntityFrameworkCore;
using OptimusPrime.Server.Entities;
using OptimusPrime.Server.Persistences.Extensions;
using System;

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
            modelBuilder.Entity<Transformer>().HasData(
                new Transformer
                {
                    Guid = Guid.NewGuid().ToString(),
                    Name = "Bumblebee"
                });
            #endregion
        }
    }
}
