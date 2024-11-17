using Inc.MyFamily.Application.DTOs;
using Inc.MyFamily.Application.Interfaces.Services;
using Inc.MyFamily.Application.Interfaces.UseCases;
using Inc.MyFamily.Domain.Interfaces;
using Inc.MyFamily.Shared.Enuns;
using Inc.MyFamily.Shared.Exceptions.Exceptions;
using Inc.MyFamily.Shared.Models;

namespace Inc.MyFamily.Application.UseCase.Authenticate.Children
{
    public class AuthenticateChildrenUseCase : IAuthenticateChildrenUseCase
    {
        public readonly IChildRepository _ChildrenRepository;
        public readonly IAuthTokenService _AuthTokenService;

        public AuthenticateChildrenUseCase(IChildRepository childrenRepository, IAuthTokenService authTokenService)
        {
            _ChildrenRepository = childrenRepository;
            _AuthTokenService = authTokenService;
        }

        public async Task<UseCaseResponse<BearerTokenDTO>> Execute((string, string) request)
        {
            var result = new UseCaseResponse<BearerTokenDTO>();
            try
            {
                var (login, senha) = request;

                var Children = await _ChildrenRepository.GetChildrenByLoginAndPasswordAsync(login, senha);

                var response = await _AuthTokenService.BuildToken(Children.Id, Children.Name, Children.FamilyId, ETypeAuth.Children);

                return result.SetSuccess(response);
            }
            catch (AuthorizationException ex)
            {
                return result.SetNotAuthorized(ex.Errors.First());
            }
        }
    }
}
