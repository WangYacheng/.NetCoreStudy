﻿using System;
using System.Linq.Expressions;

namespace Dang.Domain.Core.Operations {
    /// <summary>
    /// 通过表达式判断是否存在
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public interface IExistsByExpression<TEntity, in TKey> where TEntity : class {
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="predicate">条件</param>
        bool Exists( Expression<Func<TEntity, bool>> predicate );
    }
}