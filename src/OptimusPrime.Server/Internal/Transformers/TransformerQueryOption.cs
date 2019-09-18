using OptimusPrime.Server.Entities;

namespace OptimusPrime.Server.Internal.Transformers
{
    public class TransformerQueryOption
    {
        internal TransformerQueryOption() { }

        public string Name { get; set; }
        public Alliance? Alliance { get; set; }
        public int? CategoryId { get; set; }
    }
}
