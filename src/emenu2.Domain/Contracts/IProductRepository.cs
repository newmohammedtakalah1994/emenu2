 
using emenu2.Domain.Models;
using System;
using Volo.Abp.Domain.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace emenu2.Domain.Contracts
{
    public interface IProductRepository :IRepository<Product,Guid>
    {
        public  Task<IEnumerable<Product>> FilterByNameAsync(string name);

        public Task<IQueryable<Product>> AddDetailsAsync(IQueryable<Product> query);
    }
}
