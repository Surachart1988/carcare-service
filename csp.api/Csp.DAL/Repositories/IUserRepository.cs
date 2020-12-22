using Csp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Csp.DAL.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        //Task<(IEnumerable<User> Resources, int TotalRecords)> SearchUserByField(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "UpdatedAt", bool orderAsc = false);

        Task<IEnumerable<User>> SrchUsrByField(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "UpdatedAt", bool orderAsc = false);
        Task<int> GetTotalSrchUsrByField(Dictionary<string, string> searchParams);
    }
}
