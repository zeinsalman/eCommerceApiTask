using eCommerceApi.Data;
using eCommerceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Repositories
{
    public class CultureRepository : ICultureRepository
    {
        private readonly ApplicationDbContext _context;

        public CultureRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Culture> GetAll()
        {
            return this._context.Cultures.OrderBy(c => c.Name).ToList();
        }
    }
}
