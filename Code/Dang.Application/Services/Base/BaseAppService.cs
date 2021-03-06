using Dang.Domain.Core;
using Dang.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dang.Application.Services.Base
{
    public class BaseAppService:Dang.Application.Interfaces.Base.IBaseAppService
    {
        protected readonly IMediatorHandler _bus;

        public BaseAppService(IMediatorHandler bus)
        {
            _bus = bus;
        }

        protected void NotifyError(string code, string message)
        {
            _bus.RaiseEvent(new DomainNotification(code, message));
        }
    }
}
