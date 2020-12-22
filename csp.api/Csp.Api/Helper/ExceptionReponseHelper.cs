using Csp.Services.CustomeException;
using Csp.Api.Exceptions;
using Csp.Api.Models.Response;
using Csp.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csp.Api.Helper
{
    public static class ExceptionReponseHelper
    {
        public static BaseResponse<T> CustomExceptionHandler<T>(Exception ex) where T : class
        {
            LoggerManager _logger = new LoggerManager();

            BaseResponse<T> result = null;
            if (ex is DataNotFoundException)
            {
                result = new BaseResponse<T>
                {
                    Message = "Data Not Found",
                    StatusCode = 404
                };

            }
            else if (ex is DataDuplicateException)
            {
                result = new BaseResponse<T>
                {
                    Message = "Data Duplicate/Conflict",
                    StatusCode = 409
                };

            }
            else if (ex is BadParametersException)
            {
                result = new BaseResponse<T>
                {
                    Message = "Bad Request",
                    StatusCode = 400
                };
            }

            else if (ex is RefreshTokenExpException)
            {
                result = new BaseResponse<T>
                {
                    Message = "Refresh Token Expired",
                    StatusCode = 498
                };
            }
            else if (ex is NotAccpteableException)
            {
                result = new BaseResponse<T>
                {
                    Message = "Not Acceptable",
                    StatusCode = 406
                };
            }
            else
            {
                _logger.LogError(ex.Message);

                result = new BaseResponse<T>
                {
                    Message = "Internal Server Error",
                    StatusCode = 500
                };
            }

            return result;

        }
    }
}
