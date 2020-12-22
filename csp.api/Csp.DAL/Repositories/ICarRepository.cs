using Csp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Csp.DAL.Repositories
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        Task<IEnumerable<Car>> SearchCarbyField(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "UpdatedAt", bool orderAsc = false);
        Task<int> GetTotalSearchCarByField(Dictionary<string, string> searchParams);
    }
}
