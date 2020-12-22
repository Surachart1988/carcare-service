using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Csp.DAL.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {

        Task<TEntity> Get(int Id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<int> AddRageItems(string sqlcmd, IEnumerable<TEntity> entities);
        Task<TEntity> Add(TEntity entity);
        Task<bool> Delete(TEntity entity);
        Task<bool> DeleteRageItems(string sqlcmd, IEnumerable<TEntity> entities);
        Task<bool> UpdateRageItems(string sqlcmd, IEnumerable<TEntity> entities);
        Task<bool> Update(TEntity entity);
        Task<IEnumerable<TEntity>> SearchByField(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "UpdatedAt", bool orderAsc = false);
        Task<int> GetCountSearchByField(Dictionary<string, string> searchParams);
        Task<IEnumerable<TEntity>> MasterDataSearchByField(Dictionary<string, string> searchParams, string tableName, int pageIndex = 1, int pageSize = 10, string orderBy = "UpdatedAt", bool orderAsc = false);
        Task<int> GetCountMasterDataSearchByField(Dictionary<string, string> searchParams, string tableName);
    }
}
