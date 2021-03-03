using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dang.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        Task SendCommand<T>(T command) where T : Command;


        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
