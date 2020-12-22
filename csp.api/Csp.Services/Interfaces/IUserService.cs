using Csp.DAL.Models;
using Csp.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Csp.Services.Interfaces
{
    public interface IUserService
    {
        public int UserId { get; set; }
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        Task<User> Create(User user, string password);
        Task<User> GetUserById(int userId);
        Task<User> GetUserByLoginName(string loginName);
        Task<bool> Update(User user);
        Task<bool> Delete(int id);
        Task<IEnumerable<User>> SrchUsrByField(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "UpdatedAt", bool orderAsc = false);
        Task<int> GetTotalSrchUsrByField(Dictionary<string, string> searchParams);
        IUnitOfWork GetUnitOfWork();
    }
}
