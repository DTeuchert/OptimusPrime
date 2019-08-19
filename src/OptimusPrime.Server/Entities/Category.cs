using System.Collections.Generic;

namespace OptimusPrime.Server.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Transformer> Transformers { get; set; }
    }
}
