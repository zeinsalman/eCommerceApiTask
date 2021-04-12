using eCommerceApi.Models;
using eCommerceApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        Task<Product> CreateOrUpdate(PostOrPutProductViewModel postProductViewModel);
        Task<bool> Delete(int id);
    }
}
