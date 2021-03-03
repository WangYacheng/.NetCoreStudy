using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dang.Domain.Core.Operations
{
    public interface ISaveAsync
    {
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveChangesAsync();
    }
}
