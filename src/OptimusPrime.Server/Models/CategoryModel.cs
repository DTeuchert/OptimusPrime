using OptimusPrime.Server.Entities;

namespace OptimusPrime.Server.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public static class CategoryModelExtensions
    {
        public static CategoryModel ToModel(this Category x)
        {
            return new CategoryModel
            {
                Id = x.Id,
                Name = x.Name,
            };
        }
    }
}
