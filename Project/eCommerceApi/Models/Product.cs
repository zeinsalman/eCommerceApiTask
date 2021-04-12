using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int ? NameId { get; set; }
        public int ? DescriptionId { get; set; }
        [ForeignKey("NameId")]
        public virtual LocalizationSet  Name { get; set; }
        [ForeignKey("DescriptionId")]
        public virtual LocalizationSet Description { get; set; }
        public virtual ICollection<ProductVariant> Varaints { get; set; }
    }
}
