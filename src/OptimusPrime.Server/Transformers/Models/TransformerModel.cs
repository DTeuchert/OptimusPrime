using OptimusPrime.Server.Entities;

namespace OptimusPrime.Server.Models
{
    public class TransformerModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Alliance Alliance { get; set; }
        public CategoryModel Category { get; set; }
    }

    public static class TransformerModelExtensions
    {
        public static TransformerModel ToModel(this Transformer x)
        {
            return new TransformerModel
            {
                Id = x.Guid,
                Name = x.Name,
                Alliance = x.Alliance,
                Category = x.Category.ToModel() ?? new CategoryModel()
            };
        }
    }
}
