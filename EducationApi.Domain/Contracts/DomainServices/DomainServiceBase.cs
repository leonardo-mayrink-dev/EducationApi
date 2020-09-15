using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EducationApi.Domain.Contracts.DomainServices.Interfaces;
using EducationApi.Domain.Contracts.Repositories;

namespace EducationApi.Domain.Contracts.DomainServices
{
    public abstract class DomainServiceBase<TEntity, TKey> : IDomainServiceBase<TEntity, TKey>
         where TEntity : class
         where TKey : struct
    {

        private readonly IRepositoryBase<TEntity, TKey> repositorio;

        public DomainServiceBase(IRepositoryBase<TEntity, TKey> repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task Update(TEntity obj)
        {
            try
            {
                await repositorio.SaveOrUpdate(obj);

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task Save(TEntity obj)
        {
            try
            {
                await repositorio.SaveOrUpdate(obj);

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task Delete(TKey id)
        {
            try
            {
                Task<TEntity> obj = repositorio.FindById(id);

                await repositorio.Delete(obj.Result);


            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<List<TEntity>> FindAll()
        {
            try
            {
                return await repositorio.FindAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<TEntity> GetById(TKey id)
        {
            try
            {
                return await repositorio.FindById(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IList<TEntity>> FindByFilter(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await repositorio.FindByFilter(predicate);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
