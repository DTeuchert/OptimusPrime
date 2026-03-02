using Microsoft.EntityFrameworkCore;
using OptimusPrime.Infrastructure.Persistence.Entities;
using OptimusPrime.Infrastructure.Persistence.Extensions;

namespace OptimusPrime.Infrastructure.Persistence;
public class OptimusPrimeDbContext(DbContextOptions<OptimusPrimeDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Transformer> Transformers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyAllConfigurations();

        #region Data seeding
        var categories = new List<(int id, string name)>
        {
            (id: 1, name: "Main"),
            (id: 2, name: "Autobot Cars"),
            (id: 3, name: "Mini-Bots"),
            (id: 4, name: "Dinobots"),
            (id: 5, name: "Aerialbots"),
            (id: 6, name: "Protectobots"),
            (id: 7, name: "Female Autobots"),
            (id: 8, name: "Technobots"),
            (id: 9, name: "Throttlebots"),
            (id: 10, name: "Targetmasters"),
            (id: 11, name: "Headmasters"),
            (id: 12, name: "Clonebots"),
            (id: 13, name: "Junkions"),
            (id: 14, name: "Others"),


        };
        foreach (var (id, name) in categories)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = id, Name = name });
        }

        modelBuilder.Entity<Transformer>().HasData(
            new Transformer
            {
                Id = Guid.NewGuid(),
                Name = "Optimus Prime",
                Alliance = Alliance.Autobot,
                CategoryId = 1
            });
        modelBuilder.Entity<Transformer>().HasData(
            new Transformer
            {
                Id = Guid.NewGuid(),
                Name = "Bumblebee",
                Alliance = Alliance.Autobot,
                CategoryId = 1
            });
        modelBuilder.Entity<Transformer>().HasData(
           new Transformer
           {
               Id = Guid.NewGuid(),
               Name = "Cliffjumper",
               Alliance = Alliance.Autobot,
               CategoryId = 1
           });

        modelBuilder.Entity<Transformer>().HasData(
           new Transformer
           {
               Id = Guid.NewGuid(),
               Name = "Megatron",
               Alliance = Alliance.Decepticon,
               CategoryId = 1
           });
        #endregion
    }
}
