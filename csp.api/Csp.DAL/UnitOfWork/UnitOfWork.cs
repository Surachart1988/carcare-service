using Csp.DAL.Infrastructure;
using Csp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Csp.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IConnectionFactory _connectionFactory;
        public int UserId { get; set; }

        public UnitOfWork(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        // create property for custom Repository
        public IUserRepository UserRepository => new UserRepository(_connectionFactory, UserId);
        public IContactTypesRepository ContactTypesRepository => new ContactTypesRepository(_connectionFactory, UserId);
        public IProductRepository ProductRepository => new ProductRepository(_connectionFactory, UserId);

        public IProductSalePriceRepository ProductSalePriceRepository => new ProductSalePriceRepository(_connectionFactory, UserId);
 		public ICarRepository CarRepository => new CarRepository(_connectionFactory, UserId);
        public IReportServiceRequestRepository ReportServiceRequestRepository => new ReportServiceRequestRepository(_connectionFactory, UserId);
        public IReportDailySalesRepository ReportDailySalesRepository => new ReportDailySalesRepository(_connectionFactory, UserId);


        // create Generic Repository
        public IGenericRepository<TEntity> GenericRepository<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity>(_connectionFactory, UserId);

        }
    }
}
