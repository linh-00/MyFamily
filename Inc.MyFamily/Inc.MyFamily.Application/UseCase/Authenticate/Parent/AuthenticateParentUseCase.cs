using Inc.MyFamily.Application.DTOs;
using Inc.MyFamily.Application.Interfaces.Services;
using Inc.MyFamily.Application.Interfaces.UseCases;
using Inc.MyFamily.Domain.Interfaces;
using Inc.MyFamily.Shared.Enuns;
using Inc.MyFamily.Shared.Exceptions.Exceptions;
using Inc.MyFamily.Shared.Models;

namespace Inc.MyFamily.Application.UseCase.Authenticate.Parents
{
    public class AuthenticateParentUseCase : IAuthenticateParentUseCase
    {
        public readonly IParentRepository _ParentRepository;
        public readonly IAuthTokenService _AuthTokenService;


        public AuthenticateParentUseCase(IParentRepository parentRepository, IAuthTokenService authTokenService)
        {

            _ParentRepository = parentRepository;
            _AuthTokenService = authTokenService;
        }
        public async Task<UseCaseResponse<BearerTokenDTO>> Execute((string, string) request)
        {
            var result = new UseCaseResponse<BearerTokenDTO>();
            try
            {
                var (login, senha) = request;

                var Parent = await _ParentRepository.GetParentsByLoginAndPasswordAsync(login, senha);

                var response = await _AuthTokenService.BuildToken(Parent.Id, Parent.FullName, Parent.FamilyId, ETypeAuth.Parent);

                return result.SetSuccess(response);
            }
            catch (AuthorizationException ex)
            {
                return result.SetNotAuthorized(ex.Errors.First());
            }
        }
    }
}
