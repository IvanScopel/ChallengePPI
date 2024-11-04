using UnitOfWorkRepository.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnitOfWorkRepository.Repository.Interfaces;
using Microsoft.Xrm.Sdk;


namespace UnitOfWorkRepository.Repository.Models
{
    public interface IGenericRepository<T> : ICreateRepository<T>, IReadRepository<T>, IRemoveRepository<T> where T : class
    {
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected IQueryable<T> PrepareQuery(IQueryable<T> query,
                                              Expression<Func<T, bool>> predicate = null,
                                              Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                              int? take = null,
                                              params Expression<Func<T, object>>[] includes
                                            )
        {
            if (includes != null)
                query = Include(query, includes);
            if (predicate != null)
                query = query.Where(predicate);
            if (orderBy != null)
                query = orderBy(query);
            if (take.HasValue)
                query = query.Take(Convert.ToInt32(take));

            return query;
        }

        public IQueryable<T> Include(IQueryable<T> query, params Expression<Func<T, object>>[] includes)
        {
            if (includes.Length > 0)
            {
                query = query.Include(includes[0]);
            }
            for (int queryIndex = 1; queryIndex < includes.Length; ++queryIndex)
            {
                query = query.Include(includes[queryIndex]);
            }
            return query;
        }

        #region ICreateRepository 
        public virtual async Task<bool> CreateAsync(T entity)
        {
            bool created = false;

            try
            {
                var save = await _unitOfWork.Context.Set<T>().AddAsync(entity);

                if (save != null)
                    created = true;
            }
            catch (Exception)
            {
                throw;
            }
            return created;
        }
        public virtual async Task CreateAsync(IEnumerable<T> entity)
        {
            try
            {
                await _unitOfWork.Context.Set<T>().AddRangeAsync(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual bool Create(T entity)
        {
            bool created = false;

            try
            {
                var save = _unitOfWork.Context.Set<T>().Add(entity);

                if (save != null)
                    created = true;
            }
            catch (Exception)
            {
                throw;
            }
            return created;
        }

        public virtual void Create(IEnumerable<T> entity)
        {
            _unitOfWork.Context.Set<T>().AddRange(entity);
        }
        #endregion

       

        #region IReadRepository
        #region Get All
        public virtual IEnumerable<T> GetAll(
           Expression<Func<T, bool>> predicate = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           int? take = null,
                    params Expression<Func<T, object>>[] includes
       )
        {
            var query = _unitOfWork.Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, orderBy, take, includes);

            return query.ToList();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? take = null,
            params Expression<Func<T, object>>[] includes
        )
        {
            var query = _unitOfWork.Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, orderBy, take, includes);

            return await query.ToListAsync();
        }
        #endregion

        #region Extras
        public virtual async Task<decimal?> SumAsync(
            Expression<Func<T, bool>> predicate = null
        )
        {
            var query = _unitOfWork.Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate);

            return await ((IQueryable<decimal?>)query).SumAsync();
        }

        public virtual decimal? Sum(
            Expression<Func<T, bool>> predicate = null
        )
        {
            var query = _unitOfWork.Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate);

            return ((IQueryable<decimal?>)query).Sum();
        }

        public virtual async Task<int> CountAsync(
            Expression<Func<T, bool>> predicate = null
        )
        {
            var query = _unitOfWork.Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate);

            return await query.CountAsync();
        }

        public virtual int Count(
            Expression<Func<T, bool>> predicate = null
        )
        {
            var query = _unitOfWork.Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate);

            return query.Count();
        }
        #endregion

        #region First
        public virtual T First(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                      params Expression<Func<T, object>>[] includes
        )
        {
            var query = _unitOfWork.Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, orderBy, null, includes);

            return query.First();
        }

        public virtual async Task<T> FirstAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                      params Expression<Func<T, object>>[] includes
        )
        {
            var query = _unitOfWork.Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, orderBy, null, includes);

            return await query.FirstAsync();
        }

        public virtual T FirstOrDefault(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                      params Expression<Func<T, object>>[] includes
        )
        {
            var query = _unitOfWork.Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, orderBy, null, includes);

            return query.FirstOrDefault();
        }

        public virtual async Task<T> FirstOrDefaultAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                      params Expression<Func<T, object>>[] includes
        )
        {
            var query = _unitOfWork.Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, orderBy, null, includes);

            return await query.FirstOrDefaultAsync();
        }
        #endregion

        #region Single
        public virtual T Single(
            Expression<Func<T, bool>> predicate,
                      params Expression<Func<T, object>>[] includes
        )
        {
            var query = _unitOfWork.Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, null, null, includes);

            return query.Single();
        }

        public virtual async Task<T> SingleAsync(
            Expression<Func<T, bool>> predicate,
                      params Expression<Func<T, object>>[] includes
        )
        {
            var query = _unitOfWork.Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, null, null, includes);

            return await query.SingleAsync();
        }

        public virtual T SingleOrDefault(
            Expression<Func<T, bool>> predicate,
                      params Expression<Func<T, object>>[] includes
        )
        {
            var query = _unitOfWork.Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, null, null, includes);

            return query.SingleOrDefault();
        }

        public virtual async Task<T> SingleOrDefaultAsync(
            Expression<Func<T, bool>> predicate,
                      params Expression<Func<T, object>>[] includes
        )
        {
            var query = _unitOfWork.Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, null, null, includes);

            return await query.SingleOrDefaultAsync();
        }
        #endregion

        #endregion

        #region IRemoveRepository 
        public virtual void Remove(T t)
        {
            _unitOfWork.Context.Remove(t);
        }

        public virtual void Remove(IEnumerable<T> t)
        {
            _unitOfWork.Context.RemoveRange(t);
        }
        #endregion

        #region IUpdateRepository 
        public virtual void Update(T t)
        {
            _unitOfWork.Context.Update(t);
        }

        public virtual void Update(IEnumerable<T> t)
        {
            _unitOfWork.Context.UpdateRange(t);
        }
        #endregion
    }
}
