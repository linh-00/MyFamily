using Inc.MyFamily.Shared.Models;

namespace Inc.MyFamily.Shared.Interface
{
    public interface IUseCase<TRequest, TResponse>
    {
        Task<UseCaseResponse<TResponse>> Execute(TRequest request);
    }
}
