using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dang.Domain.Core;
using Dang.Domain.Core.Operations;
using Dang.Domain.Interfaces;
using Dang.Context;
using Dang.Infrastruct.Collections;
using Microsoft.EntityFrameworkCore;
using Dang.Domain.Interfaces.Base;
using Dang.Domain.Core.Models;
using Dang.Common;

namespace Dang.Repository.Base
{
    /// <summary>
    /// 查询存储器
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    public abstract class QueryStoreBase<TEntity> : QueryStoreBase<TEntity, Guid>, IQueryStore<TEntity> where TEntity : class, IKey<Guid>
    {
        /// <summary>
        /// 初始化查询存储器
        /// </summary>
        protected QueryStoreBase(DangContext context) : base(context)
        {
        }
    }

    /// <summary>
    /// 查询存储器
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public abstract class QueryStoreBase<TEntity, TKey> : IQueryStore<TEntity, TKey> where TEntity : class, IKey<TKey>
    {
        /// <summary>
        /// Context上下文
        /// </summary>
        protected DbContext Db;

        /// <summary>
        /// 实体集
        /// </summary>
        protected DbSet<TEntity> Set;

        /// <summary>
        /// 初始化查询存储器
        /// </summary>
        protected QueryStoreBase(DbContext context)
        {
            Db = context;
            Set = Db.Set<TEntity>();
        }

        /// <summary>
        /// 获取未跟踪查询对象
        /// </summary>
        public IQueryable<TEntity> FindAsNoTracking()
        {
            return Set.AsNoTracking();
        }

        /// <summary>
        /// 获取查询对象
        /// </summary>
        public IQueryable<TEntity> Find()
        {
            return Set;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="predicate">条件</param>
        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Set.Where(predicate);
        }

        public TEntity FindById(TKey id)
        {
            if (id.SafeString().IsEmpty())
                return null;
            return Set.Find(id);
        }

        public async Task<TEntity> FindByIdAsync(TKey id)
        {
            if (id.SafeString().IsEmpty())
                return null;
            return await Set.FindAsync(id);
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="ids">标识列表</param>
        public virtual List<TEntity> FindByIds(params TKey[] ids)
        {
            return FindByIds((IEnumerable<TKey>)ids);
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="ids">标识列表</param>
        public virtual List<TEntity> FindByIds(IEnumerable<TKey> ids)
        {
            if (ids == null)
                return null;
            return Find(t => ids.Contains(t.Id)).ToList();
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="ids">逗号分隔的标识列表，范例："1,2"</param>
        public virtual List<TEntity> FindByIds(string ids)
        {
            var idList = Dang.Common.Helpers.Convert.ToList<TKey>(ids);
            return FindByIds(idList);
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="ids">标识列表</param>
        public virtual async Task<List<TEntity>> FindByIdsAsync(params TKey[] ids)
        {
            return await FindByIdsAsync((IEnumerable<TKey>)ids);
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="ids">标识列表</param>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task<List<TEntity>> FindByIdsAsync(IEnumerable<TKey> ids, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (ids == null)
                return null;
            return await Find(t => ids.Contains(t.Id)).ToListAsync(cancellationToken);
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="ids">逗号分隔的标识列表，范例："1,2"</param>
        public virtual async Task<List<TEntity>> FindByIdsAsync(string ids)
        {
            var idList = Dang.Common.Helpers.Convert.ToList<TKey>(ids);
            return await FindByIdsAsync(idList);
        }

        /// <summary>
        /// 查找未跟踪单个实体
        /// </summary>
        /// <param name="id">标识</param>
        public virtual TEntity FindByIdNoTracking(TKey id)
        {
            var entities = FindByIdsNoTracking(id);
            if (entities == null || entities.Count == 0)
                return null;
            return entities[0];
        }

        /// <summary>
        /// 查找未跟踪单个实体
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task<TEntity> FindByIdNoTrackingAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entities = await FindByIdsNoTrackingAsync(id);
            if (entities == null || entities.Count == 0)
                return null;
            return entities[0];
        }

        /// <summary>
        /// 查找实体列表,不跟踪
        /// </summary>
        /// <param name="ids">标识列表</param>
        public virtual List<TEntity> FindByIdsNoTracking(params TKey[] ids)
        {
            return FindByIdsNoTracking((IEnumerable<TKey>)ids);
        }

        /// <summary>
        /// 查找实体列表,不跟踪
        /// </summary>
        /// <param name="ids">标识列表</param>
        public virtual List<TEntity> FindByIdsNoTracking(IEnumerable<TKey> ids)
        {
            if (ids == null)
                return null;
            return FindAsNoTracking().Where(t => ids.Contains(t.Id)).ToList();
        }

        /// <summary>
        /// 查找实体列表,不跟踪
        /// </summary>
        /// <param name="ids">逗号分隔的标识列表，范例："1,2"</param>
        public virtual List<TEntity> FindByIdsNoTracking(string ids)
        {
            var idList = Dang.Common.Helpers.Convert.ToList<TKey>(ids);
            return FindByIdsNoTracking(idList);
        }

        /// <summary>
        /// 查找实体列表,不跟踪
        /// </summary>
        /// <param name="ids">标识列表</param>
        public virtual async Task<List<TEntity>> FindByIdsNoTrackingAsync(params TKey[] ids)
        {
            return await FindByIdsNoTrackingAsync((IEnumerable<TKey>)ids);
        }

        /// <summary>
        /// 查找实体列表,不跟踪
        /// </summary>
        /// <param name="ids">标识列表</param>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task<List<TEntity>> FindByIdsNoTrackingAsync(IEnumerable<TKey> ids, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (ids == null)
                return null;
            return await FindAsNoTracking().Where(t => ids.Contains(t.Id)).ToListAsync(cancellationToken);
        }

        /// <summary>
        /// 查找实体列表,不跟踪
        /// </summary>
        /// <param name="ids">逗号分隔的标识列表，范例："1,2"</param>
        public virtual async Task<List<TEntity>> FindByIdsNoTrackingAsync(string ids)
        {
            var idList = Dang.Common.Helpers.Convert.ToList<TKey>(ids);
            return await FindByIdsNoTrackingAsync(idList);
        }

        /// <summary>
        /// 查找单个实体
        /// </summary>
        /// <param name="predicate">条件</param>
        public virtual TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return Set.FirstOrDefault(predicate);
        }

        /// <summary>
        /// 查找单个实体
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Set.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="predicate">条件</param>
        public virtual List<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return Set.ToList();
            return Find(predicate).ToList();
        }

        /// <summary>
        /// 查找实体列表,不跟踪
        /// </summary>
        /// <param name="predicate">条件</param>
        public virtual List<TEntity> FindAllNoTracking(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return FindAsNoTracking().ToList();
            return FindAsNoTracking().Where(predicate).ToList();
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="predicate">条件</param>
        public virtual async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return await Set.ToListAsync();
            return await Find(predicate).ToListAsync();
        }

        /// <summary>
        /// 查找实体列表,不跟踪
        /// </summary>
        /// <param name="predicate">条件</param>
        public virtual async Task<List<TEntity>> FindAllNoTrackingAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return await FindAsNoTracking().ToListAsync();
            return await FindAsNoTracking().Where(predicate).ToListAsync();
        }

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="predicate">条件</param>
        public virtual bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                return false;
            return Set.Any(predicate);
        }

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="ids">标识列表</param>
        public virtual bool Exists(params TKey[] ids)
        {
            if (ids == null)
                return false;
            return Exists(t => ids.Contains(t.Id));
        }

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="predicate">条件</param>
        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                return false;
            return await Set.AnyAsync(predicate);
        }

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="ids">标识列表</param>
        public virtual async Task<bool> ExistsAsync(params TKey[] ids)
        {
            if (ids == null)
                return false;
            return await ExistsAsync(t => ids.Contains(t.Id));
        }

        /// <summary>
        /// 查找数量
        /// </summary>
        /// <param name="predicate">条件</param>
        public virtual int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return Set.Count();
            return Set.Count(predicate);
        }

        /// <summary>
        /// 查找数量
        /// </summary>
        /// <param name="predicate">条件</param>
        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return await Set.CountAsync();
            return await Set.CountAsync(predicate);
        }

        /// <summary>
        /// Gets the <see cref="IPagedList{TEntity}"/> based on a predicate, orderby delegate and page information. This method default no-tracking query.
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <param name="orderBy">A function to order elements.</param>
        /// <param name="pageIndex">The index of page.</param>
        /// <param name="pageSize">The size of the page.</param>
        /// <param name="disableTracking"><c>True</c> to disable changing tracking; otherwise, <c>false</c>. Default to <c>true</c>.</param>
        /// <returns>An <see cref="IPagedList{TEntity}"/> that contains elements that satisfy the condition specified by <paramref name="predicate"/>.</returns>
        /// <remarks>This method default no-tracking query.</remarks>
        public virtual IPagedList<TEntity> GetPagedList(Expression<Func<TEntity, bool>> predicate = null,
                                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                int pageIndex = 0,
                                                int pageSize = 20,
                                                bool disableTracking = true)
        {
            IQueryable<TEntity> query = Set;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToPagedList(pageIndex, pageSize, 1);
            }
            else
            {
                return query.ToPagedList(pageIndex, pageSize, 1);
            }
        }

        /// <summary>
        /// Gets the <see cref="IPagedList{TEntity}"/> based on a predicate, orderby delegate and page information. This method default no-tracking query.
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <param name="orderBy">A function to order elements.</param>
        /// <param name="pageIndex">The index of page.</param>
        /// <param name="pageSize">The size of the page.</param>
        /// <param name="disableTracking"><c>True</c> to disable changing tracking; otherwise, <c>false</c>. Default to <c>true</c>.</param>
        /// <param name="fromSql">use EF Core FromSqlRaw</param>
        /// <param name="cancellationToken">
        ///     A <see cref="CancellationToken" /> to observe while waiting for the task to complete.
        /// </param>
        /// <returns>An <see cref="IPagedList{TEntity}"/> that contains elements that satisfy the condition specified by <paramref name="predicate"/>.</returns>
        /// <remarks>This method default no-tracking query.</remarks>
        public virtual Task<IPagedList<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>> predicate = null,
                                                           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                           int pageIndex = 0,
                                                           int pageSize = 20,
                                                           bool disableTracking = true,
                                                           string fromSql = "",
                                                           CancellationToken cancellationToken = default(CancellationToken))
        {
            IQueryable<TEntity> query = Set;
            if (string.IsNullOrEmpty(fromSql))
            {
                query = Set;
            }
            else
            {
                query = Set.FromSqlRaw(fromSql);
            }
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToPagedListAsync(pageIndex, pageSize, 1, cancellationToken);
            }
            else
            {
                return query.ToPagedListAsync(pageIndex, pageSize, 1, cancellationToken);
            }
        }

        /// <summary>
        /// Gets the <see cref="IPagedList{TResult}"/> based on a predicate, orderby delegate and page information. This method default no-tracking query.
        /// </summary>
        /// <param name="selector">The selector for projection.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <param name="orderBy">A function to order elements.</param>
        /// <param name="pageIndex">The index of page.</param>
        /// <param name="pageSize">The size of the page.</param>
        /// <param name="disableTracking"><c>True</c> to disable changing tracking; otherwise, <c>false</c>. Default to <c>true</c>.</param>
        /// <returns>An <see cref="IPagedList{TResult}"/> that contains elements that satisfy the condition specified by <paramref name="predicate"/>.</returns>
        /// <remarks>This method default no-tracking query.</remarks>
        public virtual IPagedList<TResult> GetPagedList<TResult>(Expression<Func<TEntity, TResult>> selector,
                                                         Expression<Func<TEntity, bool>> predicate = null,
                                                         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                         int pageIndex = 0,
                                                         int pageSize = 20,
                                                         bool disableTracking = true)
            where TResult : class
        {
            IQueryable<TEntity> query = Set;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return orderBy(query).Select(selector).ToPagedList(pageIndex, pageSize, 1);
            }
            else
            {
                return query.Select(selector).ToPagedList(pageIndex, pageSize, 1);
            }
        }

        /// <summary>
        /// Gets the <see cref="IPagedList{TEntity}"/> based on a predicate, orderby delegate and page information. This method default no-tracking query.
        /// </summary>
        /// <param name="selector">The selector for projection.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <param name="orderBy">A function to order elements.</param>
        /// <param name="pageIndex">The index of page.</param>
        /// <param name="pageSize">The size of the page.</param>
        /// <param name="disableTracking"><c>True</c> to disable changing tracking; otherwise, <c>false</c>. Default to <c>true</c>.</param>
        /// <param name="cancellationToken">
        ///     A <see cref="CancellationToken" /> to observe while waiting for the task to complete.
        /// </param>
        /// <returns>An <see cref="IPagedList{TEntity}"/> that contains elements that satisfy the condition specified by <paramref name="predicate"/>.</returns>
        /// <remarks>This method default no-tracking query.</remarks>
        public virtual Task<IPagedList<TResult>> GetPagedListAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
                                                                    Expression<Func<TEntity, bool>> predicate = null,
                                                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                                    int pageIndex = 0,
                                                                    int pageSize = 20,
                                                                    bool disableTracking = true,
                                                                    CancellationToken cancellationToken = default(CancellationToken))
            where TResult : class
        {
            IQueryable<TEntity> query = Set;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return orderBy(query).Select(selector).ToPagedListAsync(pageIndex, pageSize, 1, cancellationToken);
            }
            else
            {
                return query.Select(selector).ToPagedListAsync(pageIndex, pageSize, 1, cancellationToken);
            }
        }

        /// <summary>
        /// Uses raw SQL queries to fetch the specified <typeparamref name="TEntity" /> data.
        /// </summary>
        /// <param name="sql">The raw SQL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>An <see cref="IQueryable{TEntity}" /> that contains elements that satisfy the condition specified by raw SQL.</returns>
        public virtual IQueryable<TEntity> FromSql(string sql, params object[] parameters) => Set.FromSqlRaw(sql, parameters).AsNoTracking();

        /// <summary>
        /// Uses raw SQL queries to fetch the specified <typeparamref name="TEntity" /> data.
        /// </summary>
        /// <param name="sql">The raw SQL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>An <see cref="IQueryable{TEntity}" /> that contains elements that satisfy the condition specified by raw SQL.</returns>
        public virtual IQueryable<TEntity> FromSqlTracking(string sql, params object[] parameters) => Set.FromSqlRaw(sql, parameters);
    }
}
