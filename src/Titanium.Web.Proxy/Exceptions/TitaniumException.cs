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

#pragma warning disable SYSLIB0051 // Formatter-based serialization is obsolete; the ctor is kept for binary-compatibility with consumers that still deserialize this exception.
        protected TitaniumException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
#pragma warning restore SYSLIB0051
    }
}
