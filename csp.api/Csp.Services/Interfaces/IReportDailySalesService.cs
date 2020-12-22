using Csp.DAL.Models;
using Csp.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Csp.Services.Interfaces
{
    public interface IReportDailySalesService
    {
        Task<IEnumerable<Sale>> SearchReportDailySalesByField(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "Sale.Code", bool orderAsc = false);
        Task<int> GetTotalSearchReportDailySalesByField(Dictionary<string, string> searchParams);
    }
}
