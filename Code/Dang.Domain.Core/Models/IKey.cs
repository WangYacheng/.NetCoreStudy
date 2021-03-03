using System;
using System.Collections.Generic;
using System.Text;

namespace Dang.Domain.Core.Models
{
    public interface IKey<out TKey>
    {
        TKey Id { get; }
    }
}
