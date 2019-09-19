namespace OptimusPrime.Server.Internal
{
    public class ResultModel<T>
    {
        public bool IsSuccess { get; set; } = false;
        public string Message { get; set; }
        public T Value { get; set; }
    }
}
