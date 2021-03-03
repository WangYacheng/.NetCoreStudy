using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Dang.Domain.Core.Operations
{

    /// <summary>
    /// 修改实体部分字段
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public interface IUpdateProperty<TEntity, in TKey> where TEntity : class
    {
        /// <summary>
        /// 修改实体部分字段
        /// </summary>
        /// <param name="entity">实体</param>
        void UpdateProperty<TProperty>(TEntity entity, List<Expression<Func<TEntity, TProperty>>> lspropertyExpression);


    }
}
