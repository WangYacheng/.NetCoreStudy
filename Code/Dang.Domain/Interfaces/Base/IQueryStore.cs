using Dang.Domain.Core.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dang.Domain.Interfaces.Base
{
    public interface IQueryStore<TEntity>:IQueryStore<TEntity,Guid>
        where TEntity:class
    {
    }

    public interface IQueryStore<TEntity, in TKey> : IFindQueryable<TEntity, TKey>,
    IFindById<TEntity, TKey>,
    IFindByIdAsync<TEntity, TKey>,
    IFindByIds<TEntity, TKey>,
    IFindByIdsAsync<TEntity, TKey>,
    IFindByIdNoTracking<TEntity, TKey>,
    IFindByIdNoTrackingAsync<TEntity, TKey>,
    IFindByIdsNoTracking<TEntity, TKey>,
    IFindByIdsNoTrackingAsync<TEntity, TKey>,
    ISingle<TEntity, TKey>,
    ISingleAsync<TEntity, TKey>,
    IFindAll<TEntity, TKey>,
    IFindAllAsync<TEntity, TKey>,
    IFindAllNoTracking<TEntity, TKey>,
    IFindAllNoTrackingAsync<TEntity, TKey>,
    IExists<TEntity, TKey>,
    IExistsAsync<TEntity, TKey>,
    IExistsByExpression<TEntity, TKey>,
    IExistsByExpressionAsync<TEntity, TKey>,
    ICount<TEntity, TKey>,
    ICountAsync<TEntity, TKey>,
    IPageQuery<TEntity, TKey>,
    IPageQueryAsync<TEntity, TKey>,
    ISql<TEntity>

    where TEntity : class
    {

    }
}
