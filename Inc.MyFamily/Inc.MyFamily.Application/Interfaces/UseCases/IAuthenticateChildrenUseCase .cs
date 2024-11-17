using Inc.MyFamily.Application.DTOs;
using Inc.MyFamily.Shared.Interface;

namespace Inc.MyFamily.Application.Interfaces.UseCases
{
    public interface IAuthenticateChildrenUseCase : IUseCase<(string, string), BearerTokenDTO>
    {
    }
}
