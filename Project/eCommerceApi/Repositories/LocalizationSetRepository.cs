using eCommerceApi.Data;
using eCommerceApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace eCommerceApi.Repositories
{
    public class LocalizationSetRepository : ILocalizationSetRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILocalizationRepository _localization;

        public LocalizationSetRepository(ApplicationDbContext context, ILocalizationRepository localization)
        {
            _context = context;
            _localization = localization;
        }

        public LocalizationSet GetById(int id)
        {
            return _context.LocalizationSets
              .Include(ls => ls.Localizations)
              .FirstOrDefault(ls => ls.Id == id);
        }

        public void Create(LocalizationSet localizationSet)
        {
            _context.LocalizationSets.Add(localizationSet);
        }

        public void CreateOrUpdateLocalizationsFor(object entity , object viewModel)
        {
            foreach (PropertyInfo propertyInfo in GetLocalizationSetPropertiesFromEntity(entity))
            {
                LocalizationSet localizationSet = GetOrCreateLocalizationSetForProperty(entity, propertyInfo);

                if(localizationSet.Localizations.Count() > 0)
                {
                    _localization.Delete(localizationSet.Localizations);

                }
                _localization.CreateLocalizations( viewModel ,propertyInfo, localizationSet);
            }
        }

        private IEnumerable<PropertyInfo> GetLocalizationSetPropertiesFromEntity(object entity)
        {
            return entity.GetType().GetProperties().Where(pi => pi.PropertyType == typeof(LocalizationSet));
        }

        private LocalizationSet GetOrCreateLocalizationSetForProperty(object entity, PropertyInfo propertyInfo)
        {
            
            PropertyInfo localizationSetIdPropertyInfo = entity.GetType().GetProperty(propertyInfo.Name + "Id");
            int? localizationSetId = (int?)localizationSetIdPropertyInfo.GetValue(entity);
            LocalizationSet localizationSet;
            if (localizationSetId == null || localizationSetId == 0)
            {
                localizationSet = new LocalizationSet();
                Create(localizationSet);
                _context.SaveChanges();
                localizationSetIdPropertyInfo.SetValue(entity, localizationSet.Id);
            }

            else localizationSet = GetById((int)localizationSetId);

            return localizationSet;
        }
    }
}
