using Csp.DAL.Models;
using Csp.Services.CustomeException;
using Csp.Services.Interfaces;
using AutoMapper;
using Csp.Api.Helper;
using Csp.Api.Models;
using Csp.Api.Models.Response;
using Csp.Logger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Csp.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;
        private readonly ICacheService _cache;
        private static string _cacheName = "Car";

        public CarController(ICarService carService, IMapper mapper, ICacheService cache)
        {
            _carService = carService;
            _mapper = mapper;
            _cache = cache;
    }

        /// <summary>
        /// Get All Cars by Customer Id return as List
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <param name="page">Page number</param>
        /// <param name="perPage">Item Per Page</param>
        /// <param name="orderBy">Order By Field</param>
        /// <param name="orderasc">True : Order By ASC | False : Order By DESC</param>
        /// <returns></returns>
        [HttpGet("/api/v{version:apiVersion}/[controller]/{customerId}")]
        [ProducesResponseType(typeof(IEnumerable<CarItem>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(
            [FromRoute] int customerId,
            [FromQuery] int page = 1,
            [FromQuery] int perPage = 10,
            [FromQuery] string orderBy = "RegisterDate",
            [FromQuery] bool orderasc = false)
        {
            Dictionary<string, string> searchParams = null;
            searchParams = new Dictionary<string, string>() { { "customer.ID", customerId.ToString() } };
            try
            {
                var cacheKey = HashHelper.TextToHash("allCars");

                var cacheTotalCount = _cache.GetCacheValue<string>(cacheKey);

                if (cacheTotalCount == null)
                {
                    cacheTotalCount = (await _carService.GetTotalNumberCar(searchParams)).ToString();
                    _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                }
                               
                var cars = await _carService.GetAllCarByPageIndex(searchParams, page, perPage, orderBy, orderasc);
                int totalCount = Convert.ToInt32(cacheTotalCount);

                if (cars == null)
                {
                    return Ok(new BaseResponse<IEnumerable<CarItem>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    var carItems = _mapper.Map<IEnumerable<CarItem>>(cars);

                    return Ok(new PagedResponse<IEnumerable<CarItem>>(carItems, totalCount, page, perPage, orderBy, orderasc)
                    {
                        Message = "Success",
                        StatusCode = 200,
                        Resource = carItems
                    });
                }
            }
             
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<Car>>(ex)));
            }
        }

        /// <summary>
        /// Get specific Car data by ID
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <param name="carId">Car Id</param>
        /// <returns></returns>
        [HttpGet("/api/v{version:apiVersion}/[controller]/{customerId}/{carId}")]
        [ProducesResponseType(typeof(CarModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] int customerId, [FromRoute] int carId)
        {
            try
            {
                var car = await _carService.GetCarById(carId);
                if (car == null)
                {
                    return Ok(new BaseResponse<CarModel>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<CarModel>
                    {
                        Message = "Success",
                        StatusCode = 200,
                        Resource = _mapper.Map<CarModel>(car)
                    });
                }
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<CarModel>(ex)));
            }
        }

        /// <summary>
        /// Create Car
        /// </summary>
        /// <param name="model">Car Data</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostVender([FromBody] CarModel model)
        {
            var car = _mapper.Map<Car>(model);
            try
            {
                var newCar = await _carService.CreateCar(car);
                if (newCar != null) _cache.ClearCache(_cacheName);
                return Ok(new BaseResponse<Car>
                {
                    StatusCode = 200,
                    Message = "Success"
                });
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<Car>>(ex)));
            }
        }

        /// <summary>
        /// Update Car
        /// </summary>
        /// <param name="model">Car Data</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(object), 201)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync([FromBody] CarModel model)
        {
            var car = _mapper.Map<Car>(model);
            try
            {
                var updateCar = await _carService.UpdateCar(car);

                return Ok(new BaseResponse<Car>
                {
                    StatusCode = 200,
                    Message = "Success"
                });
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<Car>>(ex)));
            }
        }

        /// <summary>
        /// Cancel Car by Id
        /// </summary>
        /// <param name="id">Car Id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                bool cancelCar = await _carService.DeleteCar(id);
                if (cancelCar) _cache.ClearCache(_cacheName);
                return Ok(new BaseResponse<User>
                {
                    Message = cancelCar ? "Success" : "Failure",
                    StatusCode = cancelCar ? 200 : 304
                });
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<Car>>(ex))); ;
            }
        }

        /// <summary>
        /// Tranfer Car to new Customer
        /// </summary>
        /// <param name="id">Car Id</param>
        /// <param name="customerId">new Customer Id</param>
        /// <returns></returns>
        [HttpPut("/api/v{version:apiVersion}/[controller]/TranferCar/{id}/CustomerId/{customerId}")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TranferCar(int id, int customerId)
        {
            try
            {
                bool tranferCar = await _carService.TranferCar(id, customerId);

                return Ok(new BaseResponse<Car>
                {
                    StatusCode = 200,
                    Message = "Success"
                });
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<Car>>(ex))); ;
            }
        }

        /// <summary>
        /// Replace Red Car Registration to correct Car Registration
        /// </summary>
        /// <param name="id">Car Id</param>
        /// <param name="code">new Car Registration</param>
        /// <param name="provinceId">new Car Province</param>
        /// <returns></returns>
        [HttpPut("/api/v{version:apiVersion}/[controller]/ReplaceCarRegistration/{id}/NewCarRegistration/{code}/ProvinceId/{provinceId}")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ReplaceCarRegistration(int id, string code, int provinceId)
        {
            try
            {
                bool registrationCar = await _carService.ReplaceCarRegistration(id, code, provinceId);

                return Ok(new BaseResponse<Car>
                {
                    StatusCode = 200,
                    Message = "Success"
                });
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<Car>>(ex))); ;
            }
        }
    }
}
