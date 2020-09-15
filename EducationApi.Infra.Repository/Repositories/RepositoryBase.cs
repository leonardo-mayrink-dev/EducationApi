using EducationApi.Domain.Contracts.Repositories;
using EducationApi.Infra.Repository.Util;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EducationApi.Infra.Repository.Repositories
{
    public abstract class RepositoryBase<TEntity, TKey>
       : IRepositoryBase<TEntity, TKey>, IDisposable
       where TEntity : class
       where TKey : struct
    {

        protected ISession session; 
        protected ITransaction transaction; 


        public RepositoryBase()
        {
            session = HibernateUtil.Factory.OpenSession();
        }

        public async Task SaveOrUpdate(TEntity obj)
        {
            ITransaction tx = null;

            try
            {
                tx = session.BeginTransaction();

                await session.SaveOrUpdateAsync(obj);

                await  tx.CommitAsync();

            }
            catch (Exception e)
            {
                if (tx != null)
                    await tx.RollbackAsync();

                throw new SystemException(e.Message, e);
            }

        }

        public async Task Save(TEntity obj)
        {
            ITransaction tx = null;

            try
            {
                tx = session.BeginTransaction();

                await session.SaveAsync(obj);

                await tx.CommitAsync();
            }
            catch (Exception e)
            {
                if (tx != null)
                    await tx.RollbackAsync();

                throw new SystemException(e.Message, e);
            }
        }

        public async Task Delete(TEntity obj)
        {
            ITransaction tx = null;

            try
            {
                tx = session.BeginTransaction();

                await session.DeleteAsync(obj);

                await tx.CommitAsync();
            }
            catch (Exception e)
            {
                if (tx != null)
                    await tx.RollbackAsync();

                throw new SystemException(e.Message, e);
            }

        }

        public async Task<List<TEntity>> FindAll()
        {
            return await session.Query<TEntity>().ToListAsync();
        }

        public async Task<TEntity> FindById(TKey id)
        {
            return await session.GetAsync<TEntity>(id);
        }

        public async Task<IList<TEntity>> FindByFilter(Expression<Func<TEntity, bool>> predicate)
        {
            return await session.QueryOver<TEntity>().Where(predicate).ListAsync();
        }

        public void BeginTransaction()
        {
            transaction = session.BeginTransaction();
        }

        public async Task Commit()
        {
            await transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            await transaction.RollbackAsync();
        }

        public void Dispose()
        {
            session.Dispose();
        }
    }
}
