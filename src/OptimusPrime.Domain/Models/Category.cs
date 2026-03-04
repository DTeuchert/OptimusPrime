using OptimusPrime.Domain.Abstractions;

namespace OptimusPrime.Domain.Models;

public record Category(Guid Id, string Name) : DomainEntity<Guid>(Id);
