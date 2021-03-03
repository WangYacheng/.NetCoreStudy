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
    public interface IBatchUpdateAsync<TEntity, in TKey> where TEntity : class
    {

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities">实体集合</param>
        Task<int> BatchUpdateAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> updateExpression, System.Data.Common.DbTransaction dbTransaction = null);


    }
}
