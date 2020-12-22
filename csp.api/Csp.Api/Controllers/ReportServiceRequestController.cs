using AutoMapper;
using Csp.Api.Helper;
using Csp.Api.Models;
using Csp.Api.Models.Response;
using Csp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csp.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class ReportServiceRequestController : Controller
    {
        private readonly IReportServiceRequestService _reportServiceRequestService;
        private readonly IMapper _mapper;
        private readonly ICacheService _cache;
        private static string _cacheName = "ReportServiceRequest";

        public ReportServiceRequestController(IReportServiceRequestService reportServiceRequestService, IMapper mapper, ICacheService cache)
        {
            _reportServiceRequestService = reportServiceRequestService;
            _mapper = mapper;
            _cache = cache;
        }

        /// <summary>
        /// Search Report Service Request by Field
        /// </summary>
        /// <param name="searchParams">Custom Parameters</param>
        /// <param name="page">Page number</param>
        /// <param name="perPage">Item Per Page</param>
        /// <param name="orderBy">Order By Field</param>
        /// <param name="orderasc">True : Order By ASC | False : Order By DESC</param>
        /// <returns></returns>
        [HttpPost("/api/v{version:apiVersion}/ReportServiceRequest/Search")]
        [ProducesResponseType(typeof(IEnumerable<ReportServiceRequestItem>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Search(
            [FromBody] Dictionary<string, string> searchParams,
            [FromQuery] int page = 1,
            [FromQuery] int perPage = 10,
            [FromQuery] string orderBy = "Sale.Code",
            [FromQuery] bool orderasc = false
            )
        {
            BaseResponse<IEnumerable<ReportServiceRequestItem>> result = null;
            //Job Ducument = 1
            searchParams.Add("Sale.DocTypeID", "1");
            try
            {
                var p = new ArrayList();
                if (searchParams != null)
                {
                    if (searchParams.Count() == 0)
                        throw new Exception();

                    foreach (var searchParam in searchParams)
                    {
                        p.Add(string.Format("{0} = '{1}'", searchParam.Key, searchParam.Value));
                    }
                }

                var searchString = p.Count == 0 ? "1=1" : String.Join(" and ", p.ToArray());

                var cacheKey = HashHelper.TextToHash(searchString);

                var cacheTotalCount = _cache.GetCacheValue<string>(cacheKey);
                if (cacheTotalCount == null)
                {
                    cacheTotalCount = (await _reportServiceRequestService.GetTotalSearchReportServiceRequestByField(searchParams)).ToString();
                    _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                }

                var response = await _reportServiceRequestService.SearchReportServiceRequestByField(searchParams, page, perPage, orderBy, orderasc);
                int totalCount = Convert.ToInt32(cacheTotalCount);

                if (response == null)
                {
                    result = new BaseResponse<IEnumerable<ReportServiceRequestItem>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    };
                }
                else
                {
                    var reportServiceRequestItems = _mapper.Map<IEnumerable<ReportServiceRequestItem>>(response);

                    result = new PagedResponse<IEnumerable<ReportServiceRequestItem>>(reportServiceRequestItems, totalCount, page, perPage, orderBy, orderasc)
                    {
                        Message = "Success",
                        StatusCode = 200,
                        Resource = reportServiceRequestItems
                    };
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<ReportServiceRequestItem>>(ex)));
            }

            return Ok(result);
        }

    }

}
