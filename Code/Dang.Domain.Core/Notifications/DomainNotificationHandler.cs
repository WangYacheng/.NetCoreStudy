using System;
using System.Collections.Generic;
using MediatR;

namespace Dang.Domain.Core.Notifications
{
    public class DomainNotificationHandler: INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        { }
    }
}
