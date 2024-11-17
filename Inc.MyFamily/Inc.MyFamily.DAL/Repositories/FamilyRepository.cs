using Inc.MyFamily.DAL.Context;
using Inc.MyFamily.Domain.Interfaces;
using Inc.MyFamily.Shared.Constants;
using Inc.MyFamily.Shared.Exceptions.Exceptions;
using Microsoft.EntityFrameworkCore;
using _Family = Inc.MyFamily.Domain.Entities.Family;

namespace Inc.MyFamily.DAL.Repositories
{
    public class FamilyRepository : IFamilyRepository
    {
        public readonly dbMyFamilyContext _dbMyFamilyContext;
        private readonly string FamilyProperties = "Familia";
        public FamilyRepository(dbMyFamilyContext dbMyFamily)
        {
            _dbMyFamilyContext = dbMyFamily;
        }

        public async Task DeleteFamilyAsync(int id)
        {
            try
            {
                var result = await _dbMyFamilyContext.Families.Where(us => us.Id == id).FirstOrDefaultAsync();
                if (result is null)
                {
                    throw new RepositoryException(string.Format(ErrorMessages.NotFoundMessage, FamilyProperties));
                }
                _dbMyFamilyContext.Families.Remove(result);
                await _dbMyFamilyContext.SaveChangesAsync();
            }
            catch (Exception ex) when (ex is not RepositoryException)
            {
                throw new RepositoryException(string.Format(ApiErrorConstants.UNEXPECTED_ERROR_REPOSITORY, GetType().Name), ex);
            }
        }

        public async Task<_Family> GetFamilyByIdAsync(int id)
        {
            try
            {
                var request = await _dbMyFamilyContext.Families.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (request is not null)
                {
                    return new _Family(request.Id, request.Surname, request.Status);
                }
                else
                {
                    throw new RepositoryException(string.Format(ErrorMessages.NotFoundMessage, FamilyProperties));
                }
            }
            catch (Exception ex) when (ex is not RepositoryException)
            {
                throw new RepositoryException(string.Format(ApiErrorConstants.UNEXPECTED_ERROR_REPOSITORY, GetType().Name), ex);
            }
        }

        public async Task<_Family> InsertFamilyAsync(_Family family)
        {
            try
            {
                var newFamily = new Models.Family()
                {
                    Id = family.Id,
                    Status = family.Status,
                    Surname = family.SurName,
                };
                _dbMyFamilyContext.Families.Add(newFamily);
                await _dbMyFamilyContext.SaveChangesAsync();
                family.setId(newFamily.Id);
                return family;
            }
            catch (Exception ex) when (ex is not RepositoryException)
            {
                throw new RepositoryException(string.Format(ApiErrorConstants.UNEXPECTED_ERROR_REPOSITORY, GetType().Name), ex);
            }
        }

        public async Task<_Family> UpdateFamilyAsync(_Family family)
        {
            try
            {
                var entity = await _dbMyFamilyContext.Families.Where(e => e.Status == family.Status && e.Surname == family.SurName).FirstOrDefaultAsync();
                if (entity == null)
                {
                    entity.Status = family.Status;
                    entity.Surname = family.SurName;

                    _dbMyFamilyContext.Families.Update(entity);
                    await _dbMyFamilyContext.SaveChangesAsync();
                    return family;
                }
                else
                {
                    throw new RepositoryException(string.Format(ErrorMessages.NotFoundMessage, FamilyProperties));
                }
            }
            catch (Exception ex) when (ex is not RepositoryException)
            {
                throw new RepositoryException(string.Format(ErrorMessages.NotFoundMessage, FamilyProperties));
            }
        }
    }
}
