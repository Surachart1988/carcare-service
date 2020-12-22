using Csp.DAL.Models;
using Csp.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Csp.Services.Interfaces
{
    public interface IReportServiceRequestService
    {
        Task<IEnumerable<Sale>> SearchReportServiceRequestByField(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "Sale.Code", bool orderAsc = false);
        Task<int> GetTotalSearchReportServiceRequestByField(Dictionary<string, string> searchParams);
    }
}
