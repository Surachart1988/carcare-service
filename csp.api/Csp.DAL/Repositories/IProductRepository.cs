using Csp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Csp.DAL.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<int> GetTotalSrchProductByField(Dictionary<string, string> searchParams);
        Task<IEnumerable<Product>> SearchProductByField(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "UpdatedAt", bool orderAsc = false);

        Task<Product> Create(Product product);



        //Task<(IEnumerable<object> Resources, int TotalRecords)> SearchProductSalePriceByField(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "UpdatedAt", bool orderAsc = false);
        //Task<(IEnumerable<object> Resources, int TotalRecords)> SearchProductForSaleProcessByField(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "UpdatedAt", bool orderAsc = false);
    }
}
