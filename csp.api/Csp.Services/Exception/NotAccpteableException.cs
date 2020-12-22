using System;
using System.Runtime.Serialization;

namespace Csp.Services.CustomeException
{
    [Serializable()]
    public class NotAccpteableException : Exception
    {
        public NotAccpteableException(string message) : base(message)
        {

        }
        public NotAccpteableException(string message, Exception innerException) : base(message, innerException)
        {

        }
        public NotAccpteableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
