using Csp.DAL.Infrastructure;
using Csp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Csp.DAL.Repositories
{
    public class ProductSalePriceRepository : GenericRepository<ProductSalePrice>, IProductSalePriceRepository
    {
        public ProductSalePriceRepository(IConnectionFactory connectionFactory, int userId) : base(connectionFactory, userId)
        {

        }
    }
}
