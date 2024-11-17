using Inc.MyFamily.Api.Interfaces;
using Inc.MyFamily.Application.DTOs;
using Inc.MyFamily.Application.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Inc.MyFamily.Api.Controllers
{
    [ApiController]
    [Route("api/v1/app/[controller]")]
    public class AuthenticateController
    {
        private readonly IAuthenticateChildrenUseCase _AuthenticateChildrenUseCase;
        private readonly IAuthenticateParentUseCase _AuthenticateParentUseCase;
        private readonly IActionResultConverter _ActionResultConverter;

        public AuthenticateController(IAuthenticateChildrenUseCase authenticateChildrenUseCase, IAuthenticateParentUseCase authenticateParentUseCase, IActionResultConverter actionResultConverter)
        {
            _AuthenticateChildrenUseCase = authenticateChildrenUseCase;
            _AuthenticateParentUseCase = authenticateParentUseCase;
            _ActionResultConverter = actionResultConverter;
        }

        [ProducesResponseType(typeof(BearerTokenDTO), StatusCodes.Status200OK)]
        [HttpPost("Parent")]
        public async Task<IActionResult> AuthenticacaoParentApp([FromBody] AuthenticateRequest request)
        {
            var response = await _AuthenticateParentUseCase.Execute((request.Login, request.Password));
            return _ActionResultConverter.Convert(response);
        }

        [ProducesResponseType(typeof(BearerTokenDTO), StatusCodes.Status200OK)]
        [HttpPost("Children")]
        public async Task<IActionResult> AuthenticacaoChildrenApp([FromBody] AuthenticateRequest request)
        {
            var response = await _AuthenticateChildrenUseCase.Execute((request.Login, request.Password));
            return _ActionResultConverter.Convert(response);
        }
    }
}
