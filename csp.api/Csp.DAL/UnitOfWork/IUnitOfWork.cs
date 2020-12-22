using Csp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Csp.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        // create property for custom Repository
        public IUserRepository UserRepository { get; }
        public IContactTypesRepository ContactTypesRepository { get; }
        public ICarRepository CarRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IProductSalePriceRepository ProductSalePriceRepository { get; }
        public IReportServiceRequestRepository ReportServiceRequestRepository { get; }
        public IReportDailySalesRepository ReportDailySalesRepository { get; }

        // create Generic Repository and pass Entity Type
        public IGenericRepository<TEntity> GenericRepository<TEntity>() where TEntity : class;

        public int UserId { get; set; }

    }
}
