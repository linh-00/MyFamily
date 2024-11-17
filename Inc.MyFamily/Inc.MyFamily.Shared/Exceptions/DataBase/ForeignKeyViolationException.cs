using Inc.MyFamily.Shared.Exceptions.Exceptions;
using Inc.MyFamily.Shared.Models;
using System.Runtime.Serialization;

namespace Inc.MyFamily.Shared.Exceptions.DataBase
{
    [Serializable]
    public class ForeignKeyViolationException : BaseException
    {
        public ForeignKeyViolationException(ErrorMessage error)
           : base(error)
        {
        }

        public ForeignKeyViolationException(ErrorMessage error, Exception innerException)
            : base(error, innerException)
        {
        }

        public ForeignKeyViolationException(IEnumerable<ErrorMessage> errors, Exception innerException)
            : base(errors, innerException)
        {
        }

        public ForeignKeyViolationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
