using System;
using System.Runtime.Serialization;

namespace Titanium.Web.Proxy.Exceptions
{
    public class TitaniumException : Exception
    {
        public TitaniumException()
        {
        }

        public TitaniumException(string message) : base(message)
        {
        }

        public TitaniumException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TitaniumException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
