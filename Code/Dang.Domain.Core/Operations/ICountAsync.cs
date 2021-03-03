﻿using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dang.Domain.Core.Operations
{
    /// <summary>
    /// 查找数量
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public interface ICountAsync<TEntity, in TKey> where TEntity : class
    {
        /// <summary>
        /// 查找数量
        /// </summary>
        /// <param name="predicate">查询条件</param>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null);
    }
}
