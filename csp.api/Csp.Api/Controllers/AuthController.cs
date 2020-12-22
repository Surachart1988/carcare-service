using Csp.DAL.Models;
using Csp.Services.CustomeException;
using Csp.Services.Interfaces;
using AutoMapper;
using Csp.Api.Exceptions;
using Csp.Api.Helper;
using Csp.Api.Models;
using Csp.Api.Models.Response;
using Csp.Logger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csp.Api.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}")]
    [Produces("application/json")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        private IConfiguration _config; 
        private readonly IMapper _mapper;

        public AuthController(
            IAuthService authService, 
            IJwtService jwtService, 
            IUserService userService,
            IConfiguration config,
            IMapper mapper)
        {
            _authService = authService;
            _jwtService = jwtService;
            _userService = userService;
            _config = config;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            BaseResponse<AuthModel> result;
            try
            {
                var user = await _authService.Login(model.LoginName, model.Password);
                if (user == null)
                {
                    return Ok(new BaseResponse<User>
                    {
                        StatusCode = 401,
                        Message = "Unauthorized"
                    });
                }

                var userParam = new Dictionary<string, string>
                {
                    { "LoginName", user.LoginName }
                };

                IEnumerable<User> userResource = await _userService.SrchUsrByField(userParam);
                Dictionary<string, string> parameters = PraseTokenParams(userResource.FirstOrDefault());

                var tokenString = _jwtService.GenerateSecurityToken(parameters);
                var refreshToken = _jwtService.GenerateRefreshToken();

                var refreshTokenExpiryTime = Double.Parse(_config.GetSection("JwtConfig").GetSection("refreshTokenExpirationInSecond").Value);

                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.Now.AddSeconds(refreshTokenExpiryTime);
                var tmp = await _userService.Update(user);

                result = new BaseResponse<AuthModel>
                {
                    StatusCode = 200,
                    Message = "Success",
                    Resource = new AuthModel
                    {
                        AccessToken = tokenString,
                        TokenType = "bearer",
                        expiresIn = _jwtService.GetExpirationDate(),
                        RefreshToken = refreshToken
                    }
                };
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<User>>(ex)));
            }

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("refreshtoken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenApiModel tokenApiModel)
        {
            BaseResponse<AuthModel> result;
            try
            {
                string accessToken = tokenApiModel.AccessToken;
                string refreshToken = tokenApiModel.RefreshToken;
                var principal = _jwtService.GetPrincipalFromExpiredToken(accessToken);
                var username = principal.Identity.Name; //this is mapped to the Name claim by default

                var user = await _userService.GetUserByLoginName(username);

                if (user == null || user.RefreshToken != refreshToken ) 
                    throw new DataNotFoundException("User Not Found / User Not Login");

                else if (user.RefreshTokenExpiryTime <= DateTime.Now)
                    throw new RefreshTokenExpException("Token");

                var userParam = new Dictionary<string, string>
                {
                    { "LoginName", user.LoginName }
                };

                IEnumerable<User> userResource = await _userService.SrchUsrByField(userParam);
                Dictionary<string, string> parameters = PraseTokenParams(userResource.FirstOrDefault());
                var newAccessToken = _jwtService.GenerateSecurityToken(parameters);
                var newRefreshToken = _jwtService.GenerateRefreshToken();
                user.RefreshToken = newRefreshToken;
                var tmp = await _userService.Update(user);

                result = new BaseResponse<AuthModel>
                {
                    StatusCode = 200,
                    Message = "Success",
                    Resource = new AuthModel
                    {
                        AccessToken = newAccessToken,
                        TokenType = "bearer",
                        expiresIn = _jwtService.GetExpirationDate(),
                        RefreshToken = newRefreshToken
                    }
                };
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<User>>(ex)));
            }

            return Ok(result);
        }

        [HttpPost("revoketoken")]
        public async Task<IActionResult> Revoke()
        {
            BaseResponse<AuthModel> result = null;

            try
            {
                var loginName = User.Identity.Name;
                var user = await _userService.GetUserByLoginName(loginName);
                if (user == null) return BadRequest();
                user.RefreshToken = null;
                user.RefreshTokenExpiryTime = null;
                var tmp = await _userService.Update(user);

                result = new BaseResponse<AuthModel>
                {
                    StatusCode = 200,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                return Ok((ExceptionReponseHelper.CustomExceptionHandler<IEnumerable<User>>(ex)));
            }

            return Ok(result);
        }

        private static Dictionary<string, string> PraseTokenParams(User user)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("LoginName", user.LoginName);
            parameters.Add("FirstName", user.FirstName);
            parameters.Add("LastName", user.Lastname);
            parameters.Add("UserId", user.Id.ToString());
            parameters.Add("PositionId", user.PositionId.ToString());
            parameters.Add("PositionName", user.Position.Name);
            return parameters;
        }
    }
}