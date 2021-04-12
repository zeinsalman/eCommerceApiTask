using eCommerceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace eCommerceApi.Repositories
{
    public interface ILocalizationRepository
    {
    
        void Create(Localization localization);
        void Delete(IEnumerable<Localization> localizations);

        void CreateLocalizations(object viewModel, PropertyInfo propertyInfo, LocalizationSet localizationSet);
    }
}
