using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.ViewModels
{
    public class PostOrPutProductViewModel
    {
        public int ? Id { get; set; }
        [Required]
        public string EnglishDescription { get; set; }
        [Required]
        public string EnglishName { get; set; }
        [Required]
        public string ArabicDescription { get; set; }
        [Required]
        public string ArabicName { get; set; }
        [Required]
        public string FrenchDescription { get; set; }
        [Required]
        public string FrenchName { get; set; }
        public List<PostOrPutProductVariantViewModel> Variants { get; set; }

    }
}
