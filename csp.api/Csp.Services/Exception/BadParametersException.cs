using System;
using System.Runtime.Serialization;


namespace Csp.Services.CustomeException
{
    [Serializable()]
    public class BadParametersException : Exception
    {
        public BadParametersException(string message) : base(message)
        {

        }

        public BadParametersException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public BadParametersException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
