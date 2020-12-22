using Csp.DAL.Models;
using Csp.Services.CustomeException;
using Csp.Services.Interfaces;
using AutoMapper;
using Csp.Api.Helper;
using Csp.Api.Models;
using Csp.Api.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Csp.Api.Controllers
{
    /// <summary>
    /// MasterData Resources 
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class MasterDataController : ControllerBase
    {
        private readonly IMasterDataService _masterdataService;
        private readonly ICacheService _cache;
        private readonly IMapper _mapper;
        private static string _cacheName = "MasterData";

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="masterdataService"></param>
        /// <param name="mapper"></param>
        public MasterDataController(IMasterDataService masterdataService, ICacheService cache, IMapper mapper)
        {
            _masterdataService = masterdataService;
            _mapper = mapper;
            _cache = cache;
        }

        /// <summary>
        /// Get all MasterData By PageType
        /// </summary>
        /// <param name="pageType">
        /// [productgroup,producttype,productbrand,productmodel,productsize,productunit,location,dot,nextservice,subnextservice,cartype,carbrand,carmodel,carsubmodel,
        /// carchecklist,cargear,contacttype,bussinesstype,reasondecinc,assessment,tagstatus,documenttype,bankname,creditcard,chequetype,creditcardswipe,inputtaxrate,
        /// outputtaxrate,conditiontaxdeduction,taxdeductiontype,position]
        /// </param>
        /// <param name="page">current page</param>
        /// <param name="perPage">item per page</param>
        /// <param name="orderBy">order by field</param>
        /// <param name="orderasc">true: order by asc, false: order by desc</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<object>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(
            [FromQuery, Required] string pageType = null,
            [FromQuery] int page = 1,
            [FromQuery] int perPage = 10,
            [FromQuery] string orderBy = "UpdatedAt",
            [FromQuery] bool orderasc = false)
        {
            //(IEnumerable<object> Resources, int TotalRecords) result = (null, 0);
            IEnumerable<object> result = null;
            try
            {
                string msType = pageType.ToLower();
                string cacheKey = HashHelper.TextToHash($"all{_cacheName}Type{msType}");
                string cacheTotalCount = _cache.GetCacheValue<string>(cacheKey);

                switch (msType)
                {
                    case "productgroup":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterProGroup>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterProGroup>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "producttype":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterProType>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterProType>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "productbrand":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterProBrand>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterProBrand>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "productmodel":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterPromodel>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterPromodel>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "productsize":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterProSize>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterProSize>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "productunit":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterProUnit>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterProUnit>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "location":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterLocation>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterLocation>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "dot":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterDot>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterDot>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "nextservice":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterNextService>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterNextService>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "subnextservice":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterNextServiceSub>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterNextServiceSub>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "cartype":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterCarType>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterCarType>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "carbrand":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterCarBrand>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterCarBrand>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "carmodel":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterCarModel>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterCarModel>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "carsubmodel":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterCarSubModel>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterCarSubModel>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "carchecklist":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterCheckList>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterCheckList>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "cargear":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterCarGear>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterCarGear>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "contacttype":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterContactType>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterContactType>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "bussinesstype":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterBussinessType>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterBussinessType>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "reasondecinc":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterReasonDecInc>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterReasonDecInc>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "assessment":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterAssessment>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterAssessment>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "tagstatus":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterTagStatus>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterTagStatus>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "documenttype":
                        result = await _masterdataService.GetAllMasterDataByPageType<DocumentType>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<DocumentType>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "bankname":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterBank>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterBank>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "creditcard":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterCreditCard>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterCreditCard>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "chequetype":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterPayChqType>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterPayChqType>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "creditcardswipe":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterCardUseType>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterCardUseType>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "inputtaxrate":
                    case "outputtaxrate":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterVatRate>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterVatRate>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "conditiontaxdeduction":
                        var conditionTaxDedcutionParams = new Dictionary<string, string> { { "Flag", "TaxType" } };
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterTaxItem>(conditionTaxDedcutionParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterTaxItem>(conditionTaxDedcutionParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "taxdeductiontype":
                        var taxDeductionTypeParams = new Dictionary<string, string> { { "Flag", "TaxDeduc" } };
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterTaxItem>(taxDeductionTypeParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterTaxItem>(taxDeductionTypeParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "position":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterPosition>(null, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterPosition>(null)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                }

                if (result == null)
                {
                    return Ok(new PagedResponse<IEnumerable<object>>(null, 0, page, perPage, orderBy, orderasc)
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new PagedResponse<IEnumerable<object>>(result, Convert.ToInt32(cacheTotalCount), page, perPage, orderBy, orderasc)
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = result
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<object>>(ex)));
            }
        }

        /// <summary>
        /// Search MasterData By PageType parameters
        /// </summary>
        /// <param name="searchParams">search parameters</param>
        /// <param name="pageType">
        /// [productgroup,producttype,productbrand,productmodel,productsize,productunit,location,dot,nextservice,subnextservice,cartype,carbrand,carmodel,carsubmodel,
        /// carchecklist,cargear,contacttype,bussinesstype,reasondecinc,assessment,tagstatus,documenttype,bankname,creditcard,chequetype,creditcardswipe,inputtaxrate,
        /// outputtaxrate,conditiontaxdeduction,taxdeductiontype,position]
        /// </param>
        /// <param name="page">current page</param>
        /// <param name="perPage">item per page</param>
        /// <param name="orderBy">order by field</param>
        /// <param name="orderasc">true: order by asc, false: order by desc</param>
        /// <returns></returns>
        [HttpPost("/api/v{version:apiVersion}/MasterData/Search")]
        [ProducesResponseType(typeof(IEnumerable<object>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Search(
            [FromBody] Dictionary<string, string> searchParams,
            [FromQuery, Required] string pageType = null,
            [FromQuery] int page = 1,
            [FromQuery] int perPage = 10,
            [FromQuery] string orderBy = "UpdatedAt",
            [FromQuery] bool orderasc = false)
        {
            //(IEnumerable<object> Resources, int TotalRecords) result = (null, 0);
            IEnumerable<object> result = null;
            try
            {
                string msType = pageType.ToLower();
                var p = new ArrayList();
                if (searchParams != null)
                {
                    if (searchParams.Count() == 0)
                        throw new BadParametersException("Search Parameters cannot be null");

                    if (msType == "conditiontaxdeduction")
                        searchParams.Add("Flag", "TaxType");
                    if (msType == "taxdeductiontype")
                        searchParams.Add("Flag", "TaxDeduc");

                    foreach (var searchParam in searchParams)
                    {
                        p.Add(string.Format("{0} = '{1}'", searchParam.Key, searchParam.Value));
                    }
                }
                var searchString = p.Count == 0 ? "1=1" : String.Join(" and ", p.ToArray());

                string cacheKey = HashHelper.TextToHash($"srch{_cacheName}Type{msType}{searchString}");
                string cacheTotalCount = _cache.GetCacheValue<string>(cacheKey);
                switch (msType)
                {
                    case "productgroup":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterProGroup>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterProGroup>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }

                        break;
                    case "producttype":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterProType>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterProType>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "productbrand":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterProBrand>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterProBrand>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "productmodel":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterPromodel>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterPromodel>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "productsize":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterProSize>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterProSize>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "productunit":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterProUnit>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterProUnit>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "location":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterLocation>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterLocation>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "dot":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterDot>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterDot>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "nextservice":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterNextService>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterNextService>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "subnextservice":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterNextServiceSub>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterNextServiceSub>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "cartype":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterCarType>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterCarType>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "carbrand":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterCarBrand>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterCarBrand>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "carmodel":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterCarModel>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterCarModel>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "carsubmodel":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterCarSubModel>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterCarSubModel>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "carchecklist":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterCheckList>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterCheckList>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "cargear":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterCarGear>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterCarGear>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "contacttype":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterContactType>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterContactType>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "bussinesstype":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterBussinessType>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterBussinessType>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "reasondecinc":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterReasonDecInc>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterReasonDecInc>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "assessment":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterAssessment>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterAssessment>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "tagstatus":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterTagStatus>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterTagStatus>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "documenttype":
                        result = await _masterdataService.GetAllMasterDataByPageType<DocumentType>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<DocumentType>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "bankname":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterBank>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterBank>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "creditcard":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterCreditCard>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterCreditCard>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "chequetype":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterPayChqType>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterPayChqType>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "creditcardswipe":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterCardUseType>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterCardUseType>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "inputtaxrate":
                    case "outputtaxrate":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterVatRate>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterVatRate>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "conditiontaxdeduction":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterTaxItem>(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterTaxItem>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "taxdeductiontype":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterTaxItem>(searchParams, page, perPage, orderBy, orderasc);
                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterTaxItem>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                    case "position":
                        result = await _masterdataService.GetAllMasterDataByPageType<MasterPosition>(searchParams, page, perPage, orderBy, orderasc);
                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _masterdataService.GetCountAllMasterDataByPageType<MasterPosition>(searchParams)).ToString();
                            _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                        }
                        break;
                }
                if (result == null)
                {
                    return Ok(new PagedResponse<IEnumerable<object>>(null, 0, page, perPage, orderBy, orderasc)
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new PagedResponse<IEnumerable<object>>(result, Convert.ToInt32(cacheTotalCount), page, perPage, orderBy, orderasc)
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = result
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<object>>(ex)));
            }
        }

        /// <summary>
        /// Get MasterData With PageType By id
        /// </summary>
        /// <param name="id">id of masterdata</param>
        /// <param name="pageType">
        /// [productgroup,producttype,productbrand,productmodel,productsize,productunit,location,dot,nextservice,subnextservice,cartype,carbrand,carmodel,carsubmodel,
        /// carchecklist,cargear,contacttype,bussinesstype,reasondecinc,assessment,tagstatus,documenttype,bankname,creditcard,chequetype,creditcardswipe,inputtaxrate,
        /// outputtaxrate,conditiontaxdeduction,taxdeductiontype,position]
        /// </param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id, [FromQuery, Required] string pageType = null)
        {
            object result = null;
            try
            {
                switch (pageType.ToLower())
                {
                    case "productgroup": result = await _masterdataService.GetMasterDataById<MasterProGroup>(id); break;
                    case "producttype": result = await _masterdataService.GetMasterDataById<MasterProType>(id); break;
                    case "productbrand": result = await _masterdataService.GetMasterDataById<MasterProBrand>(id); break;
                    case "productmodel": result = await _masterdataService.GetMasterDataById<MasterPromodel>(id); break;
                    case "productsize": result = await _masterdataService.GetMasterDataById<MasterProSize>(id); break;
                    case "productunit": result = await _masterdataService.GetMasterDataById<MasterProUnit>(id); break;
                    case "location": result = await _masterdataService.GetMasterDataById<MasterLocation>(id); break;
                    case "dot": result = await _masterdataService.GetMasterDataById<MasterDot>(id); break;
                    case "nextservice": result = await _masterdataService.GetMasterDataById<MasterNextService>(id); break;
                    case "subnextservice": result = await _masterdataService.GetMasterDataById<MasterNextServiceSub>(id); break;
                    case "cartype": result = await _masterdataService.GetMasterDataById<MasterCarType>(id); break;
                    case "carbrand": result = await _masterdataService.GetMasterDataById<MasterCarBrand>(id); break;
                    case "carmodel": result = await _masterdataService.GetMasterDataById<MasterCarModel>(id); break;
                    case "carsubmodel": result = await _masterdataService.GetMasterDataById<MasterCarSubModel>(id); break;
                    case "carchecklist": result = await _masterdataService.GetMasterDataById<MasterCheckList>(id); break;
                    case "cargear": result = await _masterdataService.GetMasterDataById<MasterCarGear>(id); break;
                    case "contacttype": result = await _masterdataService.GetMasterDataById<MasterContactType>(id); break;
                    case "bussinesstype": result = await _masterdataService.GetMasterDataById<MasterBussinessType>(id); break;
                    case "reasondecinc": result = await _masterdataService.GetMasterDataById<MasterReasonDecInc>(id); break;
                    case "assessment": result = await _masterdataService.GetMasterDataById<MasterAssessment>(id); break;
                    case "tagstatus": result = await _masterdataService.GetMasterDataById<MasterTagStatus>(id); break;
                    case "documenttype": result = await _masterdataService.GetMasterDataById<DocumentType>(id); break;
                    case "bankname": result = await _masterdataService.GetMasterDataById<MasterBank>(id); break;
                    case "creditcard": result = await _masterdataService.GetMasterDataById<MasterCreditCard>(id); break;
                    case "chequetype": result = await _masterdataService.GetMasterDataById<MasterPayChqType>(id); break;
                    case "creditcardswipe": result = await _masterdataService.GetMasterDataById<MasterCardUseType>(id); break;
                    case "inputtaxrate":
                    case "outputtaxrate": result = await _masterdataService.GetMasterDataById<MasterVatRate>(id); break;
                    case "conditiontaxdeduction":
                    case "taxdeductiontype": result = await _masterdataService.GetMasterDataById<MasterTaxItem>(id); break;
                    case "position": result = await _masterdataService.GetMasterDataById<MasterPosition>(id); break;
                }
                if (result == null)
                {
                    return Ok(new BaseResponse<object>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<object>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = result
                    });
                }
            }
            catch (Exception ex)
            {

                return Ok((ExceptionReponseHelper.CustomExceptionHandler<object>(ex)));
            }
        }

        /// <summary>
        /// Create MasterData With PageType
        /// </summary>
        /// <param name="model">data of masterdata</param>
        /// <param name="pageType">
        /// [productgroup,producttype,productbrand,productmodel,productsize,productunit,location,dot,nextservice,subnextservice,cartype,carbrand,carmodel,carsubmodel,
        /// carchecklist,cargear,contacttype,bussinesstype,reasondecinc,assessment,tagstatus,bankname,creditcard,chequetype,creditcardswipe,inputtaxrate,
        /// outputtaxrate,position]
        /// </param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(object), 201)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync(
            [FromBody] RequestMasterData model,
            [FromQuery, Required] string pageType = null)
        {
            object result = null;
            try
            {
                switch (pageType.ToLower())
                {
                    case "productgroup": result = await _masterdataService.Create(_mapper.Map<RequestMasterData, MasterProGroup>(model)); break;

                    case "producttype": result = await _masterdataService.Create(_mapper.Map<RequestMasterData, MasterProType>(model)); break;

                    case "productbrand": result = await _masterdataService.Create(_mapper.Map<RequestMasterData, MasterProBrand>(model)); break;

                    case "productmodel": result = await _masterdataService.Create(_mapper.Map<RequestMasterData, MasterPromodel>(model)); break;

                    case "productsize": result = await _masterdataService.Create(_mapper.Map<RequestMasterData, MasterProSize>(model)); break;

                    case "productunit": result = await _masterdataService.Create(_mapper.Map<RequestMasterData, MasterProUnit>(model)); break;

                    case "location": result = await _masterdataService.Create(_mapper.Map<RequestMasterData, MasterLocation>(model)); break;

                    case "dot": result = await _masterdataService.Create(_mapper.Map<RequestMasterData, MasterDot>(model)); break;

                    case "nextservice": result = await _masterdataService.Create(_mapper.Map<RequestMasterData, MasterNextService>(model)); break;

                    case "subnextservice": result = await _masterdataService.Create(_mapper.Map<RequestMasterData, MasterNextServiceSub>(model)); break;

                    case "cartype": result = await _masterdataService.Create(_mapper.Map<RequestMasterData, MasterCarType>(model)); break;

                    case "carbrand": result = await _masterdataService.Create(_mapper.Map<RequestMasterData, MasterCarBrand>(model)); break;

                    case "carmodel": result = await _masterdataService.Create(_mapper.Map<RequestMasterData, MasterCarModel>(model)); break;

                    case "carsubmodel": result = await _masterdataService.Create(_mapper.Map<RequestMasterData, MasterCarSubModel>(model)); break;

                    case "carchecklist": result = await _masterdataService.Create(_mapper.Map<RequestMasterData, MasterCheckList>(model)); break;

                    case "cargear": result = await _masterdataService.Create(_mapper.Map<RequestMasterData, MasterCarGear>(model)); break;

                    case "contacttype": result = await _masterdataService.Create(_mapper.Map<RequestMasterData, MasterContactType>(model)); break;

                    case "bussinesstype": result = await _masterdataService.Create(_mapper.Map<RequestMasterData, MasterBussinessType>(model)); break;

                    case "reasondecinc": result = await _masterdataService.Create(_mapper.Map<RequestMasterData, MasterReasonDecInc>(model)); break;

                    case "assessment": result = await _masterdataService.Create(_mapper.Map<RequestMasterData, MasterAssessment>(model)); break;

                    case "tagstatus": result = await _masterdataService.Create(_mapper.Map<RequestMasterData, MasterTagStatus>(model)); break;

                    //no manage 
                    //case "documenttype": result = await _masterdataService.Create( _mapper.Map<RequestMasterData, DocumentType>(model)); break;

                    case "bankname": result = await _masterdataService.Create(_mapper.Map<RequestMasterData, MasterBank>(model)); break;

                    case "creditcard": result = await _masterdataService.Create(_mapper.Map<RequestMasterData, MasterCreditCard>(model)); break;

                    case "chequetype": result = await _masterdataService.Create(_mapper.Map<RequestMasterData, MasterPayChqType>(model)); break;

                    case "creditcardswipe": result = await _masterdataService.Create(_mapper.Map<RequestMasterData, MasterCardUseType>(model)); break;

                    case "inputtaxrate":
                    case "outputtaxrate": result = await _masterdataService.Create(_mapper.Map<RequestMasterData, MasterVatRate>(model)); break;

                    //no manage 
                    //case "conditiontaxdeduction": break;
                    //case "taxdeductiontype": break;

                    case "position": result = await _masterdataService.Create(_mapper.Map<RequestMasterData, MasterPosition>(model)); break;
                }

                return Ok(new BaseResponse<object>
                {
                    Message = "Sucess",
                    StatusCode = 200,
                    Resource = result
                });
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<object>(ex)));
            }
        }

        /// <summary>
        /// Edit MasterData With PageType
        /// </summary>
        /// <param name="id">id of masterdata</param>
        /// <param name="model">masterdata Data</param>
        /// <param name="pageType">
        /// [productgroup,producttype,productbrand,productmodel,productsize,productunit,location,nextservice,subnextservice,cartype,carbrand,carmodel,carsubmodel,
        /// carchecklist,cargear,contacttype,bussinesstype,reasondecinc,assessment,tagstatus,bankname,creditcard,chequetype,creditcardswipe,inputtaxrate,
        /// outputtaxrate,position]
        /// </param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(object), 201)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] RequestMasterData model, [FromQuery, Required] string pageType = null)
        {
            bool result = false;
            try
            {
                switch (pageType.ToLower())
                {
                    case "productgroup": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, MasterProGroup>(model)); break;

                    case "producttype": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, MasterProType>(model)); break;

                    case "productbrand": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, MasterProBrand>(model)); break;

                    case "productmodel": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, MasterPromodel>(model)); break;

                    case "productsize": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, MasterProSize>(model)); break;

                    case "productunit": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, MasterProUnit>(model)); break;

                    case "location": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, MasterLocation>(model)); break;

                    //no manage 
                    //case "dot": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, MasterDot>(model)); break;

                    case "nextservice": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, MasterNextService>(model)); break;

                    case "subnextservice": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, MasterNextServiceSub>(model)); break;

                    case "cartype": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, MasterCarType>(model)); break;

                    case "carbrand": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, MasterCarBrand>(model)); break;

                    case "carmodel": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, MasterCarModel>(model)); break;

                    case "carsubmodel": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, MasterCarSubModel>(model)); break;

                    case "carchecklist": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, MasterCheckList>(model)); break;

                    case "cargear": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, MasterCarGear>(model)); break;

                    case "contacttype": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, MasterContactType>(model)); break;

                    case "bussinesstype": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, MasterBussinessType>(model)); break;

                    case "reasondecinc": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, MasterReasonDecInc>(model)); break;

                    case "assessment": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, MasterAssessment>(model)); break;

                    case "tagstatus": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, MasterTagStatus>(model)); break;

                    //no manage 
                    //case "documenttype": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, DocumentType>(model)); break;

                    case "bankname": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, MasterBank>(model)); break;

                    case "creditcard": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, MasterCreditCard>(model)); break;

                    case "chequetype": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, MasterPayChqType>(model)); break;

                    case "creditcardswipe": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, MasterCardUseType>(model)); break;

                    case "inputtaxrate":
                    case "outputtaxrate": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, MasterVatRate>(model)); break;

                    //no manage 
                    //case "conditiontaxdeduction": break;
                    //case "taxdeductiontype": break;

                    case "position": result = await _masterdataService.Update(id, _mapper.Map<RequestMasterData, MasterPosition>(model)); break;
                }

                return Ok(new BaseResponse<object>
                {
                    Message = result ? "Success" : "Failure",
                    StatusCode = result ? 200 : 304
                });
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<object>(ex)));
            }
        }

        /// <summary>
        /// Delete MasterData With PageType by  id
        /// </summary>
        /// <param name="id">id of masterdata</param>
        /// <param name="pageType">
        /// [productgroup,producttype,productbrand,productmodel,productsize,productunit,location,nextservice,subnextservice,cartype,carbrand,carmodel,carsubmodel,
        /// carchecklist,cargear,contacttype,bussinesstype,reasondecinc,assessment,tagstatus,bankname,creditcard,chequetype,creditcardswipe,inputtaxrate,
        /// outputtaxrate,position]
        /// </param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(int id, [FromQuery, Required] string pageType = null)
        {
            bool result = false;
            try
            {
                switch (pageType.ToLower())
                {
                    case "productgroup": result = await _masterdataService.Delete<MasterProGroup>(id); break;

                    case "producttype": result = await _masterdataService.Delete<MasterProType>(id); break;

                    case "productbrand": result = await _masterdataService.Delete<MasterProBrand>(id); break;

                    case "productmodel": result = await _masterdataService.Delete<MasterPromodel>(id); break;

                    case "productsize": result = await _masterdataService.Delete<MasterProSize>(id); break;

                    case "productunit": result = await _masterdataService.Delete<MasterProUnit>(id); break;

                    case "location": result = await _masterdataService.Delete<MasterLocation>(id); break;

                    //no manage 
                    //case "dot": result = await _masterdataService.Delete<MasterPromodel>(id); break;(id, _mapper.Map<RequestMasterData, MasterDot>(model)); break;

                    case "nextservice": result = await _masterdataService.Delete<MasterNextService>(id); break;

                    case "subnextservice": result = await _masterdataService.Delete<MasterNextServiceSub>(id); break;

                    case "cartype": result = await _masterdataService.Delete<MasterCarType>(id); break;

                    case "carbrand": result = await _masterdataService.Delete<MasterCarBrand>(id); break;

                    case "carmodel": result = await _masterdataService.Delete<MasterCarModel>(id); break;

                    case "carsubmodel": result = await _masterdataService.Delete<MasterCarSubModel>(id); break;

                    case "carchecklist": result = await _masterdataService.Delete<MasterCheckList>(id); break;

                    case "cargear": result = await _masterdataService.Delete<MasterCarGear>(id); break;

                    case "contacttype": result = await _masterdataService.Delete<MasterContactType>(id); break;

                    case "bussinesstype": result = await _masterdataService.Delete<MasterBussinessType>(id); break;

                    case "reasondecinc": result = await _masterdataService.Delete<MasterReasonDecInc>(id); break;

                    case "assessment": result = await _masterdataService.Delete<MasterAssessment>(id); break;

                    case "tagstatus": result = await _masterdataService.Delete<MasterTagStatus>(id); break;

                    //no manage 
                    //case "documenttype": result = await _masterdataService.Delete<MasterPromodel>(id); break;(id, _mapper.Map<RequestMasterData, DocumentType>(model)); break;

                    case "bankname": result = await _masterdataService.Delete<MasterBank>(id); break;

                    case "creditcard": result = await _masterdataService.Delete<MasterCreditCard>(id); break;

                    case "chequetype": result = await _masterdataService.Delete<MasterPayChqType>(id); break;

                    case "creditcardswipe": result = await _masterdataService.Delete<MasterCardUseType>(id); break;

                    case "inputtaxrate":
                    case "outputtaxrate": result = await _masterdataService.Delete<MasterVatRate>(id); break;

                    //no manage 
                    //case "conditiontaxdeduction": break;
                    //case "taxdeductiontype": break;

                    case "position": result = await _masterdataService.Delete<MasterPosition>(id); break;
                }

                return Ok(new BaseResponse<object>
                {
                    Message = result ? "Success" : "Failure",
                    StatusCode = result ? 200 : 304
                });
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<object>(ex)));
            }
        }

        /// <summary>
        /// Get Permission with positionId and menuId
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("permission/userId")]
        [ProducesResponseType(typeof(BaseResponse<MasterPermisson>), StatusCodes.Status200OK)]
        public async Task<IActionResult> PermissionByUserId([FromBody] PermissionModel model)
        {
            BaseResponse<MasterPermisson> result;
            try
            {
                var permission = await _masterdataService.GetPermissionByUserId(model.PositionID, model.MenuID);
                if (permission == null)
                {
                    result = new BaseResponse<MasterPermisson>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    };
                }
                else
                {
                    result = new BaseResponse<MasterPermisson>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = _mapper.Map<MasterPermisson>(permission)
                    };
                }
            }
            catch (Exception ex)
            {

                return Ok((ExceptionReponseHelper.CustomExceptionHandler<MasterPermisson>(ex)));
            }

            return Ok(result);
        }

        /// <summary>
        /// Get all contacttype
        /// </summary>
        /// <returns></returns>
        [HttpGet("contacttype")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterContactType>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetContactType()
        {
            try
            {
                var Resources = await _masterdataService.GetAllContactType();
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterContactType>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterContactType>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterContactType>>(ex)));
            }
        }

        /// <summary>
        /// Get all bussinesstype
        /// </summary>
        /// <returns></returns>
        [HttpGet("bussinesstype")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterBussinessType>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBussinessType()
        {
            try
            {
                var Resources = await _masterdataService.GetAllBussinessType();
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterBussinessType>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterBussinessType>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterBussinessType>>(ex)));
            }
        }

        /// <summary>
        /// Get all reasondecinc
        /// </summary>
        /// <returns></returns>
        [HttpGet("reasondecinc")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterReasonDecInc>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetReasonDecInc()
        {
            try
            {
                var Resources = await _masterdataService.GetAllReasonDecInc();
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterReasonDecInc>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterReasonDecInc>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterReasonDecInc>>(ex)));
            }
        }

        /// <summary>
        /// Get all documenttype
        /// </summary>
        /// <returns></returns>
        [HttpGet("documenttype")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<DocumentType>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDocumentTypes()
        {
            try
            {
                var Resources = await _masterdataService.GetAllDocumentTypes();
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<DocumentType>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<DocumentType>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<DocumentType>>(ex)));
            }
        }

        /// <summary>
        /// Get all vattype
        /// </summary>
        /// <returns></returns>
        [HttpGet("vattype")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterVatType>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetVattype()
        {
            try
            {
                var Resources = await _masterdataService.GetAllVattype();
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterVatType>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterVatType>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterVatType>>(ex)));
            }
        }

        /// <summary>
        /// Get all vatrate
        /// </summary>
        /// <returns></returns>
        [HttpGet("vatrate")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterVatRate>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetVatRate()
        {
            try
            {
                var Resources = await _masterdataService.GetAllVatRate();
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterVatRate>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterVatRate>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterVatRate>>(ex)));
            }
        }

        /// <summary>
        /// Get all tag
        /// </summary>
        /// <returns></returns>
        [HttpGet("tag/list")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterTagDetails>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTagList()
        {
            try
            {
                var Resources = await _masterdataService.GetAllTagList();
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterTagDetails>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterTagDetails>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterTagDetails>>(ex)));
            }
        }

        /// <summary>
        /// Get all tag status
        /// </summary>
        /// <returns></returns>
        [HttpGet("tag/status")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterTagStatus>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTagStatus()
        {
            try
            {
                var Resources = await _masterdataService.GetAllTagStatus();
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterTagStatus>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterTagStatus>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterTagStatus>>(ex)));
            }
        }

        /// <summary>
        /// Get all cheque type
        /// </summary>
        /// <returns></returns>
        [HttpGet("cheque/type")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterPayChqType>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetChequeType()
        {
            try
            {
                var Resources = await _masterdataService.GetAllChequeType();
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterPayChqType>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterPayChqType>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterPayChqType>>(ex)));
            }
        }

        /// <summary>
        /// Get all bank
        /// </summary>
        /// <returns></returns>
        [HttpGet("bank")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterBank>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBank()
        {
            try
            {
                var Resources = await _masterdataService.GetAllBank();
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterBank>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterBank>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterBank>>(ex)));
            }
        }

        /// <summary>
        /// Get all creditcard by bankId
        /// </summary>
        /// <param name="bankId"></param>
        /// <returns></returns>
        [HttpGet("bank/{bankId}/creditcard")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterCreditCard>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCreditCard(int bankId)
        {
            try
            {
                var Resources = await _masterdataService.GetAllCreditCard(bankId);
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterCreditCard>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterCreditCard>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterCreditCard>>(ex)));
            }
        }

        /// <summary>
        /// Get all creditcard swipe
        /// </summary>
        /// <returns></returns>
        [HttpGet("creditcard/swipe")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterCardUseType>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCreditCardSwipe()
        {
            try
            {
                var Resources = await _masterdataService.GetAllCreditCardSwipe();
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterCardUseType>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterCardUseType>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterCardUseType>>(ex)));
            }
        }

        /// <summary>
        /// Get all position
        /// </summary>
        /// <returns></returns>
        [HttpGet("position")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterPosition>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPosition()
        {
            try
            {
                var Resources = await _masterdataService.GetAllPosition();
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterPosition>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterPosition>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterPosition>>(ex)));
            }
        }

        /// <summary>
        /// Get all prefix
        /// </summary>
        /// <returns></returns>
        [HttpGet("prefix")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterPrefix>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPrefix()
        {
            try
            {
                var Resources = await _masterdataService.GetAllPrefixName();
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterPrefix>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterPrefix>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterPrefix>>(ex)));
            }
        }

        /// <summary>
        /// Get all nextservice
        /// </summary>
        /// <returns></returns>
        [HttpGet("nextservice")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterNextService>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetNextService()
        {
            try
            {
                var Resources = await _masterdataService.GetAllNextService();
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterNextService>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterNextService>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterNextService>>(ex)));
            }
        }

        /// <summary>
        /// Get all subnextservice by nextserviceId
        /// </summary>
        /// <param name="nextserviceId"></param>
        /// <returns></returns>
        [HttpGet("nextservice/{nextserviceId}/subnextservice")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterNextServiceSub>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSubNextService(int nextserviceId)
        {
            try
            {
                var Resources = await _masterdataService.GetAllSubNextService(nextserviceId);
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterNextServiceSub>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterNextServiceSub>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterNextServiceSub>>(ex)));
            }
        }

        /// <summary>
        /// Get all province
        /// </summary>
        /// <returns></returns>
        [HttpGet("province")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterProvince>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProvince()
        {
            try
            {
                var Resources = await _masterdataService.GetAllProvince();
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterProvince>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterProvince>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterProvince>>(ex)));
            }
        }

        /// <summary>
        /// Get all district by provinceId
        /// </summary>
        /// <param name="provinceId"></param>
        /// <returns></returns>
        [HttpGet("province/{provinceId}/district")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterDistrict>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDistrictByProvinceId(int provinceId)
        {
            try
            {
                var Resources = await _masterdataService.GetAllDistrictByProvinceId(provinceId);
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterDistrict>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterDistrict>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterDistrict>>(ex)));
            }
        }

        /// <summary>
        /// Get all subdistrict by provinceId and districtId
        /// </summary>
        /// <param name="provinceId"></param>
        /// <param name="districtId"></param>
        /// <returns></returns>
        [HttpGet("province/{provinceId}/district/{districtId}/subdistrict")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterSubDistrict>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSubDistrictByProvinceId(int provinceId, int districtId)
        {
            try
            {
                var Resources = await _masterdataService.GetAllSubDistrictByProvinceId(provinceId, districtId);
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterSubDistrict>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterSubDistrict>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterSubDistrict>>(ex)));
            }
        }

        /// <summary>
        /// Get all dot
        /// </summary>
        /// <returns></returns>
        [HttpGet("dot")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterDot>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDot()
        {
            try
            {
                var Resources = await _masterdataService.GetAllDot();
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterDot>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterDot>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterDot>>(ex)));
            }
        }

        /// <summary>
        /// Get all car type
        /// </summary>
        /// <returns></returns>
        [HttpGet("car/type")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterCarType>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCarType()
        {
            try
            {
                var Resources = await _masterdataService.GetAllCarType();
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterCarType>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterCarType>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterCarType>>(ex)));
            }
        }

        /// <summary>
        /// Get all car brand
        /// </summary>
        /// <returns></returns>
        [HttpGet("car/brand")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterCarBrand>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCarBrands()
        {
            try
            {
                var Resources = await _masterdataService.GetAllCarBrand();
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterCarBrand>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterCarBrand>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterCarBrand>>(ex)));
            }
        }

        /// <summary>
        /// Get all car model
        /// </summary>
        /// <returns></returns>
        [HttpGet("car/model")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterCarModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCarModels()
        {
            try
            {
                var Resources = await _masterdataService.GetAllCarModel();
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterCarModel>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterCarModel>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterCarModel>>(ex)));
            }
        }

        /// <summary>
        /// Get all car brand by cartypeId
        /// </summary>
        /// <param name="cartypeId"></param>
        /// <returns></returns>
        [HttpGet("car/type/{cartypeId}/brand")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterCarBrand>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCarBrand(int cartypeId)
        {
            try
            {
                var Resources = await _masterdataService.GetAllCarBrandByCarTypeId(cartypeId);
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterCarBrand>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterCarBrand>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterCarBrand>>(ex)));
            }
        }

        /// <summary>
        /// Get all car model by carbrandId
        /// </summary>
        /// <param name="carbrandId"></param>
        /// <returns></returns>
        [HttpGet("car/brand/{carbrandId}/model")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterCarModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCarModel(int carbrandId)
        {
            try
            {
                var Resources = await _masterdataService.GetAllCarModelByCarBrandId(carbrandId);
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterCarModel>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterCarModel>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterCarModel>>(ex)));
            }
        }

        /// <summary>
        /// Get all car submodel by carmodelId
        /// </summary>
        /// <param name="carmodelId"></param>
        /// <returns></returns>
        [HttpGet("car/model/{carmodelId}/submodel")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterCarSubModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCarSubModel(int carmodelId)
        {
            try
            {
                var Resources = await _masterdataService.GetAllCarSubModelByCarModelId(carmodelId);
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterCarSubModel>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterCarSubModel>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterCarSubModel>>(ex)));
            }
        }

        /// <summary>
        /// Get all car gear
        /// </summary>
        /// <returns></returns>
        [HttpGet("car/gear")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterCarGear>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCarGear()
        {
            try
            {
                var Resources = await _masterdataService.GetAllCarGear();
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterCarGear>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterCarGear>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterCarGear>>(ex)));
            }
        }

        /// <summary>
        /// Get all progroup
        /// </summary>
        /// <returns></returns>
        [HttpGet("product/progroup")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterProGroup>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductGroup()
        {
            try
            {
                var Resources = await _masterdataService.GetAllProductGroups();
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterProGroup>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterProGroup>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterProGroup>>(ex)));
            }
        }

        /// <summary>
        /// Get all protype 
        /// </summary>
        /// <returns></returns>
        [HttpGet("product/protype")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterProType>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductType()
        {
            try
            {
                var Resources = await _masterdataService.GetAllProductTypes();
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterProType>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterProType>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterProType>>(ex)));
            }
        }

        /// <summary>
        /// Get all probrand 
        /// </summary>
        /// <returns></returns>
        [HttpGet("product/probrand")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterProBrand>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductBrand()
        {
            try
            {
                var Resources = await _masterdataService.GetAllProductBrands();
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterProBrand>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterProBrand>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterProBrand>>(ex)));
            }
        }

        /// <summary>
        /// Get all prosize
        /// </summary>
        /// <returns></returns>
        [HttpGet("product/prosize")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterProSize>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductSize()
        {
            try
            {
                var Resources = await _masterdataService.GetAllProductSize();
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterProSize>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterProSize>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterProSize>>(ex)));
            }
        }

        /// <summary>
        /// Get all protype by progroupId
        /// </summary>
        /// <param name="progroupId"></param>
        /// <returns></returns>
        [HttpGet("product/progroup/{progroupId}/protype")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterProType>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductTypes(int progroupId)
        {
            try
            {
                var Resources = await _masterdataService.GetAllProductTypeByProGroupId(progroupId);
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterProType>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterProType>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterProType>>(ex)));
            }
        }

        /// <summary>
        /// Get all probrand by protypeId
        /// </summary>
        /// <param name="protypeId"></param>
        /// <returns></returns>
        [HttpGet("product/protype/{protypeId}/probrand")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterProBrand>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductBrands(int protypeId)
        {
            try
            {
                var Resources = await _masterdataService.GetAllProductBrandByProTypeId(protypeId);
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterProBrand>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterProBrand>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterProBrand>>(ex)));
            }
        }

        /// <summary>
        /// Get all promodel by probrandId
        /// </summary>
        /// <param name="probrandId"></param>
        /// <returns></returns>
        [HttpGet("product/probrand/{probrandId}/promodel")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterPromodel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductModels(int probrandId)
        {
            try
            {
                var Resources = await _masterdataService.GetAllProductModelByProBrandId(probrandId);
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterPromodel>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterPromodel>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterPromodel>>(ex)));
            }
        }

        /// <summary>
        /// Get all product at location
        /// </summary>
        /// <returns></returns>
        [HttpGet("product/location")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterLocation>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLocation()
        {
            try
            {
                var Resources = await _masterdataService.GetAllProductLocation();
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterLocation>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterLocation>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterLocation>>(ex)));
            }
        }

        /// <summary>
        /// Get all product unit
        /// </summary>
        /// <returns></returns>
        [HttpGet("product/unit")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<MasterProUnit>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProUnit()
        {
            try
            {
                var Resources = await _masterdataService.GetAllProUnit();
                if (Resources == null)
                {
                    return Ok(new BaseResponse<IEnumerable<MasterProUnit>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<IEnumerable<MasterProUnit>>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = Resources
                    });
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<MasterProUnit>>(ex)));
            }
        }
    }
}
