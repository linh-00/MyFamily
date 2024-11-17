using Inc.MyFamily.Shared.Exceptions.Exceptions;
using Inc.MyFamily.Shared.Models;
using System.Runtime.Serialization;

namespace Inc.MyFamily.Shared.Exceptions.DataBase
{
    public class UniqueViolationException : BaseException
    {
        public UniqueViolationException(ErrorMessage error)
           : base(error)
        {
        }
        public UniqueViolationException(ErrorMessage error, Exception exception)
            : base(error, exception)
        {
        }
        public UniqueViolationException(IEnumerable<ErrorMessage> errors, Exception exception)
            : base(errors, exception)
        {
        }
        public UniqueViolationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
