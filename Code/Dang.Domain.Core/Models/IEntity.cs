using System;
using System.Collections.Generic;
using System.Text;

namespace Dang.Domain.Core.Models
{
    public interface IEntity
    {

    }

    public interface IEntity<out Tkey>:IKey<Tkey>,IEntity
    { }

    public interface IEntity<in TEntity, out TKey> : IEntity<TKey> where TEntity : IEntity
    { }
}
