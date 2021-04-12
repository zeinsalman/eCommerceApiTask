using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Models
{
    public class ProductVariant
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public int ? TypeId { get; set; }
        public int ? ValueId { get; set; }
        [ForeignKey("TypeId")]
        public virtual LocalizationSet Type { get; set; }
        [ForeignKey("ValueId")]
        public virtual LocalizationSet Value { get; set; }


    }
}
