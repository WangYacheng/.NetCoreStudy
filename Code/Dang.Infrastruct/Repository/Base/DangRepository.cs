using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dang.Domain.Core;
using Dang.Domain.Interfaces;
using Dang.Context;
using Microsoft.EntityFrameworkCore;
using Dang.Domain.Interfaces.Base;
using Dang.Domain.Core.Models;

namespace Dang.Repository.Base
{
    /// <summary>
    /// 泛型仓储，实现泛型仓储接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class DangRepository<TEntity> : DangRepository<TEntity, Guid>, IDangRepository<TEntity, Guid> where TEntity : class, IKey<Guid>
    {
        public DangRepository(DbContext context) : base(context)
        {

        }
    }

    /// <summary>
    /// 泛型仓储，实现泛型仓储接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class DangRepository<TEntity, TKey> : StoreBase<TEntity, TKey>, IDangRepository<TEntity, TKey> where TEntity : class, IKey<TKey>
    {
        public DangRepository(DbContext context) : base(context)
        {

        }

        public void Dispose()
        {
            //GC.SuppressFinalize(this);
        }

    }
}
