using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.ViewModels
{
    public class ProductVariantViewModel
    {
        public int  Id { get; set; }
        
        public string EnglishType { get; set; }

        public string EnglishValue { get; set; }

        public string FrenchType { get; set; }
      
        public string FrenchValue { get; set; }       
        public string ArabicType { get; set; }
        public string ArabicValue { get; set; }
    }
}
