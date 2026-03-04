using OptimusPrime.Domain.Abstractions;

namespace OptimusPrime.Domain.Models;

public record Transformer (Guid Id, string Name, Alliance Alliance, Category Category): AggregateRoot<Guid>(Id);
