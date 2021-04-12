using eCommerceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Repositories
{
    public interface ILocalizationSetRepository
    {
        LocalizationSet GetById(int id);
        void Create(LocalizationSet localizationSet);
        void CreateOrUpdateLocalizationsFor(object entity, object viewModel);
    }
}
