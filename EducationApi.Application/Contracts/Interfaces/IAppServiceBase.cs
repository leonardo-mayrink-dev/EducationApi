using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EducationApi.Application.Contracts.Interfaces
{
    public interface IAppServiceBase<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        Task Save(TEntity obj);
        Task Update(TEntity obj);
        Task Delete(TKey id);
        Task<List<TEntity>> FindAll();
        Task<TEntity> GetById(TKey id);
        Task<IList<TEntity>> FindByFilter(Expression<Func<TEntity, bool>> predicate);
    }
}
