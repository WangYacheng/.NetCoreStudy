using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dang.Domain.Core.Operations
{
    /// <summary>
    /// 批量更新
    /// </summary>
    public interface IBatchDeleteAsync<TEntity, in TKey> where TEntity : class
    {

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities">实体集合</param>
        Task<int> BatchDeleteAsync(Expression<Func<TEntity, bool>> predicate);


    }
}
