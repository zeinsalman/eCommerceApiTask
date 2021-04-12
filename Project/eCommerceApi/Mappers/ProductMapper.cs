using AutoMapper;
using eCommerceApi.Models;
using eCommerceApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Mappers
{
    public class ProductMapper :Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductViewModel>()
                 .ForMember(x => x.Variants, y => y.MapFrom(s => s.Varaints))

                 .ForMember(x => x.EnglishDescription, y => y.MapFrom(s => s.Description.Localizations.FirstOrDefault(x => x.CultureId == 1).Value))
                 .ForMember(x => x.EnglishName, y => y.MapFrom(s => s.Name.Localizations.FirstOrDefault(x => x.CultureId == 1).Value))
                 .ForMember(x => x.ArabicDescription, y => y.MapFrom(s => s.Description.Localizations.FirstOrDefault(x => x.CultureId == 2).Value))
                 .ForMember(x => x.ArabicName, y => y.MapFrom(s => s.Name.Localizations.FirstOrDefault(x => x.CultureId == 2).Value))
                 .ForMember(x => x.FrenchDescription, y => y.MapFrom(s => s.Description.Localizations.FirstOrDefault(x => x.CultureId == 3).Value))
                 .ForMember(x => x.FrenchName, y => y.MapFrom(s => s.Name.Localizations.FirstOrDefault(x => x.CultureId == 3).Value));
        }
    }
}
