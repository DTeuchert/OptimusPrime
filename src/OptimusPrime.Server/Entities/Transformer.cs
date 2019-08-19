namespace OptimusPrime.Server.Entities
{
    public class Transformer
    {
        public string Guid { get; set; }
        public string Name { get; set; }

        public Alliance Alliance { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
