using Inc.MyFamily.Shared.Models;
using System.Runtime.Serialization;

namespace Inc.MyFamily.Shared.Exceptions.Exceptions
{
    public class AuthorizationException : BaseException
    {
        public AuthorizationException(ErrorMessage error)
           : base(error)
        {
        }

        public AuthorizationException(ErrorMessage error, Exception innerEception)
            : base(error, innerEception)
        {
        }
        public AuthorizationException(IEnumerable<ErrorMessage> errors, Exception innerException)
            : base(errors, innerException)
        {
        }
        public AuthorizationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
