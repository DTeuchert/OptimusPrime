namespace OptimusPrime.Domain.Exceptions;

public class OptimusPrimeException : Exception
{
    public OptimusPrimeException() { }
    public OptimusPrimeException(string message) : base(message) { }
    public OptimusPrimeException(string  message, Exception inner) : base(message, inner) { }
}
