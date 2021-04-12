using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Models
{
    public class LocalizationSet
    {
        [Key]
        public int Id { get; set; }
        public virtual ICollection<Localization> Localizations { get; set; } = new List<Localization>();
    }
}
