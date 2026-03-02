namespace OptimusPrime.Infrastructure.Persistence.Entities;
public class Transformer
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Alliance Alliance { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
