using Csp.DAL.Models;
using Csp.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Csp.Services.Interfaces
{
    public interface IProductService
    {
        //Task<object> GenerateCode(int progroupId, int protypeId, int probrandId);
        Task<int> GetTotalCountSearchProductByField(Dictionary<string, string> searchParams);
        Task<IEnumerable<Product>> SearchProductByField(Dictionary<string, string> searchParams, int pageIndex, int pageSize, string orderBy, bool orderAsc);

        Task<Product> Create(Product product, decimal produtceSalePrice);
        Task<bool> Update(Product product, decimal produtceSalePrices);
        Task<(Product product, decimal saleprice)> GetProductById(int id);

        // Mystery Code from previous extreme senoir developer
        //Task<(IEnumerable<object> Resources, int ToTalRecords)> GetAllProductSalePrice(Dictionary<string, string> searchParams, int pageIndex, int pageSize, string orderBy, bool orderAsc);
        //Task<(IEnumerable<object> Resources, int ToTalRecords)> GetAllProductForSaleProcess(Dictionary<string, string> searchParams, int pageIndex, int pageSize, string orderBy, bool orderAsc);
    }
}
