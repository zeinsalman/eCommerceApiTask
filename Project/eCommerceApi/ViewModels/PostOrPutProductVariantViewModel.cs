using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.ViewModels
{
    public class PostOrPutProductVariantViewModel
    {
        public int ? Id { get; set; }
        [Required]
        public string EnglishType { get; set; }
        [Required] 
        public string EnglishValue { get; set; }
        [Required] 
        public string FrenchType { get; set; }
        [Required] 
        public string FrenchValue{ get; set; }
        [Required] 
        public string ArabicType { get; set; }
        [Required] 
        public string ArabicValue { get; set; }
    }
}
