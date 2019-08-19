using OptimusPrime.Server.Entities;

namespace OptimusPrime.Server.ViewModels
{
    public class TransformerViewModel
    {
        public string Guid { get; set; }
        public string Name { get; set; }
        public Alliance Alicance { get; set; }
        public CategoryViewModel Category { get; set; }

    }

    public static class TransformerViewModelExtensions
    {
        public static TransformerViewModel ToViewModel(this Transformer x)
        {
            return new TransformerViewModel
            {
                Guid = x.Guid,
                Name = x.Name,
                Alicance = x.Alliance,
                Category = x.Category.ToViewModel() ?? new CategoryViewModel()
            };
        }
    }
}
