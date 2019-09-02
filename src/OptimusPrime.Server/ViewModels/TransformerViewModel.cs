using OptimusPrime.Server.Entities;
using OptimusPrime.Server.Models;

namespace OptimusPrime.Server.ViewModels
{
    public class TransformerViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Alliance Allicance { get; set; }
        public CategoryViewModel Category { get; set; }

    }

    public static class TransformerViewModelExtensions
    {
        public static TransformerViewModel ToViewModel(this TransformerModel x)
        {
            return new TransformerViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Allicance = x.Alliance,
                Category = x.Category.ToViewModel() ?? new CategoryViewModel()
            };
        }
    }
}
