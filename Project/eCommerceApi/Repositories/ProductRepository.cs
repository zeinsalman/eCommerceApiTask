using eCommerceApi.Data;
using eCommerceApi.Exceptions;
using eCommerceApi.Models;
using eCommerceApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace eCommerceApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ICultureRepository _cultureRepository;
        private readonly ILocalizationSetRepository _localizationSetRepository;

        public ProductRepository(ApplicationDbContext context, ICultureRepository cultureRepository, ILocalizationSetRepository localizationSetRepository)
        {
            _context = context;
            _cultureRepository = cultureRepository;
            _localizationSetRepository = localizationSetRepository;
        }

        public  IEnumerable<Product> GetAll()
        {
            return _context.Products
              .Include(b => b.Name).ThenInclude(ls => ls.Localizations)
              .Include(b => b.Description).ThenInclude(ls => ls.Localizations)
              .Include(b=>b.Varaints).ThenInclude(x=>x.Type).ThenInclude(x=>x.Localizations)
              .Include(b => b.Varaints).ThenInclude(x => x.Value).ThenInclude(x => x.Localizations)
              .ToList();
        }
        public Product GetById(int id)
        {
            var product =  _context.Products
              .Include(b => b.Name).ThenInclude(ls => ls.Localizations)
              .Include(b => b.Description).ThenInclude(ls => ls.Localizations)
              .Include(b => b.Varaints).ThenInclude(x => x.Type).ThenInclude(x => x.Localizations)
              .Include(b => b.Varaints).ThenInclude(x => x.Value).ThenInclude(x => x.Localizations)
              .FirstOrDefault(b => b.Id == id);

            if (product == null)
            {
                throw new NotFoundException("Product was not found");
            }
            else
            {
                return product;
            }
        }

        public async Task<Product> CreateOrUpdate(PostOrPutProductViewModel postProductViewModel)
        {
            Product product = new Product();

            if (!postProductViewModel.Id.HasValue)
            {
                _localizationSetRepository.CreateOrUpdateLocalizationsFor(product, postProductViewModel);
                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                foreach (var variant in postProductViewModel.Variants)
                {
                    ProductVariant productVariant = new ProductVariant()
                    {
                        ProductId = product.Id,

                    };
                    _localizationSetRepository.CreateOrUpdateLocalizationsFor(productVariant, variant);
                    _context.ProductVariants.Add(productVariant);

                }
                await _context.SaveChangesAsync();
            }
            else
            {
                product = GetById(Convert.ToInt32(postProductViewModel.Id));
                if (product == null)
                {
                    throw new NotFoundException("Product was not found");
                }
                else
                {
                    _localizationSetRepository.CreateOrUpdateLocalizationsFor(product, postProductViewModel);
                    _context.Products.Update(product);
                    await _context.SaveChangesAsync();
                    foreach (var variant in postProductViewModel.Variants)
                    {
                        if (variant.Id.HasValue)
                        {
                            var existedVariant = GetVariantById(Convert.ToInt32(variant.Id));
                            if (existedVariant == null)
                            {
                                throw new NotFoundException("Product Vriant  was not found");
                            }
                            else
                            {
                                _localizationSetRepository.CreateOrUpdateLocalizationsFor(existedVariant, variant);
                                _context.ProductVariants.Update(existedVariant);
                            }


                        }
                        else
                        {
                            ProductVariant productVariant = new ProductVariant()
                            {
                                ProductId = product.Id,

                            };

                            _localizationSetRepository.CreateOrUpdateLocalizationsFor(productVariant, variant);
                            _context.ProductVariants.Add(productVariant);
                        };





                        await _context.SaveChangesAsync();
                    }
                }
      

            }

            return product;

        }

        private ProductVariant GetVariantById(int id)
        {
            var productVariant = _context.ProductVariants.Where(x => x.Id == id).Include(x => x.Type).Include(x => x.Value).FirstOrDefault();
            if (productVariant == null)
            {
                throw new NotFoundException("Product Vriant  was not found");
            }
            else
            {
                return productVariant;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var product = _context.Products
            .Include(b => b.Name).ThenInclude(ls => ls.Localizations)
            .Include(b => b.Description).ThenInclude(ls => ls.Localizations)
            .Include(b => b.Varaints).ThenInclude(x => x.Type).ThenInclude(x => x.Localizations)
            .Include(b => b.Varaints).ThenInclude(x => x.Value).ThenInclude(x => x.Localizations)
            .FirstOrDefault(b => b.Id == id);

            if (product == null)
            {
                throw new NotFoundException("Product was not found");
            }
            else
            {
                foreach(var variant in product.Varaints)
                {
                    await DeleteLocalisationSet(Convert.ToInt32(variant.TypeId));
                    await DeleteLocalisationSet(Convert.ToInt32(variant.ValueId));

                    _context.ProductVariants.Remove(variant);


                }

                await DeleteLocalisationSet(Convert.ToInt32(product.NameId));
                await DeleteLocalisationSet(Convert.ToInt32(product.DescriptionId));
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;


            }
        }

        private async Task<bool> DeleteLocalisationSet(int id)
        {
            var localosationSet = _context.LocalizationSets.Include(x => x.Localizations).FirstOrDefault(x => x.Id == id);
            if (localosationSet == null)
            {
                return false;
            }
            else
            {
                foreach(var localisation in localosationSet.Localizations)
                {
                    _context.Localizations.Remove(localisation);
                }
                _context.Remove(localosationSet);
                await _context.SaveChangesAsync(); 
                return true;
            }
        }
    }

}
