using Csp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Csp.DAL.Repositories
{
    public interface IReportServiceRequestRepository : IGenericRepository<Sale>
    {
        Task<IEnumerable<Sale>> SearchReportServiceRequestByField(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "Sale.Code", bool orderAsc = false);
        Task<int> GetTotalSearchReportServiceRequestByField(Dictionary<string, string> searchParams);
    }
}
