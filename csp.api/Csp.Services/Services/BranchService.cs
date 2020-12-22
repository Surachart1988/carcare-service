using Csp.DAL.Models;
using Csp.DAL.UnitOfWork;
using Csp.Services.CustomeException;
using Csp.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csp.Services.Services
{
    public class BranchService : BaseService, IBranchService
    {

        public BranchService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<Branch> GetBranch()
        {
            return await _unitOfWork.GenericRepository<Branch>().Get(1);
        }

        public async Task<bool> UpdateBranch(Branch model)
        {
            return await _unitOfWork.GenericRepository<Branch>().Update(model);
        }
    }
}
