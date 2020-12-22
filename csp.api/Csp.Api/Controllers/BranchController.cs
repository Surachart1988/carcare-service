using Csp.DAL.Models;
using Csp.Services.Interfaces;
using AutoMapper;
using Csp.Api.Helper;
using Csp.Api.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
    public class BranchController : Controller
    {
        private readonly IBranchService _branchService;
        private readonly IMapper _mapper;

        public BranchController(IBranchService branchService, IMapper mapper)
        {
            _branchService = branchService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get Branch Data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Branch), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var branch = await _branchService.GetBranch();
                if (branch == null)
                {
                    return Ok(new BaseResponse<Branch>
                    {
                        Message = "Not Found",
                        StatusCode = 404
                    });
                }
                else
                {
                    return Ok(new BaseResponse<Branch>
                    {
                        Message = "Success",
                        StatusCode = 200,
                        Resource = _mapper.Map<Branch>(branch)
                    });
                }
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<Branch>(ex)));
            }
        }

        /// <summary>
        /// Update Branch
        /// </summary>
        /// <param name="model">Branch Data</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(object), 201)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync([FromBody] Branch model)
        {
            try
            {
                var updateBranch = await _branchService.UpdateBranch(model);

                return Ok(new BaseResponse<Branch>
                {
                    StatusCode = 200,
                    Message = "Success"
                });
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<Branch>>(ex)));
            }
        }

    }

}
