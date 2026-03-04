namespace OptimusPrime.Domain.Abstractions;

public abstract record AggregateRoot<T>(T Id) : DomainEntity<T>(Id);




