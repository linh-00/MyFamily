using Inc.MyFamily.Domain.Entities;

namespace Inc.MyFamily.Domain.Interfaces
{
    public interface IParentRepository
    {
        Task<Parent> GetParentsByLoginAndPasswordAsync(string login, string password);
    }
}
