using Inc.MyFamily.Application.DTOs;
using Inc.MyFamily.Shared.Enuns;

namespace Inc.MyFamily.Application.Interfaces.Services
{
    public interface IAuthTokenService
    {
        Task<BearerTokenDTO> BuildToken(int Id, string FullName, int FamilyId, ETypeAuth typeAuth);
    }
}
