using Csp.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Csp.Services.Interfaces
{
    public interface IContactTypesService
    {
        Task<IEnumerable<Contact>> GetAllVenderByPageIndex(Dictionary<string, string> searchParams, int pageIndex, int pageSize, string orderBy, bool orderAsc);
        Task<Contact> GetVenderById(int id);
        Task<Contact> CreateVender(Contact model);
        Task<bool> UpdateVender(Contact model);
        Task<int> GetTotalNumberVender(Dictionary<string, string> searchParams);

        Task<IEnumerable<Contact>> GetAllCustomerByPageIndex(Dictionary<string, string> searchParams, int pageIndex, int pageSize, string orderBy, bool orderAsc);
        Task<Contact> GetCustomerById(int id);
        Task<Contact> CreateCustomer(Contact model);
        Task<bool> UpdateCustomer(Contact vendor);
        Task<int> GetTotalNumberCustomer(Dictionary<string, string> searchParams);
    }
}

