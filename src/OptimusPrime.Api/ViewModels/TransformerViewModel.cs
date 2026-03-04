using OptimusPrime.Domain.Models;

namespace OptimusPrime.Api.ViewModels;
    public class TransformerViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Alliance Allicance { get; set; }
        public CategoryViewModel Category { get; set; }

    }

    public static class TransformerViewModelExtensions
    {
        extension(Transformer transformer)
        {
            public TransformerViewModel ToViewModel() => new()
            {
                Id = transformer.Id,
                Name = transformer.Name,
                Allicance = transformer.Alliance,
                Category = transformer.Category.ToViewModel()
            };
        }
    }
