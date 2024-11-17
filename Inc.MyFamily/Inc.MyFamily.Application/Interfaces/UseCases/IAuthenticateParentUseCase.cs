using Inc.MyFamily.Application.DTOs;
using Inc.MyFamily.Shared.Interface;

namespace Inc.MyFamily.Application.Interfaces.UseCases
{
    public interface IAuthenticateParentUseCase : IUseCase<(string, string), BearerTokenDTO>
    {

    }
}
