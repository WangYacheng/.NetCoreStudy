using Dang.Domain.Core;
using Dang.Domain.Interfaces;
using Dang.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dang.Domain.Interfaces.Base;
using Dang.Domain.Core.Models;
using Z.EntityFramework.Plus;

namespace Dang.Repository.Base
{
    /// <summary>
    /// 存储器
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    public abstract class StoreBase<TEntity> : StoreBase<TEntity, Guid>, IStore<TEntity>
        where TEntity : class, IKey<Guid>
    {
        /// <summary>
        /// 初始化存储器
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        protected StoreBase(DbContext context) : base(context)
        {
        }
    }

    /// <summary>
    /// 存储器
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public abstract class StoreBase<TEntity, TKey> : QueryStoreBase<TEntity, TKey>, IStore<TEntity, TKey> where TEntity : class, IKey<TKey>
    {
        /// <summary>
        /// 初始化存储器
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        protected StoreBase(DbContext context) : base(context)
        {
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        public virtual void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            Set.Add(entity);
        }

        /// <summary>
        /// 添加实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public virtual void Add(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            Set.AddRange(entities);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            await Set.AddAsync(entity, cancellationToken);
        }

        /// <summary>
        /// 添加实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task AddAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            await Set.AddRangeAsync(entities, cancellationToken);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        public virtual void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            Set.Update(entity);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        public virtual Task UpdateAsync(TEntity entity)
        {
            Update(entity);
            return Task.CompletedTask;
        }

        /// <summary>
        /// 修改实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public virtual void Update(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            foreach (var entity in entities)
                Update(entity);
        }

        /// <summary>
        /// 修改实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public virtual async Task UpdateAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            foreach (var entity in entities)
                await UpdateAsync(entity);
        }


        public virtual void UpdateProperty2<TProperty>(TEntity entity, List<KeyValuePair<bool, Expression<Func<TEntity, TProperty>>>> lspropertyExpression)
        {
            if (lspropertyExpression == null || lspropertyExpression.Count <= 0)
            {
                throw new ArgumentNullException(nameof(lspropertyExpression));
            }
            Db.Attach(entity);
            foreach (var expression in lspropertyExpression)
            {
                Db.Entry(entity).Property(expression.Value).IsModified = true;
            }
        }

        public virtual void UpdateProperty<TProperty>(TEntity entity, List<Expression<Func<TEntity, TProperty>>> lspropertyExpression)
        {
            if (lspropertyExpression == null || lspropertyExpression.Count <= 0)
            {
                throw new ArgumentNullException(nameof(lspropertyExpression));
            }
            Db.Attach(entity);
            foreach (var expression in lspropertyExpression)
            {
                Db.Entry(entity).Property(expression).IsModified = true;
            }
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="id">实体标识</param>
        public virtual void Remove(TKey id)
        {
            var entity = FindById(id);
            Delete(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        private void Delete(TEntity entity)
        {
            if (entity == null)
                return;
            Set.Remove(entity);
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task RemoveAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entity = await FindByIdAsync(id);
            Delete(entity);
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">实体</param>
        public virtual void Remove(TEntity entity)
        {
            if (entity == null)
                return;
            Remove(entity.Id);
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (entity == null)
                return;
            await RemoveAsync(entity.Id, cancellationToken);
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="ids">标识集合</param>
        public virtual void Remove(IEnumerable<TKey> ids)
        {
            if (ids == null)
                return;
            var list = FindByIds(ids);
            Delete(list);
        }

        /// <summary>
        /// 删除实体集合
        /// </summary>
        private void Delete(List<TEntity> list)
        {
            if (list == null)
                return;
            if (!list.Any())
                return;
            Set.RemoveRange(list);
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="ids">标识集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task RemoveAsync(IEnumerable<TKey> ids, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (ids == null)
                return;
            var entities = await FindByIdsAsync(ids, cancellationToken);
            Delete(entities);
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public virtual void Remove(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                return;
            Remove(entities.Select(t => t.Id));
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task RemoveAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (entities == null)
                return;
            await RemoveAsync(entities.Select(t => t.Id), cancellationToken);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return Db.SaveChanges() > 0;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveChangesAsync()
        {
            return (await Db.SaveChangesAsync()) > 0;
        }

        #region 批量操作

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities">实体集合</param>
        public virtual int BatchUpdate(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> updateExpression, System.Data.Common.DbTransaction dbTransaction = null)
        {
            if (dbTransaction != null)
            {
                return Set.Where(predicate).Update(updateExpression, x => { x.Executing = command => command.Transaction = dbTransaction; });
            }
            return Set.Where(predicate).Update(updateExpression);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities">实体集合</param>
        public virtual async Task<int> BatchUpdateAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> updateExpression, System.Data.Common.DbTransaction dbTransaction = null)
        {
            if (dbTransaction != null)
            {
                return await Set.Where(predicate).UpdateAsync(updateExpression, x => { x.Executing = command => command.Transaction = dbTransaction; });
            }
            return await Set.Where(predicate).UpdateAsync(updateExpression);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities">实体集合</param>
        public virtual int BatchDelete(Expression<Func<TEntity, bool>> predicate)
        {
            return Set.Where(predicate).Delete();
        }

        /// <summary>
        /// 批量删除异步
        /// </summary>
        /// <param name="entities">实体集合</param>
        public virtual async Task<int> BatchDeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Set.Where(predicate).DeleteAsync();
        }

        #endregion
    }
}
