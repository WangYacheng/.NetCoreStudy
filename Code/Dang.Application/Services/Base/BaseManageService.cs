using Dang.Application.Interfaces.Base;
using Dang.Domain.Core;
using Dang.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dang.Application.Services.Base
{
    public class BaseManageService: IBaseManageService
    {
        protected readonly IMediatorHandler _bus;

        public BaseManageService(IMediatorHandler bus)
        {
            _bus = bus;
        }

        protected void NotifyError(string code, string message)
        {
            _bus.RaiseEvent(new DomainNotification(code, message));
        }
    }
}
