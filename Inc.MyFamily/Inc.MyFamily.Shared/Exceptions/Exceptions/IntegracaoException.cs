using Inc.MyFamily.Shared.Models;
using System.Runtime.Serialization;

namespace Inc.MyFamily.Shared.Exceptions.Exceptions
{
    public class IntegracaoException : BaseException
    {
        public IntegracaoException(ErrorMessage error)
            : base(error)
        {
        }
        public IntegracaoException(ErrorMessage error, Exception innerException)
            : base(error, innerException)
        {
        }
        public IntegracaoException(IEnumerable<ErrorMessage> errors, Exception innerException)
            : base(errors, innerException)
        {
        }
        public IntegracaoException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
