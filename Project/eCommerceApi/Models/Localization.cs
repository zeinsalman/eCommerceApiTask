using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Models
{
    public class Localization
    {
    
        public int  LocalizationSetId { get; set; }
        public int  CultureId { get; set; }
        public string Value { get; set; }
        [ForeignKey("LocalizationSetId")]
        public virtual LocalizationSet LocalizationSet { get; set; }
        [ForeignKey("CultureId")]
        public virtual Culture Culture { get; set; }
    }
}
