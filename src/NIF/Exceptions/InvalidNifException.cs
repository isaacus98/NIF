using System.Runtime.Serialization;

namespace NIF.Exceptions
{
    [Serializable]
    internal class InvalidNifException : Exception
    {
        public InvalidNifException()
        {
        }

        public InvalidNifException(string? message) : base(message)
        {
        }

        public InvalidNifException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidNifException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}