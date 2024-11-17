using Inc.MyFamily.Shared.Models;

namespace Inc.MyFamily.Shared.Interface
{
    public interface IUseCaseOnlyResponse<TResponse>
    {
        Task<UseCaseResponse<TResponse>> Execute();
    }
}
