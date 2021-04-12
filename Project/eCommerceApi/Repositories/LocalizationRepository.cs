using eCommerceApi.Data;
using eCommerceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace eCommerceApi.Repositories
{
    public class LocalizationRepository : ILocalizationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ICultureRepository _cultureRepository;


        public LocalizationRepository(ApplicationDbContext context, ICultureRepository cultureRepository)
        {
            _context = context;
            _cultureRepository = cultureRepository;
        }

        public void Create(Localization localization)
        {
           _context.Localizations.Add(localization);
        }

        public void Delete(IEnumerable<Localization> localizations)
        {
           _context.Localizations.RemoveRange(localizations);
        }

        public void CreateLocalizations(object viewModel , PropertyInfo propertyInfo, LocalizationSet localizationSet)
        {
            
            foreach (Culture culture in _cultureRepository.GetAll())
            {
                Localization localization = new Localization
                {
                    LocalizationSetId = localizationSet.Id,
                    CultureId = culture.Id,
                    //Value = propertyInfo.GetValue(entity).ToString()
                };
                
                foreach (var viewModelProp in viewModel.GetType().GetProperties())
                {
                    if(viewModelProp.Name == culture.Name + propertyInfo.Name)
                    {
                        localization.Value = viewModelProp.GetValue(viewModel).ToString();
                    }
                }
                Create(localization);
            }

            _context.SaveChanges();
        }
    }
}
