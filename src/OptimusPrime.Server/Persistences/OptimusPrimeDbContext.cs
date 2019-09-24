using Microsoft.EntityFrameworkCore;
using OptimusPrime.Server.Entities;
using OptimusPrime.Server.Persistences.Extensions;

namespace OptimusPrime.Server.Persistences
{
    public class OptimusPrimeDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transformer> Transformers { get; set; }

        public OptimusPrimeDbContext(DbContextOptions<OptimusPrimeDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();
            modelBuilder.ApplySeedings();
        }
    }
}
