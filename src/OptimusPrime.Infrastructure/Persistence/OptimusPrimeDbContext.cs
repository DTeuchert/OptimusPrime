using Microsoft.EntityFrameworkCore;
using OptimusPrime.Domain.Models;
using OptimusPrime.Infrastructure.Persistence.Extensions;
using Category = OptimusPrime.Infrastructure.Persistence.Entities.Category;
using Transformer = OptimusPrime.Infrastructure.Persistence.Entities.Transformer;

namespace OptimusPrime.Infrastructure.Persistence;
public class OptimusPrimeDbContext(DbContextOptions<OptimusPrimeDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Transformer> Transformers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyAllConfigurations();

        #region Data seeding
        var categories = new List<(Guid id, string name)>
        {
            (id: Guid.NewGuid(), name: "Main"),
            (id: Guid.NewGuid(), name: "Autobot Cars"),
            (id: Guid.NewGuid(), name: "Mini-Bots"),
            (id: Guid.NewGuid(), name: "Dinobots"),
            (id: Guid.NewGuid(), name: "Aerialbots"),
            (id: Guid.NewGuid(), name: "Protectobots"),
            (id: Guid.NewGuid(), name: "Female Autobots"),
            (id: Guid.NewGuid(), name: "Technobots"),
            (id: Guid.NewGuid(), name: "Throttlebots"),
            (id: Guid.NewGuid(), name: "Targetmasters"),
            (id: Guid.NewGuid(), name: "Headmasters"),
            (id: Guid.NewGuid(), name: "Clonebots"),
            (id: Guid.NewGuid(), name: "Junkions"),
            (id: Guid.NewGuid(), name: "Others"),


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
                AllianceId = Alliance.Autobot.Id,
                CategoryId = categories[0].id
            });
        modelBuilder.Entity<Transformer>().HasData(
            new Transformer
            {
                Id = Guid.NewGuid(),
                Name = "Bumblebee",
                AllianceId = Alliance.Autobot.Id,
                CategoryId = categories[0].id
            });
        modelBuilder.Entity<Transformer>().HasData(
           new Transformer
           {
               Id = Guid.NewGuid(),
               Name = "Cliffjumper",
               AllianceId = Alliance.Autobot.Id,
               CategoryId = categories[0].id
           });

        modelBuilder.Entity<Transformer>().HasData(
           new Transformer
           {
               Id = Guid.NewGuid(),
               Name = "Megatron",
               AllianceId = Alliance.Decepticon.Id,
               CategoryId = categories[0].id
           });
        #endregion
    }
}
