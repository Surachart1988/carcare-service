using AutoMapper;
using Csp.Api.Helper;
using Csp.Api.Models;
using Csp.Api.Models.Response;
using Csp.Services.Interfaces;
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
    //[Authorize]
    public class ReportDailySalesController : Controller
    {
        private readonly IReportDailySalesService _reportDailySalesService;
        private readonly IMapper _mapper;
        private readonly ICacheService _cache;
        private static string _cacheName = "DailySales";

        public ReportDailySalesController(IReportDailySalesService reportDailySalesService, IMapper mapper, ICacheService cache)
        {
            _reportDailySalesService = reportDailySalesService;
            _mapper = mapper;
            _cache = cache;
        }

        /// <summary>
        /// Search Report Daily Sales by Field
        /// </summary>
        /// <param name="searchParams">Custom Parameters</param>
        /// <param name="page">Page number</param>
        /// <param name="perPage">Item Per Page</param>
        /// <param name="orderBy">Order By Field</param>
        /// <param name="orderasc">True : Order By ASC | False : Order By DESC</param>
        /// <returns></returns>
        [HttpPost("/api/v{version:apiVersion}/ReportDailySales/Search")]
        [ProducesResponseType(typeof(IEnumerable<ReportDailySalesItem>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Search(
            [FromBody] Dictionary<string, string> searchParams,
            [FromQuery] int page = 1,
            [FromQuery] int perPage = 10,
            [FromQuery] string orderBy = "Sale.Code",
            [FromQuery] bool orderasc = false
            )
        {
            BaseResponse<IEnumerable<ReportDailySalesItem>> result = null;
            //is only one Job Document = 1
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
                    cacheTotalCount = (await _reportDailySalesService.GetTotalSearchReportDailySalesByField(searchParams)).ToString();
                    _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                }

                var response = await _reportDailySalesService.SearchReportDailySalesByField(searchParams, page, perPage, orderBy, orderasc);
                int totalCount = Convert.ToInt32(cacheTotalCount);

                if (response == null)
                {
                    result = new BaseResponse<IEnumerable<ReportDailySalesItem>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    };
                }
                else
                {
                    var reportDailySalesItems = _mapper.Map<IEnumerable<ReportDailySalesItem>>(response);

                    result = new PagedResponse<IEnumerable<ReportDailySalesItem>>(reportDailySalesItems, totalCount, page, perPage, orderBy, orderasc)
                    {
                        Message = "Success",
                        StatusCode = 200,
                        Resource = reportDailySalesItems
                    };
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<ReportDailySalesItem>>(ex)));
            }

            return Ok(result);
        }

    }

}
