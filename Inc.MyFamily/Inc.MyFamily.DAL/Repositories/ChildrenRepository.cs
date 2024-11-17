using Inc.MyFamily.DAL.Context;
using Inc.MyFamily.DAL.Models;
using Inc.MyFamily.Domain.Entities;
using Inc.MyFamily.Domain.Interfaces;
using Inc.MyFamily.Shared.Constants;
using Inc.MyFamily.Shared.Exceptions.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Inc.MyFamily.DAL.Repositories
{
    public class ChildrenRepository : IChildRepository
    {
        private readonly dbMyFamilyContext _dbMyFamilyContext;
        private readonly string ChildrenProperties = "Criança";

        public ChildrenRepository(dbMyFamilyContext dbMyFamily)
        {
            _dbMyFamilyContext = dbMyFamily;
        }

        public async Task DeleteChildrenAsync(int id)
        {
            try
            {
                var result = await _dbMyFamilyContext.Children.Where(us => us.Id == id).FirstOrDefaultAsync();
                if (result == null)
                    throw new RepositoryException(string.Format(ErrorMessages.NotFoundMessage, ChildrenProperties));

                _dbMyFamilyContext.Children.Remove(result);
                await _dbMyFamilyContext.SaveChangesAsync();
            }
            catch (Exception ex) when (ex is not RepositoryException)
            {
                throw new RepositoryException(string.Format(ApiErrorConstants.UNEXPECTED_ERROR_REPOSITORY, GetType().Name), ex);
            }
        }

        public async Task<IEnumerable<Children>> GetAllChildrenByFamilyIdAsync(int familyId)
        {
            try
            {
                var entity = await _dbMyFamilyContext.Children.Where(x => x.FamilyId == familyId).ToListAsync();
                return entity.Select(res => new Children(res.Id, res.Name, res.BiologicalSex, res.Login, res.Password, res.FamilyId));
            }
            catch (Exception ex) when (ex is not RepositoryException)
            {
                throw new RepositoryException(string.Format(ApiErrorConstants.UNEXPECTED_ERROR_REPOSITORY, GetType().Name), ex);
            }
        }

        public async Task<Children> GetChildrenByIdAsync(int id)
        {
            try
            {
                var entity = await _dbMyFamilyContext.Children.Where(e => e.Id == id).FirstOrDefaultAsync();

                if (entity is not null)
                    return new Children(entity.Id, entity.Name, entity.BiologicalSex, entity.Login, entity.Password, entity.FamilyId);
                else
                    throw new RepositoryException(string.Format(ErrorMessages.NotFoundMessage, ChildrenProperties));

            }
            catch (Exception ex) when (ex is not RepositoryException)
            {
                throw new RepositoryException(string.Format(ApiErrorConstants.UNEXPECTED_ERROR_REPOSITORY, GetType().Name), ex);
            }
        }

        public async Task<Children> GetChildrenByLoginAndPasswordAsync(string login, string password)
        {
            try
            {
                var entity = await _dbMyFamilyContext.Children.Where(e => e.Login == login && e.Password == password).FirstOrDefaultAsync();
                if (entity is not null)
                {
                    return new Children(entity.Id, entity.Name, entity.BiologicalSex, entity.Login, entity.Password, entity.FamilyId);
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

        public async Task<Children> InsertChildrenAsync(Children Request)
        {
            try
            {
                var newChildren = new Child()
                {
                    Name = Request.Name,
                    BiologicalSex = Request.BiologicalSex,
                    Login = Request.Login,
                    Password = Request.Password,
                    FamilyId = Request.FamilyId,
                };
                _dbMyFamilyContext.Children.Add(newChildren);
                await _dbMyFamilyContext.SaveChangesAsync();
                Request.setId(newChildren.Id);
                return Request;
            }
            catch (Exception ex) when (ex is not RepositoryException)
            {
                throw new RepositoryException(string.Format(ApiErrorConstants.UNEXPECTED_ERROR_REPOSITORY, GetType().Name), ex);
            }
        }

        public async Task<Children> UpdateChildrenAsync(Children Request)
        {
            try
            {
                var entity = await _dbMyFamilyContext.Children.Where(x => x.Id == Request.Id).FirstOrDefaultAsync();
                if (entity is not null)
                {
                    entity.Name = Request.Name;
                    entity.BiologicalSex = Request.BiologicalSex;
                    entity.Login = Request.Login;
                    entity.Password = Request.Password;
                    entity.FamilyId = Request.FamilyId;

                    _dbMyFamilyContext.Children.Update(entity);
                    await _dbMyFamilyContext.SaveChangesAsync();
                    return Request;
                }
                else
                    throw new RepositoryException(string.Format(ErrorMessages.NotFoundMessage, ChildrenProperties));
            }
            catch (Exception ex) when (ex is not RepositoryException)
            {
                throw new RepositoryException(string.Format(ApiErrorConstants.UNEXPECTED_ERROR_REPOSITORY, GetType().Name), ex);
            }
        }
    }
}
