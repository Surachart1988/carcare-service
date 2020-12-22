using System;
using System.Runtime.Serialization;

namespace Csp.Services.CustomeException
{
    [Serializable()]
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(string message) : base(message)
        {
        }

        public DataNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public DataNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

    }
}
