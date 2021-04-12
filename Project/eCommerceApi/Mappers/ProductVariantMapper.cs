using AutoMapper;
using eCommerceApi.Models;
using eCommerceApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Mappers
{
    public class ProductVariantMapper : Profile
    {
        public ProductVariantMapper()
        {
            CreateMap<ProductVariant, ProductVariantViewModel>()
                 .ForMember(x => x.EnglishType, y => y.MapFrom(s => s.Type.Localizations.FirstOrDefault(x => x.CultureId == 1).Value))
                 .ForMember(x => x.EnglishValue, y => y.MapFrom(s => s.Value.Localizations.FirstOrDefault(x => x.CultureId == 1).Value))
                 .ForMember(x => x.ArabicType, y => y.MapFrom(s => s.Type.Localizations.FirstOrDefault(x => x.CultureId == 2).Value))
                 .ForMember(x => x.ArabicValue, y => y.MapFrom(s => s.Value.Localizations.FirstOrDefault(x => x.CultureId == 2).Value))
                 .ForMember(x => x.FrenchType, y => y.MapFrom(s => s.Type.Localizations.FirstOrDefault(x => x.CultureId == 3).Value))
                 .ForMember(x => x.FrenchValue, y => y.MapFrom(s => s.Value.Localizations.FirstOrDefault(x => x.CultureId == 3).Value));
        }
    }
}
