using System;
using System.Collections.Generic;
using System.Text;
using Dang.Domain.Core.Operations;
namespace Dang.Domain.Interfaces.Base
{
    public interface IStore<TEntity> :IStore<TEntity,Guid> where TEntity :class
    {
    }

    public interface IStore<TEntity,in TKey>:IQueryStore<TEntity,TKey>,
        IAdd<TEntity, TKey>,
        IAddAsync<TEntity, TKey>,
        IUpdate<TEntity, TKey>,
        IUpdateAsync<TEntity, TKey>,
        IRemove<TEntity, TKey>,
        IRemoveAsync<TEntity, TKey>,
        IBatchDelete<TEntity, TKey>,
        IBatchDeleteAsync<TEntity, TKey>,
        IBatchUpdate<TEntity, TKey>,
        IBatchUpdateAsync<TEntity, TKey>,
        IUpdateProperty<TEntity, TKey>,
        ISave,
        ISaveAsync
        where TEntity : class
    {
    }
}
