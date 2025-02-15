using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NIF.Exceptions
{
    internal class InvalidNIFException : Exception
    {
        public InvalidNIFException()
        {
        }

        public InvalidNIFException(string message) : base(message)
        {
        }

        public InvalidNIFException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidNIFException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
