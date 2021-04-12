using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string EnglishDescription { get; set; }

        public string EnglishName { get; set; }

        public string ArabicDescription { get; set; }

        public string ArabicName { get; set; }

        public string FrenchDescription { get; set; }

        public string FrenchName { get; set; }
        public List<ProductVariantViewModel> Variants { get; set; }
    }
}
