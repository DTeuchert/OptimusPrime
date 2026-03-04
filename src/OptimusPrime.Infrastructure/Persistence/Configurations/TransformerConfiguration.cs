using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OptimusPrime.Infrastructure.Persistence.Entities;

namespace OptimusPrime.Infrastructure.Persistence.Configurations;
public class TransformerConfiguration : IEntityTypeConfiguration<Transformer>
{
    public void Configure(EntityTypeBuilder<Transformer> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id)
            .HasMaxLength(36);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(64);

        // builder.Property(t => t.Alliance)
        //     .HasConversion(new ValueConverter<Alliance, string>(
        //         vc => vc.ToString(),
        //         vc => (Alliance)Enum.Parse(typeof(Alliance), vc)));

        builder.HasOne(t => t.Category)
            .WithMany(c => c.Transformers)
            .HasForeignKey(t => t.CategoryId);
    }
}
