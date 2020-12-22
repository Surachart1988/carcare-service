using Csp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Csp.DAL.Repositories
{
    public interface IContactTypesRepository : IGenericRepository<Contact>
    {
        Task<IEnumerable<Contact>> SearchVenderbyField(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "UpdatedAt", bool orderAsc = false);
        Task<IEnumerable<Contact>> CheckDuplicateVender(Dictionary<string, string> searchParams);
        Task<IEnumerable<Contact>> SearchCustomerbyField(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "UpdatedAt", bool orderAsc = false);
        Task<IEnumerable<Contact>> CheckDuplicateCustomer(Dictionary<string, string> searchParams);
        Task<int> GetTotalSearchVenderByField(Dictionary<string, string> searchParams);
        Task<int> GetTotalSearchCustomerByField(Dictionary<string, string> searchParams);
    }
}
