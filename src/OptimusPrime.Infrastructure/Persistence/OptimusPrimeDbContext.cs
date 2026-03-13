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
            (id: new Guid("b72793c4-a462-4268-88d8-f080e0eefa42"), name: "Main"),
            (id: new Guid("d51cc438-6117-4cb2-8d2f-5f33e14d04fc"), name: "Autobot Cars"),
            (id: new Guid("d74d16ae-2f91-49ce-a741-a00d8ae684ac"), name: "Mini-Bots"),
            (id: new Guid("be1c56c4-6947-4466-8e07-86542556e576"), name: "Dinobots"),
            (id: new Guid("24a1832f-cb0c-4770-a559-d4d9fc146c77"), name:"Aerialbots"),
            (id: new Guid("d9a95247-30f7-4033-83c2-81e45c996619"), name: "Protectobots"),
            (id: new Guid("83d2f378-26f9-4b83-a562-88ac627a3477"), name: "Female Autobots"),
            (id: new Guid("3e05f3c6-0e6b-4ac0-8a24-5d5edc818aa6"), name: "Technobots"),
            (id: new Guid("2fc83505-6cc8-4d5e-930c-5a96fa15f458"), name: "Throttlebots"),
            (id: new Guid("288870ca-239b-4612-ba27-a9ac1a908c0a"), name: "Targetmasters"),
            (id: new Guid("76552f0c-9505-4c3d-a2f0-098fc8493a4c"), name: "Headmasters"),
            (id: new Guid("9fd942c2-9660-4bcb-a70d-74382215c329"), name: "Clonebots"),
            (id: new Guid("72e18b93-6926-4798-9976-2857d93296fc"), name: "Junkions"),
            (id: new Guid("78bd17e8-7cd5-4161-9397-2830ef279a74"), name: "Others")
        };
        foreach (var (id, name) in categories)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = id, Name = name });
        }

        modelBuilder.Entity<Transformer>().HasData(
            new Transformer
            {
                Id = new Guid("8a78dc38-93c4-413b-8369-7784d8296a00"),
                Name = "Optimus Prime",
                AllianceId = Alliance.Autobot.Id,
                CategoryId = categories[0].id
            });
        modelBuilder.Entity<Transformer>().HasData(
            new Transformer
            {
                Id = new Guid("33a6a0a1-c13a-4c97-a0a7-c567255299e0"),
                Name = "Bumblebee",
                AllianceId = Alliance.Autobot.Id,
                CategoryId = categories[0].id
            });
        modelBuilder.Entity<Transformer>().HasData(
           new Transformer
           {
               Id = new Guid("178fb622-a034-4378-a19c-554ee9330512"),
               Name = "Cliffjumper",
               AllianceId = Alliance.Autobot.Id,
               CategoryId = categories[0].id
           });

        modelBuilder.Entity<Transformer>().HasData(
           new Transformer
           {
               Id = new Guid("ad07477c-e728-42bf-bb0d-54db2688da1c"),
               Name = "Megatron",
               AllianceId = Alliance.Decepticon.Id,
               CategoryId = categories[0].id
           });
        #endregion
    }
}
