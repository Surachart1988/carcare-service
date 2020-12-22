using System;
using System.Runtime.Serialization;

namespace Csp.Api.Exceptions
{
    public class RefreshTokenExpException : Exception
    {
        public RefreshTokenExpException(string message) : base(message)
        {

        }

        public RefreshTokenExpException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public RefreshTokenExpException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
