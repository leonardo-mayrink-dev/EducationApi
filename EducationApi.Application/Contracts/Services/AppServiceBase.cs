using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EducationApi.Application.Contracts.Interfaces;
using EducationApi.Domain.Contracts.DomainServices.Interfaces;

namespace EducationApi.Application.Contracts.Services
{
    public abstract class AppServiceBase<TEntity, TKey>
        : IAppServiceBase<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        private readonly IDomainServiceBase<TEntity, TKey> domain;

        public AppServiceBase(IDomainServiceBase<TEntity, TKey> domain)
        {
            this.domain = domain;
        }

        public async Task Update(TEntity obj)
        {
            await domain.Update(obj);
        }

        public async Task Save(TEntity obj)
        {
            await domain.Save(obj);
        }

        public async Task Delete(TKey id)
        {
            await domain.Delete(id);
        }

        public async Task<List<TEntity>> FindAll()
        {
            return await domain.FindAll();
        }

        public async Task<TEntity> GetById(TKey id)
        {
            return await domain.GetById(id);
        }

        public async Task<IList<TEntity>> FindByFilter(Expression<Func<TEntity, bool>> predicate)
        {
            return await domain.FindByFilter(predicate);
        }
    }
}
