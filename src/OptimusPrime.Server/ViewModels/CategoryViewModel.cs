using OptimusPrime.Server.Entities;

namespace OptimusPrime.Server.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    public static class CategoryViewModelExtensions
    {
        public static CategoryViewModel ToViewModel(this Category x)
        {
            return new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
            };
        }
    }
}
