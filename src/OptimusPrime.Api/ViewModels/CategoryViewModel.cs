using OptimusPrime.Domain.Models;

namespace OptimusPrime.Api.ViewModels;
public class CategoryViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public static class CategoryViewModelExtensions
{
    extension(Category category)
    {
        public CategoryViewModel ToViewModel() => new () { Id = category.Id, Name = category.Name };
    }
}
