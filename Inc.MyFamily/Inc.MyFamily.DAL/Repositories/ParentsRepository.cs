using Inc.MyFamily.DAL.Context;
using Inc.MyFamily.Domain.Entities;
using Inc.MyFamily.Domain.Interfaces;
using Inc.MyFamily.Shared.Constants;
using Inc.MyFamily.Shared.Exceptions.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Inc.MyFamily.DAL.Repositories
{
    public class ParentsRepository : IParentRepository
    {
        public readonly dbMyFamilyContext _dbMyFamilyContext;
        private readonly string ParentesProperties = "Parentes";
        public ParentsRepository(dbMyFamilyContext dbMyFamily)
        {
            _dbMyFamilyContext = dbMyFamily;
        }

        public async Task<Parent> GetParentsByLoginAndPasswordAsync(string login, string password)
        {
            try
            {
                var entity = await _dbMyFamilyContext.Parents.Where(e => e.Login == login && e.Password == password).FirstOrDefaultAsync();
                if (entity is not null)
                {
                    return new Parent(entity.Id, entity.FullName, entity.NickName, entity.BiologicalSex, entity.FamilyId, entity.Login, entity.Password);
                }
                else
                {
                    throw new RepositoryException(ErrorMessages.AuthErrorMessage);
                }
            }
            catch (Exception ex) when (ex is not RepositoryException)
            {
                throw new RepositoryException(string.Format(ApiErrorConstants.UNEXPECTED_ERROR_REPOSITORY, GetType().Name), ex);
            }
        }
    }

}
