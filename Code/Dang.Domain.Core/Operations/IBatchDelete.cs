using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Dang.Domain.Core.Operations
{
    /// <summary>
    /// 批量更新
    /// </summary>
    public interface IBatchDelete<TEntity, in TKey> where TEntity : class
    {

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities">实体集合</param>
        int BatchDelete(Expression<Func<TEntity, bool>> predicate);

    }
}
