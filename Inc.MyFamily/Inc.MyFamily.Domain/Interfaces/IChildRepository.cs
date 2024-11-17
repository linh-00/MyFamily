using Inc.MyFamily.Domain.Entities;

namespace Inc.MyFamily.Domain.Interfaces
{
    public interface IChildRepository
    {
        Task<IEnumerable<Children>> GetAllChildrenByFamilyIdAsync(int familyId);
        Task<Children> GetChildrenByIdAsync(int id);
        Task<Children> InsertChildrenAsync(Children Request);
        Task DeleteChildrenAsync(int id);
        Task<Children> UpdateChildrenAsync(Children Request);
        Task<Children> GetChildrenByLoginAndPasswordAsync(string login, string password);
    }
}
