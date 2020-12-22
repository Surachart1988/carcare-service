using System;
using System.Runtime.Serialization;

namespace Csp.Services.CustomeException
{
    [Serializable()]
    public class DataDuplicateException : Exception
    {
        public DataDuplicateException(string message) : base(message)
        {

        }
        public DataDuplicateException(string message, Exception innerException) : base(message, innerException)
        {

        }
        public DataDuplicateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
