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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Linq;

namespace Csp.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMasterDataService _masterDataService;
        private readonly IMapper _mapper;
        private readonly ICacheService _cache;
        private static string _cacheName = "Product";

        public ProductController(IProductService productService, IMasterDataService masterDataService, ICacheService cache, IMapper mapper)
        {
            _productService = productService;
            _masterDataService = masterDataService;
            _mapper = mapper;
            _cache = cache;
        }

        /// <summary>
        /// Get all product for manage-product, manage-old-product, manage-supplies, customer-price-group
        /// </summary>
        /// <param name="productType">
        /// (default) product, oldproduct, supplies
        /// </param>
        /// <param name="page"></param>
        /// <param name="perPage"></param>
        /// <param name="orderBy"></param>
        /// <param name="orderasc"></param>
        /// <returns></returns>
        [HttpGet("{productType}")]
        //[HttpGet("saleprice/customergroup")] Phase 2 
        [ProducesResponseType(typeof(IEnumerable<ProductItem>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(
            [FromRoute] string productType = "product",
            [FromQuery] int page = 1,
            [FromQuery] int perPage = 10,
            [FromQuery] string orderBy = "UpdatedAt",
            [FromQuery] bool orderasc = false)
        {
            try
            {
                var cacheKey = HashHelper.TextToHash($"allProductsType{productType}");
                var cacheTotalCount = _cache.GetCacheValue<string>(cacheKey);

                var products = await _productService.SearchProductByField(null, page, perPage, orderBy, orderasc);
                if (products == null)
                {
                    return Ok(new PagedResponse<IEnumerable<Product>>(null, 0, page, perPage, orderBy, orderasc)
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    //var searchParams = new Dictionary<string, string>() { { "Types", ((int)Enum.Parse<ProductTypes>(productType)).ToString() } };
                    if (cacheTotalCount == null)
                    {
                        cacheTotalCount = (await _productService.GetTotalCountSearchProductByField(null)).ToString();
                        _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                    }
                    var productItems = _mapper.Map<IEnumerable<ProductItem>>(products);
                    int totalCount = Convert.ToInt32(cacheTotalCount);
                    return Ok(new PagedResponse<IEnumerable<ProductItem>>(productItems, totalCount, page, perPage, orderBy, orderasc)
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = productItems
                    });
                }
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<ProductItem>>(ex)));
            }
        }

        /// <summary>
        /// Search all product for manage-product, manage-old-product, manage-supplies, customer-price-group
        /// </summary>
        /// <param name="productType">
        /// (default) product, oldproduct, supplies
        /// </param>
        /// <param name="searchParams"></param>
        /// <param name="page"></param>
        /// <param name="perPage"></param>
        /// <param name="orderBy"></param>
        /// <param name="orderasc"></param>
        /// <returns></returns>
        [HttpPost("{productType}/Search")]
        //[HttpPost("saleprice/customergroup/Search")] Phase 2
        [ProducesResponseType(typeof(IEnumerable<ProductItem>), StatusCodes.Status200OK)]
        public async Task<IActionResult> SearchAllProduct(
            [FromRoute] string productType = "product",
            [FromBody] Dictionary<string, string> searchParams = null,
            [FromQuery] int page = 1,
            [FromQuery] int perPage = 10,
            [FromQuery] string orderBy = "UpdatedAt",
            [FromQuery] bool orderasc = false)
        {
            try
            {
                searchParams.Add("Types", ((int)Enum.Parse<ProductTypes>(productType)).ToString());

                var p = new ArrayList();
                var searchTmp = searchParams.ToDictionary(entry => entry.Key, entry => entry.Value);

                foreach (var searchParam in searchTmp)
                {

                    switch (searchParam.Key)
                    {
                        case "ProTypeName":
                            var tmpPT = (await _masterDataService.GetAllProductTypes()).Where(pt => pt.Name == searchParam.Value).SingleOrDefault();
                            p.Add(string.Format("{0} = '{1}'", "ProTypeID", tmpPT.Id));

                            searchParams.Remove("ProTypeName");
                            searchParams.Add("product.ProTypeID", (tmpPT.Id).ToString());
                            break;
                        case "ProBrandName":
                            var tmpPB = (await _masterDataService.GetAllProductBrands()).Where(pb => pb.Name == searchParam.Value).SingleOrDefault();
                            p.Add(string.Format("{0} = '{1}'", "ProBrandID", tmpPB.Id));

                            searchParams.Remove("ProBrandName");
                            searchParams.Add("product.ProBrandID", (tmpPB.Id).ToString());
                            break;
                        case "ProModelName":
                            var tmpPM = (await _masterDataService.GetAllProductTypes()).Where(pm => pm.Name == searchParam.Value).SingleOrDefault();
                            p.Add(string.Format("{0} = '{1}'", "ProModelID", tmpPM.Id));

                            searchParams.Remove("ProModelName");
                            searchParams.Add("product.ProModelID", (tmpPM.Id).ToString());
                            break;
                        case "ProSizeName":
                            var tmpPS = (await _masterDataService.GetAllProductTypes()).Where(ps => ps.Name == searchParam.Value).SingleOrDefault();
                            p.Add(string.Format("{0} = '{1}'", "ProSizeID", tmpPS.Id));

                            searchParams.Remove("ProSizeName");
                            searchParams.Add("product.ProSizeID", (tmpPS.Id).ToString());
                            break;
                        default:
                            p.Add(string.Format("{0} = '{1}'", searchParam.Key, searchParam.Value));
                            break;
                    }
                }
                var searchString = p.Count == 0 ? "1=1" : String.Join(" and ", p.ToArray());

                var cacheKey = HashHelper.TextToHash(searchString);
                var cacheTotalCount = _cache.GetCacheValue<string>(cacheKey);

                var products = await _productService.SearchProductByField(searchParams, page, perPage, orderBy, orderasc);
                if (products == null)
                {
                    return Ok(new PagedResponse<IEnumerable<object>>(null, 0, page, perPage, orderBy, orderasc)
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    if (cacheTotalCount == null)
                    {
                        cacheTotalCount = (await _productService.GetTotalCountSearchProductByField(searchParams)).ToString();
                        _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                    }
                    var productItems = _mapper.Map<IEnumerable<ProductItem>>(products);
                    int totalCount = Convert.ToInt32(cacheTotalCount);
                    return Ok(new PagedResponse<IEnumerable<ProductItem>>(productItems, totalCount, page, perPage, orderBy, orderasc)
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = productItems
                    });
                }
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<ProductItem>>(ex)));
            }
        }

        //Phase 2 
        //[HttpGet("saleprice")]
        //[ProducesResponseType(typeof(IEnumerable<object>), StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetAllProductSalePrice(
        //    [FromQuery] int page = 1,
        //    [FromQuery] int perPage = 10,
        //    [FromQuery] string orderBy = "UpdatedAt",
        //    [FromQuery] bool orderasc = false)
        //{
        //    try
        //    {
        //        (IEnumerable<object> Resources, int TotalRecords) = await _productService.GetAllProductSalePrice(null,
        //                                                                                                page,
        //                                                                                                perPage,
        //                                                                                                orderBy,
        //                                                                                                orderasc);
        //        if (Resources == null)
        //        {
        //            return Ok(new PagedResponse<IEnumerable<object>>(null, 0, page, perPage, orderBy, orderasc)
        //            {
        //                Message = "Not Found",
        //                StatusCode = 404
        //            });
        //        }
        //        else
        //        {
        //            return Ok(new PagedResponse<IEnumerable<object>>(Resources, TotalRecords, page, perPage, orderBy, orderasc)
        //            {
        //                Message = "Sucess",
        //                StatusCode = 200,
        //                Resource = Resources
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<object>>(ex)));
        //    }
        //}

        //Phase 2 
        //[HttpPost("saleprice/Search")]
        //[ProducesResponseType(typeof(IEnumerable<object>), StatusCodes.Status200OK)]
        //public async Task<IActionResult> SearchAllProductSalePrice(
        //    [FromBody] Dictionary<string, string> searchParams,
        //    [FromQuery] int page = 1,
        //    [FromQuery] int perPage = 10,
        //    [FromQuery] string orderBy = "UpdatedAt",
        //    [FromQuery] bool orderasc = false)
        //{
        //    try
        //    {
        //        (IEnumerable<object> Resources, int TotalRecords) = await _productService.SearchProductByField(searchParams,
        //                                                                                                page,
        //                                                                                                perPage,
        //                                                                                                orderBy,
        //                                                                                                orderasc);
        //        if (Resources == null)
        //        {
        //            return Ok(new PagedResponse<IEnumerable<object>>(null, 0, page, perPage, orderBy, orderasc)
        //            {
        //                Message = "Not Found",
        //                StatusCode = 404
        //            });
        //        }
        //        else
        //        {
        //            return Ok(new PagedResponse<IEnumerable<object>>(Resources, TotalRecords, page, perPage, orderBy, orderasc)
        //            {
        //                Message = "Sucess",
        //                StatusCode = 200,
        //                Resource = Resources
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<object>>(ex)));
        //    }
        //}

        /// <summary>
        /// Get Product by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productType">
        /// (default) product, oldproduct, supplies
        /// </param>
        /// <returns></returns>
        [HttpGet("{productType}/{id}")]
        [ProducesResponseType(typeof(BaseResponse<ProductModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<ProductModel>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductById(int id, [FromRoute] string productType = "product")
        {
            BaseResponse<ProductModel> result;
            try
            {
                var product = await _productService.GetProductById(id);
                if (product.product == null)
                {
                    result = new BaseResponse<ProductModel>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    };
                }
                else
                {
                    var productVO = _mapper.Map<ProductModel>(product.product);
                    productVO.ProductSalePrice = product.saleprice;
                    result = new BaseResponse<ProductModel>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = productVO
                    };
                }
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<ProductModel>(ex)));
            }

            return Ok(result);
        }

        /// <summary>
        /// Create new Product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ProductModel model)
        {
            Product product =  _mapper.Map<Product>(model);
            try
            {
                var newProduct = await _productService.Create(product, model.ProductSalePrice);
                if(newProduct == null)
                    throw new Exception("cannot create product");

                return Ok(new BaseResponse<Product>
                {
                    StatusCode = 200,
                    Message = "Success"
                });
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<object>(ex)));
            }
        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] ProductModel model)
        {
            Product product = (await _productService.GetProductById(model.Id)).product;

            var updatedProduct = _mapper.Map<ProductModel, Product>(model);
            updatedProduct.CreatedAt = product.CreatedAt;
            updatedProduct.CreatedBy = product.CreatedBy;

            try
            {
                var process = await _productService.Update(updatedProduct, model.ProductSalePrice);
                return Ok(new BaseResponse<Product>
                {
                    Message = process ? "Success" : "Failure",
                    StatusCode = process ? 200 : 304
                });
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<object>(ex)));
            }
        }

        //Phase 2 
        //[HttpPut("saleprice/{id}")]
        //public async Task<IActionResult> UpdateSalePriceAsync(int id, [FromBody] ProductModel model)
        //{
        //    var product = _mapper.Map<Product>(model);
        //    try
        //    {
        //        var process = await _productService.Update(product);
        //        return Ok(new BaseResponse<Product>
        //        {
        //            Message = process ? "Success" : "Failure",
        //            StatusCode = process ? 200 : 304
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok((ExceptionReponseHelper.CustomExceptionHandler<object>(ex)));
        //    }
        //}

        #region Return all product paging for sale process
        /// <summary>
        /// Get all product for saleprocess
        /// </summary>
        /// <param name="productType">
        /// product, oldproduct, supplies
        /// </param>
        /// <param name="page"></param>
        /// <param name="perPage"></param>
        /// <param name="orderBy"></param>
        /// <param name="orderasc"></param>
        /// <returns></returns>
        //[HttpGet("sale/{productType}")]
        //[ProducesResponseType(typeof(IEnumerable<object>), StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetAllProductForSale(
        //    [FromRoute] string productType,
        //    [FromQuery] int page = 1,
        //    [FromQuery] int perPage = 10,
        //    [FromQuery] string orderBy = "UpdatedAt",
        //    [FromQuery] bool orderasc = false)
        //{
        //    /*
        //    ขาย
        //    ใบสั่งซ่อม
        //    tab สินค้า/บริการ => สินค้า
        //    tab สินค้าเก่า => สินค้าเก่า
        //    ใบเสนอราคา  => สินค้า
        //    ใบรับมัดจำ => สินค้า

        //    จัดซื้อ => สินค้า
        //    รับเข้า => สินค้า

        //    ค่าใช้จ่าย/วัสดุสิ้นเปลือง
        //    => สินค้าวัสดุสิ้นเปลือง
        //     */
        //    try
        //    {
        //        var searchParams = new Dictionary<string, string>() { { "Types", ((int)Enum.Parse<ProductTypes>(productType)).ToString() } };
        //        //(IEnumerable<object> Resources, int TotalRecords) = await _productService.GetAllProductForSaleProcess(searchParams,
        //        //                                                                                        page,
        //        //                                                                                        perPage,
        //        //                                                                                        orderBy,
        //        //                                                                                        orderasc);

        //        (IEnumerable<object> Resources, int TotalRecords) = (null, 0);
        //        if (Resources == null)
        //        {
        //            return Ok(new PagedResponse<IEnumerable<object>>(null, 0, page, perPage, orderBy, orderasc)
        //            {
        //                Message = "Not Found",
        //                StatusCode = 404
        //            });
        //        }
        //        else
        //        {
        //            return Ok(new PagedResponse<IEnumerable<object>>(Resources, TotalRecords, page, perPage, orderBy, orderasc)
        //            {
        //                Message = "Sucess",
        //                StatusCode = 200,
        //                Resource = Resources
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<object>>(ex)));
        //    }
        //}

        /// <summary>
        /// Search all product for saleprocess
        /// </summary>
        /// <param name="productType">
        ///  product, oldproduct, supplies
        /// </param>
        /// <param name="searchParams"></param>
        /// <param name="page"></param>
        /// <param name="perPage"></param>
        /// <param name="orderBy"></param>
        /// <param name="orderasc"></param>
        /// <returns></returns>
        //[HttpPost("sale/{productType}/Search")]
        //[ProducesResponseType(typeof(IEnumerable<object>), StatusCodes.Status200OK)]
        //public async Task<IActionResult> SearchAllProductForSale(
        //    [FromRoute] string productType,
        //    [FromBody] Dictionary<string, string> searchParams,
        //    [FromQuery] int page = 1,
        //    [FromQuery] int perPage = 10,
        //    [FromQuery] string orderBy = "UpdatedAt",
        //    [FromQuery] bool orderasc = false)
        //{
        //    try
        //    {
        //        //if (searchParams == null)
        //        //    searchParams = new Dictionary<string, string>() { { "Types", ((int)Enum.Parse<ProductTypes>(productType)).ToString() } };
        //        //else
        //        searchParams.Add("Types", ((int)Enum.Parse<ProductTypes>(productType)).ToString());
        //        //(IEnumerable<object> Resources, int TotalRecords) = await _productService.GetAllProductForSaleProcess(searchParams,
        //        //                                                                                        page,
        //        //                                                                                        perPage,
        //        //                                                                                        orderBy,
        //        //                                                                                        orderasc);

        //        (IEnumerable<object> Resources, int TotalRecords) = (null, 0);
        //        if (Resources == null)
        //        {
        //            return Ok(new PagedResponse<IEnumerable<object>>(null, 0, page, perPage, orderBy, orderasc)
        //            {
        //                Message = "Not Found",
        //                StatusCode = 404
        //            });
        //        }
        //        else
        //        {
        //            return Ok(new PagedResponse<IEnumerable<object>>(Resources, TotalRecords, page, perPage, orderBy, orderasc)
        //            {
        //                Message = "Sucess",
        //                StatusCode = 200,
        //                Resource = Resources
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<object>>(ex));
        //    }
        //}
        #endregion
    }
}
