namespace OptimusPrime.Domain.Models;

public class Transformer
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Alliance Alliance { get; set; }
    public Category Category { get; set; }
}
