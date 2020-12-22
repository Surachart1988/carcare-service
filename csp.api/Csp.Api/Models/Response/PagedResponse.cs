using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csp.Api.Models.Response
{
    public class PagedResponse<T> : BaseResponse<T>
    {
        public int TotalRecords { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string OrderBy { get; set; }
        public bool OrderAsc { get; set; }
        public int TotalPages { get; set; }
        public PagedResponse(T data, int totalRecords, int pageNumber, int pageSize, string orderby, bool orderasc)
        {
            TotalRecords = totalRecords;
            PageSize = pageSize;
            PageNumber = pageNumber;
            OrderBy = orderby;
            OrderAsc = orderasc;
            TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
        }
    }
}
