using Csp.DAL.Models;
using Csp.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Csp.Services.Interfaces
{
    public interface IBranchService
    {
        Task<Branch> GetBranch();
        Task<bool> UpdateBranch(Branch model);
    }
}
