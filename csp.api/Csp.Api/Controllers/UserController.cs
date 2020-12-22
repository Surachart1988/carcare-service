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
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Csp.Api.Controllers
{
    /// <summary>
    /// Provide User(Employee) Resources 
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ICacheService _cache;
        private static string _cacheName = "User";

        /// <summary>
        /// Construtor 
        /// </summary>
        /// <param name="userService">userservice</param>
        /// <param name="mapper">automapper</param>
        public UserController(IUserService userService, ICacheService cache, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
            _cache = cache;
        }

        /// <summary>
        /// Provide get all User(Employee)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="perPage"></param>
        /// <param name="orderBy"></param>
        /// <param name="orderasc"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserItem>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(
            [FromQuery] int page = 1,
            [FromQuery] int perPage = 10,
            [FromQuery] string orderBy = "UpdatedAt",
            [FromQuery] bool orderasc = false)
        {
            BaseResponse<IEnumerable<UserItem>> result = null;
            try
            {
                var cacheKey = HashHelper.TextToHash("allUsers");

                var cacheTotalCount =  _cache.GetCacheValue<string>(cacheKey);

                if (cacheTotalCount == null)
                {
                    cacheTotalCount = (await _userService.GetTotalSrchUsrByField(null)).ToString();
                    _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                }

                var users = await _userService.SrchUsrByField(null, page, perPage, orderBy, orderasc);
                int totalCount = Convert.ToInt32(cacheTotalCount);

                if (users == null)
                {
                    result = new BaseResponse<IEnumerable<UserItem>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    };
                }
                else
                {
                    var userItems = _mapper.Map<IEnumerable<UserItem>>(users);

                    result = new PagedResponse<IEnumerable<UserItem>>(userItems, totalCount, page, perPage, orderBy, orderasc)
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = userItems
                    };
                }
            }
             
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<User>>(ex)));
            }

            return Ok(result);
        }

        /// <summary>
        /// Provide search User(Employee) by customer parameters
        /// </summary>
        /// <param name="searchParams">custom parameters</param>
        /// <param name="page">page</param>
        /// <param name="perPage">item per page</param>
        /// <param name="orderBy">Order by field </param>
        /// <param name="orderasc">true: order by asc, false: order by desc</param>
        /// <returns>serached customer by parameters as json string</returns>
        [HttpPost("/api/v{version:apiVersion}/User/Search")]
        [ProducesResponseType(typeof(IEnumerable<UserItem>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Search(
            [FromBody] Dictionary<string,string> searchParams,
            [FromQuery] int page = 1,
            [FromQuery] int perPage = 10,
            [FromQuery] string orderBy = "UpdatedAt",
            [FromQuery] bool orderasc = false)
        {
            BaseResponse<IEnumerable<UserItem>> result = null;
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
                //string cacheTotalCount = null;
                if (cacheTotalCount == null)
                {
                    cacheTotalCount = (await _userService.GetTotalSrchUsrByField(searchParams)).ToString();
                    _cache.SetCacheValue<string>(_cacheName, cacheKey, cacheTotalCount);
                }

                var users = await _userService.SrchUsrByField(searchParams, page, perPage, orderBy, orderasc);
                int totalCount = Convert.ToInt32(cacheTotalCount);

                if (users == null)
                {
                    result = new BaseResponse<IEnumerable<UserItem>>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    };
                }
                else
                {
                    var userItems = _mapper.Map<IEnumerable<UserItem>>(users);

                    result = new PagedResponse<IEnumerable<UserItem>>(userItems, totalCount, page, perPage, orderBy, orderasc)
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = userItems
                    };
                }
            }

            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<User>>(ex)));
            }

            return Ok(result);
        }

        /// <summary>
        /// Get User(Employee) by id
        /// </summary>
        /// <param name="id">id of user(employee)</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            BaseResponse<UserModel> result = null;

            try
            {
                var user = await _userService.GetUserById(id);
                if (user == null)
                {
                    result = new BaseResponse<UserModel>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    };
                }
                else
                {
                    result = new BaseResponse<UserModel>
                    {
                        Message = "Sucess",
                        StatusCode = 200,
                        Resource = _mapper.Map<UserModel>(user)
                    };
                }
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<User>(ex)));
            }

            return Ok(result);
        }

        /// <summary>
        /// Create User(Employee)
        /// </summary>
        /// <param name="model">data of User(Employee)</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] UserModel model)
        {
            // map model to entity
            var user = _mapper.Map<User>(model);

            try
            {
                // create user
                var newUser = await _userService.Create(user, model.Password);
                if (newUser != null) _cache.ClearCache(_cacheName);
                return Ok(new BaseResponse<User>
                {
                    StatusCode = 200,
                    Message = "Success"
                });
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<User>>(ex)));
            }
        }

        /// <summary>
        /// Edit User(Employee)
        /// </summary>
        /// <param name="request">User(Employee) Data</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(object), 201)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync([FromBody] UserModel request)
        {
            BaseResponse<User> result = null;
            try
            {
                var updatedUser = _mapper.Map<UserModel, User>(request);

                if (String.IsNullOrWhiteSpace(request.Password) || request.Password == "1") {
                   var reqUser = await _userService.GetUserById(request.Id);
                   updatedUser.PasswordHash = reqUser.PasswordHash;
                   updatedUser.PasswordSalt = reqUser.PasswordSalt;
                }
                   
                else
                {
                    byte[] passwordHash, passwordSalt;
                    _userService.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                    updatedUser.PasswordHash = passwordHash;
                    updatedUser.PasswordSalt = passwordSalt;
                }

                var tmp = await _userService.Update(updatedUser);
                if (tmp) _cache.ClearCache(_cacheName);

                result = new BaseResponse<User>
                {
                    Message = tmp? "Success" : "Failure",
                    StatusCode = tmp?  200 : 304
                };
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<User>>(ex)));
            }

            return Ok(result);
        }

        /// <summary>
        /// Delete User(Employee) by  id
        /// </summary>
        /// <param name="id">id of user(employee</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            BaseResponse<User> result = null;
            try
            {
                bool tmp = await _userService.Delete(id);
                if (tmp) _cache.ClearCache(_cacheName);

                result = new BaseResponse<User>
                {
                    Message = tmp ? "Success" : "Failure",
                    StatusCode = tmp ? 200 : 304
                };
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<User>>(ex))); ;
            }
            
            return Ok(result);
        }
    }
}
