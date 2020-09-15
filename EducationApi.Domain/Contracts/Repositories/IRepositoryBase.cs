using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EducationApi.Domain.Contracts.Repositories
{
    public interface IRepositoryBase<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        Task SaveOrUpdate(TEntity obj);

        Task Save(TEntity obj);

        Task Delete(TEntity obj);

        Task<List<TEntity>> FindAll();

        Task<TEntity> FindById(TKey id);

        Task<IList<TEntity>> FindByFilter(Expression<Func<TEntity, bool>> predicate);

        void BeginTransaction();

        Task Commit();

        Task Rollback();
    }
}
