using OptimusPrime.Domain.Models;

namespace OptimusPrime.Api.ViewModels
{
    public class TransformerViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Alliance Allicance { get; set; }
        public CategoryViewModel Category { get; set; }

    }

    public static class TransformerViewModelExtensions
    {
        public static TransformerViewModel ToViewModel(this Transformer x)
        {
            return new TransformerViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Allicance = x.Alliance,
                Category = x.Category.ToViewModel()
            };
        }
    }
}
