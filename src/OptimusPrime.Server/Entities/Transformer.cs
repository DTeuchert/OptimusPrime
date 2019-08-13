using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OptimusPrime.Server.Entities
{
    public class Transformer
    {
        [Key]
        public string Guid { get; set; }

        [Required]
        [StringLength(300)]
        public string Name { get; set; }

    }
}
