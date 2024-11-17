namespace Inc.MyFamily.Shared.Enuns
{
    public enum UseCaseResponseKind
    {
        Success,
        DataPersisted,
        DataAccepted,
        InternalServerError,
        RequestValidationError,
        ForeingKeyViolationError,
        UniqueViolationError,
        RequiredResourceNotFound,
        NotFound,
        Unauthorized,
        Forbidden,
        Unavailable
    }
}
