using Inc.MyFamily.Application.DTOs;
using Inc.MyFamily.Shared.Interface;

namespace Inc.MyFamily.Application.Interfaces.UseCases
{
    public interface IGetAllChildrenByFamilyIdUseCase : IUseCase<int, List<Children>>
    {
    }
}
