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
    public class ReportServiceRequestService : BaseService, IReportServiceRequestService
    {

        public ReportServiceRequestService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public async Task<IEnumerable<Sale>> SearchReportServiceRequestByField(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "Sale.Code", bool orderAsc = false)
        {
            return await _unitOfWork.ReportServiceRequestRepository.SearchReportServiceRequestByField(searchParams, pageIndex, pageSize, orderBy, orderAsc);
        }
        public async Task<int> GetTotalSearchReportServiceRequestByField(Dictionary<string, string> searchParams)
        {
            return await _unitOfWork.ReportServiceRequestRepository.GetTotalSearchReportServiceRequestByField(searchParams);
        }
    }
}
