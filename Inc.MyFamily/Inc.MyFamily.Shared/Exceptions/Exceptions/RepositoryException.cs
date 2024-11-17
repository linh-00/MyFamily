using Inc.MyFamily.Shared.Constants;
using Inc.MyFamily.Shared.Enuns;
using Inc.MyFamily.Shared.Models;
using System.Net;
using System.Runtime.Serialization;

namespace Inc.MyFamily.Shared.Exceptions.Exceptions
{
    [Serializable]
    public class RepositoryException : Exception
    {
        public IEnumerable<ErrorMessage> Errors { get; } = Array.Empty<ErrorMessage>();
        public HttpStatusCode StatusCode { get; }
        public RepositoryExceptionReason Reason { get; }

        public RepositoryException() { }
        public RepositoryException(string message) : base(message) { }
        public RepositoryException(
            string message,
            Exception inner
        ) : base(message, inner) { }

        public RepositoryException(
            string message,
            IEnumerable<ErrorMessage> errors,
            HttpStatusCode statusCode
            ) : base(message)
        {
            Errors = errors;
            StatusCode = statusCode;
        }

        public RepositoryException(
           string message,
           string errorData,
           RepositoryExceptionReason reason = RepositoryExceptionReason.ThirdPartyServiceUnavailability) : base(message)
        {
            _ = Errors.Prepend(new ErrorMessage(ErrorCodes.RepositoryError, errorData));
            Reason = reason;
        }

        protected RepositoryException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
