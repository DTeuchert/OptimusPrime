namespace OptimusPrime.Infrastructure.Persistence.Entities;
public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public virtual List<Transformer> Transformers { get; set; }
}

public static class CategoryModelExtensions
{
    extension(Category category)
    {
        public Domain.Models.Category ToModel() => new Domain.Models.Category(category.Id, category.Name);
    }
}
