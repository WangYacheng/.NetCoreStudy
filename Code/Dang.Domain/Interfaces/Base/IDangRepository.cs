using System;
using System.Collections.Generic;
using System.Text;

namespace Dang.Domain.Interfaces.Base
{
    public interface IDangRepository<TEntity> : IDangRepository<TEntity, Guid> where TEntity : class
    {
    }

    public interface IDangRepository<TEntity, in TKey> : IStore<TEntity, TKey>, IDisposable where TEntity : class
    {

    }
}
