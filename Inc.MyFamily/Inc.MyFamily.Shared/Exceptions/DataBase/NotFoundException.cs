using Inc.MyFamily.Shared.Exceptions.Exceptions;
using Inc.MyFamily.Shared.Models;
using System.Runtime.Serialization;

namespace Inc.MyFamily.Shared.Exceptions.DataBase
{
    [Serializable]
    public class NotFoundException : BaseException
    {
        public NotFoundException(ErrorMessage error)
            : base(error)
        {
        }
        public NotFoundException(ErrorMessage error, Exception innerException)
            : base(error, innerException)
        {
        }
        public NotFoundException(IEnumerable<ErrorMessage> erros, Exception exception)
            : base(erros, exception)
        {
        }
        public NotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
