using System;
using System.Linq;
using System.Linq.Expressions;

namespace Dang.Domain.Core.Operations {
    /// <summary>
    /// 获取查询对象
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public interface IFindQueryable<TEntity, in TKey> where TEntity : class{
        /// <summary>
        /// 获取未跟踪查询对象
        /// </summary>
        IQueryable<TEntity> FindAsNoTracking();
        /// <summary>
        /// 获取查询对象
        /// </summary>
        IQueryable<TEntity> Find();
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="predicate">条件</param>
        IQueryable<TEntity> Find( Expression<Func<TEntity, bool>> predicate );
    }
}
