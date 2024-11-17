using FluentValidation;
using Inc.MyFamily.Shared.Constants;
using Inc.MyFamily.Shared.Enuns;
using Inc.MyFamily.Shared.Exceptions.DataBase;
using Inc.MyFamily.Shared.Interface;

namespace Inc.MyFamily.Shared.Models
{
    public class UseCaseResponse<T> : IResponse
    {
        public UseCaseResponseKind Status { get; private set; }
        public string? ErrorMessage { get; private set; }
        public IEnumerable<ErrorMessage>? Errors { get; private set; }
        public T? Result { get; private set; }
        public string? ResultId { get; private set; }
        public UseCaseResponse<T> SetSuccess(T result)
        {
            Result = result;

            return SetStatus(UseCaseResponseKind.Success);
        }
        public UseCaseResponse<T> SetPersisted(T result, string resultId)
        {
            Result = result;
            ResultId = resultId;

            return SetStatus(UseCaseResponseKind.DataPersisted);
        }
        public UseCaseResponse<T> SetProcessed(T result, string resultId)
        {
            Result = result;
            ResultId = resultId;

            return SetStatus(UseCaseResponseKind.DataAccepted);
        }
        public UseCaseResponse<T> SetInternalServerError(string errorMessage, IEnumerable<ErrorMessage> errors = null)
        {
            return SetStatus(UseCaseResponseKind.InternalServerError, errorMessage, errors);
        }
        public UseCaseResponse<T> SetUnavailable(T result)
        {
            Result = result;
            Status = UseCaseResponseKind.Unavailable;
            ErrorMessage = ApiErrorConstants.SERVICE_UNAVAILABLE;
            return this;
        }
        public UseCaseResponse<T> SetRequestValidationError(string errorMessage, IEnumerable<ErrorMessage> errors = null)
        {
            return SetStatus(UseCaseResponseKind.RequestValidationError, errorMessage, errors);
        }
        public UseCaseResponse<T> SetRequestValidationError(ValidationException ex)
        {
            return SetRequestValidationError(ApiErrorConstants.VALIDATION_EXCEPTION, ex.Errors.Select(error => new ErrorMessage(error.ErrorCode, error.ErrorMessage)));
        }
        public UseCaseResponse<T> SetForeignKeyViolationError(ForeignKeyViolationException ex)
        {
            return SetStatus(UseCaseResponseKind.ForeingKeyViolationError, ApiErrorConstants.FK_VIOLATION_EXCEPTION, ex.Errors);
        }
        public UseCaseResponse<T> SetUniqueViolationError(UniqueViolationException ex)
        {
            return SetStatus(UseCaseResponseKind.UniqueViolationError, ApiErrorConstants.UNIQUE_VIOLATION_EXCEPTION, ex.Errors);
        }
        public UseCaseResponse<T> SetRequiredResourceNotFound(ErrorMessage error)
        {
            return SetStatus(UseCaseResponseKind.RequiredResourceNotFound, ApiErrorConstants.REQUIRED_RESOURCE_NOT_FOUND, new ErrorMessage[] { error });
        }
        public UseCaseResponse<T> SetNotFound(ErrorMessage error)
        {
            return SetStatus(UseCaseResponseKind.NotFound, ApiErrorConstants.DATA_NOT_FOUND, new ErrorMessage[] { error });
        }
        public UseCaseResponse<T> SetNotAuthorized(ErrorMessage error)
        {
            return SetStatus(UseCaseResponseKind.Unauthorized, ApiErrorConstants.NOT_AUTHORIZED, new ErrorMessage[] { error });
        }
        public UseCaseResponse<T> SetStatus(UseCaseResponseKind status, string errorMessage = null, IEnumerable<ErrorMessage> errors = null)
        {
            Status = status;
            ErrorMessage = errorMessage;
            Errors = errors;
            return this;
        }

        public bool Success()
        {
            return ErrorMessage is null;
        }
    }
}
