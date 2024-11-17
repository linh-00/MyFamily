using Inc.MyFamily.Application.DTOs;
using Inc.MyFamily.Application.Interfaces.UseCases;
using Inc.MyFamily.Shared.Models;

namespace Inc.MyFamily.Application.UseCase
{
    public class GetAllChildrenByFamilyIdUseCase : IGetAllChildrenByFamilyIdUseCase
    {
        public Task<UseCaseResponse<List<Children>>> Execute(int request)
        {
            throw new NotImplementedException();
        }
    }
}
