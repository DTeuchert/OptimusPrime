using OptimusPrime.Server.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OptimusPrime.Server.Persistences.Configurations
{
    public class TransformerConfiguration : IEntityTypeConfiguration<Transformer>
    {
        public void Configure(EntityTypeBuilder<Transformer> builder)
        {
            builder.HasKey(c => c.Guid);
            builder.Property(c => c.Guid)
                .HasMaxLength(36);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(64);
        }
    }
}
