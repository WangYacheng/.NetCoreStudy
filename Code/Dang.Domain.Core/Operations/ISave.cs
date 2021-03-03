using System;
using System.Collections.Generic;
using System.Text;

namespace Dang.Domain.Core.Operations
{
    public interface ISave
    {
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();
    }
}
