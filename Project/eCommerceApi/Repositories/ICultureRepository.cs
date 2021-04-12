using eCommerceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Repositories
{
    public interface ICultureRepository
    {
        IEnumerable<Culture> GetAll();

    }
}
