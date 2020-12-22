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
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Linq;
using System.Collections;

namespace Csp.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/{contact}")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class ContactTypesController : ControllerBase
    {
        private readonly IContactTypesService _contactTypesService;
        private readonly IMapper _mapper;
        private readonly ICacheService _cache;
        private readonly IMasterDataService _masterDataService;

        public ContactTypesController(IContactTypesService contactTypesService, IMapper mapper, ICacheService cache, IMasterDataService masterDataService)
        {
            _contactTypesService = contactTypesService;
            _mapper = mapper;
            _cache = cache;
            _masterDataService = masterDataService;
        }

        /// <summary>
        /// Get All Customer by 
        /// passing them as contact type flag return as List
        /// </summary>
        /// <param name="contact">Customer</param>
        /// <param name="page">Page number</param>
        /// <param name="perPage">Item Per Page</param>
        /// <param name="orderBy">Order By Field</param>
        /// <param name="orderasc">True : Order By ASC | False : Order By DESC</param>
        /// <returns></returns>
        [HttpGet("/api/v{version:apiVersion}/{contact}")]
        public async Task<IActionResult> GetAll(
            [FromRoute] string contact = "customer",
            [FromQuery] int page = 1,
            [FromQuery] int perPage = 10,
            [FromQuery] string orderBy = "Code",
            [FromQuery] bool orderasc = false)
        {
            IEnumerable<Contact> result = null;
            Dictionary<string, string> searchParams;
            int contactTypes = 0, totalCount = 0;
            string cacheKey = "", cacheTotalCount = "";
            try
            {
                switch (contact.ToLower())
                {
                    //Phase2
                    //case "vender":
                    //    contactTypes = (int)Enum.Parse<ContactTypes>("vender");
                    //    searchParams = new Dictionary<string, string>() { { "Types", contactTypes.ToString() } };
                    //    result = await _contactTypesService.GetAllVenderByPageIndex(searchParams, page, perPage, orderBy, orderasc);

                    //    cacheKey = HashHelper.TextToHash("allVenders");

                    //    cacheTotalCount = _cache.GetCacheValue<string>(cacheKey);

                    //    if (cacheTotalCount == null)
                    //    {
                    //        cacheTotalCount = (await _contactTypesService.GetTotalNumberVender(searchParams)).ToString();
                    //        _cache.SetCacheValue<string>("Vender", cacheKey, cacheTotalCount);
                    //    }
                    //    totalCount = Convert.ToInt32(cacheTotalCount);
                    //    break;
                    case "customer":
                        contactTypes = (int)Enum.Parse<ContactTypes>("customer");
                        searchParams = new Dictionary<string, string>();
                        searchParams.Add("Types", contactTypes.ToString());
                        result = await _contactTypesService.GetAllCustomerByPageIndex(searchParams, page, perPage, orderBy, orderasc);

                        cacheKey = HashHelper.TextToHash("allCustomers");

                        cacheTotalCount = _cache.GetCacheValue<string>(cacheKey);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _contactTypesService.GetTotalNumberCustomer(searchParams)).ToString();
                            _cache.SetCacheValue<string>("Customer", cacheKey, cacheTotalCount);
                        }
                        totalCount = Convert.ToInt32(cacheTotalCount);
                        break;
                    default:
                        throw new BadParametersException(String.Format("The contact type named {0} could not be found.", contact));
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
                    IEnumerable<object> resultItems = null;
                    switch (contact.ToLower())
                    {
                        //Phase2
                        //case "vender":
                        //    resultItems = _mapper.Map<IEnumerable<VenderItem>>(result);
                        //    break;
                        case "customer":
                            resultItems = _mapper.Map<IEnumerable<CustomerItem>>(result);
                            break;
                    }
                    return Ok(new PagedResponse<IEnumerable<object>>(resultItems, totalCount, page, perPage, orderBy, orderasc)
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = resultItems
                    });
                }
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<object>>(ex)));
            }
        }

        /// <summary>
        /// Search by Field Customer by 
        /// passing them as contact type flag return as List
        /// </summary>
        /// <param name="contact">Customer</param>
        /// <param name="searchParams">Custom Parameters</param>
        /// <param name="page">Page number</param>
        /// <param name="perPage">Item Per Page</param>
        /// <param name="orderBy">Order By Field</param>
        /// <param name="orderasc">True : Order By ASC | False : Order By DESC</param>
        /// <returns></returns>
        [HttpPost("/api/v{version:apiVersion}/{contact}/Search")]
        public async Task<IActionResult> Search(
            [FromBody] Dictionary<string, string> searchParams,
            [FromRoute] string contact = "customer",
            [FromQuery] int page = 1,
            [FromQuery] int perPage = 10,
            [FromQuery] string orderBy = "Code",
            [FromQuery] bool orderasc = false
            )
        {
            IEnumerable<Contact> result = null;
            int contactTypes = 0, totalCount = 0;
            string cacheKey = "", cacheTotalCount = "",value;
            try
            {
                var p = new ArrayList();
                

                switch (contact.ToLower())
                {
                    //case "vender":
                    //    contactTypes = (int)Enum.Parse<ContactTypes>("vender");
                    //    searchParams = new Dictionary<string, string>() { { "Types", contactTypes.ToString() } };
                    //    result = await _contactTypesService.GetAllVenderByPageIndex(searchParams, page, perPage, orderBy, orderasc);

                    //    if (cacheTotalCount == null)
                    //    {
                    //        cacheTotalCount = (await _contactTypesService.GetTotalNumberVender(searchParams)).ToString();
                    //        _cache.SetCacheValue<string>("Vender", cacheKey, cacheTotalCount);
                    //    }
                    //    totalCount = Convert.ToInt32(cacheTotalCount);
                    //    break;
                    case "customer":
                        contactTypes = (int)Enum.Parse<ContactTypes>("customer");
                        searchParams.Add("Types", contactTypes.ToString());
                        var searchTmp = searchParams.ToDictionary(entry => entry.Key, entry => entry.Value);
                        
                        foreach (var searchParam in searchTmp)
                        {
                            switch (searchParam.Key)
                            {
                                case "Code":
                                    searchParams.TryGetValue("Code",out value);
                                    searchParams.Remove("Code");
                                    searchParams.Add("contact.Code", value);
                                    break;
                                case "Name":
                                    searchParams.TryGetValue("Name", out value);
                                    searchParams.Remove("Name");
                                    searchParams.Add("contact.Name", value);
                                    break;
                                case "PrefixName":
                                    var tmpPT = (await _masterDataService.GetAllPrefixName()).Where(pf => pf.Name == searchParam.Value).SingleOrDefault();
                                    p.Add(string.Format("{0} = '{1}'", "PrefixID", tmpPT.Id));

                                    searchParams.Remove("PrefixName");
                                    searchParams.Add("contact.PrefixID", (tmpPT.Id).ToString());
                                    break;
                                case "ProvinceName":
                                    var tmpPB = (await _masterDataService.GetAllProvince()).Where(pv => pv.Name == searchParam.Value).SingleOrDefault();
                                    p.Add(string.Format("{0} = '{1}'", "ProvinceID", tmpPB.Id));

                                    searchParams.Remove("ProvinceName");
                                    searchParams.Add("contact.ProvinceID", (tmpPB.Id).ToString());
                                    break;
                                case "ContactTypeName":
                                    var tmpPM = (await _masterDataService.GetAllContactType()).Where(ct => ct.Name == searchParam.Value).SingleOrDefault();
                                    p.Add(string.Format("{0} = '{1}'", "ContactTypeID", tmpPM.Id));

                                    searchParams.Remove("ContactTypeName");
                                    searchParams.Add("contact.ContactTypeID", (tmpPM.Id).ToString());
                                    break;
                                default:
                                    p.Add(string.Format("{0} = '{1}'", searchParam.Key, searchParam.Value));
                                    break;
                            }
                        }

                        var searchString = p.Count == 0 ? "1=1" : String.Join(" AND ", p.ToArray());

                        cacheKey = HashHelper.TextToHash(searchString);
                        cacheTotalCount = _cache.GetCacheValue<string>(cacheKey);

                        result = await _contactTypesService.GetAllCustomerByPageIndex(searchParams, page, perPage, orderBy, orderasc);

                        if (cacheTotalCount == null)
                        {
                            cacheTotalCount = (await _contactTypesService.GetTotalNumberCustomer(searchParams)).ToString();
                            _cache.SetCacheValue<string>("Customer", cacheKey, cacheTotalCount);
                        }
                        totalCount = Convert.ToInt32(cacheTotalCount);
                        break;
                    default:
                        throw new BadParametersException(String.Format("The contact type named {0} could not be found.", contact));
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
                    IEnumerable<object> resultItems = null;
                    switch (contact.ToLower())
                    {
                        //case "vender":
                        //    resultItems = _mapper.Map<IEnumerable<VenderItem>>(result);
                        //    break;
                        case "customer":
                            resultItems = _mapper.Map<IEnumerable<CustomerItem>>(result);
                            break;
                        default:
                            throw new BadParametersException("Not found contact type");
                    }

                    return Ok(new PagedResponse<IEnumerable<object>>(resultItems, totalCount, page, perPage, orderBy, orderasc)
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = resultItems
                    });
                }
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<object>>(ex)));
            }
        }

        /// <summary>
        /// Get specific data by ID or Customer by 
        /// passing them as contact type flag
        /// </summary>
        /// <param name="contact">Customer</param>
        /// <param name="id">ID of Customer</param>
        /// <returns></returns>
        [HttpGet("/api/v{version:apiVersion}/{contact}/{id}")]
        public async Task<IActionResult> Get(int id, [FromRoute]string contact = "customer")
        {
            object result = null;
            try
            {
                switch (contact.ToLower())
                {
                    //case "vender":
                    //    result = await _contactTypesService.GetVenderById(id);
                    //    break;
                    case "customer":
                        result = await _contactTypesService.GetCustomerById(id);
                        break;
                    default:
                        throw new BadParametersException(String.Format("The contact type named {0} could not be found.", contact));
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
                    object resultItems = null;
                    switch (contact.ToLower())
                    {
                        //case "vender":
                        //    resultItems = _mapper.Map<VenderModel>(result);
                        //    break;
                        case "customer":
                            resultItems = _mapper.Map<CustomerModel>(result);
                            break;
                    }
                    return Ok(new BaseResponse<object>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = resultItems
                    });
                }
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<object>(ex)));
            }
        }

        ///// <summary>
        ///// Create Vender
        ///// </summary>
        ///// <param name="model">Data of Vender</param>
        ///// <returns></returns>
        //[HttpPost("/api/v{version:apiVersion}/Vender")]
        //public async Task<IActionResult> PostVender([FromBody] VenderModel model)
        //{
        //    var vender = _mapper.Map<Contact>(model);
        //    try
        //    {
        //        var newVender = await _contactTypesService.CreateVender(vender);
        //        if (newVender != null) _cache.ClearCache("Vender");
        //        return Ok(new BaseResponse<Contact>
        //        {
        //            StatusCode = 200,
        //            Message = "Success"
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<Contact>>(ex)));
        //    }
        //}

        /// <summary>
        /// Create Customer
        /// </summary>
        /// <param name="model">Data of Customer</param>
        /// <returns></returns>
        [HttpPost("/api/v{version:apiVersion}/Customer")]
        public async Task<IActionResult> PostCustomer([FromBody] CustomerModel model)
        {
            var customer = _mapper.Map<Contact>(model);
            try
            {
                var newCustomer = await _contactTypesService.CreateCustomer(customer);
                if (newCustomer != null) _cache.ClearCache("Customer");
                return Ok(new BaseResponse<Contact>
                {
                    StatusCode = 200,
                    Message = "Success"
                });
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<Contact>>(ex)));
            }
        }

        ///// <summary>
        ///// Edit Vender
        ///// </summary>
        ///// <param name="model">Data of Vender</param>
        ///// <returns></returns>
        //[HttpPut("/api/v{version:apiVersion}/Vender")]
        //[ProducesResponseType(typeof(object), 201)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> PutVender([FromBody] VenderModel model)
        //{
        //    BaseResponse<Contact> result = null;
        //    try
        //    {
        //        var updatedVender = _mapper.Map<VenderModel, Contact>(model);

        //        var tmp = await _contactTypesService.UpdateVender(updatedVender);

        //        result = new BaseResponse<Contact>
        //        {
        //            Message = tmp ? "Success" : "Failure",
        //            StatusCode = tmp ? 200 : 304
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<Contact>>(ex)));
        //    }
        //    return Ok(result);
        //}

        /// <summary>
        /// Update Customer
        /// </summary>
        /// <param name="model">Data of Customer</param>
        /// <returns></returns>
        [HttpPut("/api/v{version:apiVersion}/Customer")]
        public async Task<IActionResult> PutCustomer([FromBody] CustomerModel model)
        {
            BaseResponse<Contact> result = null;
            try
            {
                var updatedCustomer = _mapper.Map<CustomerModel, Contact>(model);

                var tmp = await _contactTypesService.UpdateCustomer(updatedCustomer);

                result = new BaseResponse<Contact>
                {
                    Message = tmp ? "Success" : "Failure",
                    StatusCode = tmp ? 200 : 304
                };
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<Contact>>(ex)));
            }
            return Ok(result);
        }

    }
}
