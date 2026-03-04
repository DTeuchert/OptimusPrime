namespace OptimusPrime.Infrastructure.Persistence.Entities;
public class Transformer
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public int AllianceId { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}

public static class TransformerModelExtensions
{
    
    extension(Transformer transformer)
    {
        public Domain.Models.Transformer ToModel() 
            => new Domain.Models.Transformer(transformer.Id, transformer.Name, Domain.Models.Alliance.Get(transformer.AllianceId), transformer.Category.ToModel());
    }
}
