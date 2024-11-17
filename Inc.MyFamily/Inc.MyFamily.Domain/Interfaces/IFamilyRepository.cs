using Inc.MyFamily.Domain.Entities;

namespace Inc.MyFamily.Domain.Interfaces
{
    public interface IFamilyRepository
    {
        Task<Family> GetFamilyByIdAsync(int id);
        Task<Family> InsertFamilyAsync(Family family);
        Task<Family> UpdateFamilyAsync(Family family);
        Task DeleteFamilyAsync(int id);
    }
}
