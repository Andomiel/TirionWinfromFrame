using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    /// <summary>
    /// Oppo异常
    /// </summary>
    [Serializable]
    public class OppoCoreException : Exception
    {
        public object Additional { get; set; }
        public int StatusCode { get; }
        public OppoCoreException() { }
        public OppoCoreException(string message) : base(message) { }
        public OppoCoreException(string message, Exception inner) : base(message, inner) { }
        protected OppoCoreException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        /// <summary>
        /// Initializes a new instance of the OppoCoreException class with a specified StatusCode enum and a error message.
        /// </summary>
        public OppoCoreException(string message, int statusCode)
                    : base(message)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// Initializes a new instance of the OppoCoreException class with a specified StatusCode enum and a error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        public OppoCoreException(string message, int statusCode, Exception inner)
                    : base(message, inner)
        {
            StatusCode = statusCode;
        }

    }
}
