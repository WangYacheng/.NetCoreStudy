using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dang.Domain.Core;
using Dang.Domain.Core.Bus;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Code.Controllers
{
    public class ApiController : ControllerBase
    {
        private readonly DomainNotificationHandler _domainNotificationHandler;
        private readonly IMediatorHandler _mediator;

        protected ApiController(INotificationHandler<DomainNotification> domainNotificationHandler,
                                IMediatorHandler mediator) 
        {
            _domainNotificationHandler = (DomainNotificationHandler)domainNotificationHandler;
            _mediator = mediator;
        }

        protected IEnumerable<DomainNotification> Notifications => _domainNotificationHandler.GetNotifications();

        protected bool IsValidOperation()
        {
            return (!_domainNotificationHandler.HasNotifications());
        }

        protected new  IActionResult Response(object result=null, string message = "成功", int total_record = 0, int status = 1)
        {
            if (IsValidOperation())
            {
                return Ok(new { 
                    status=status,
                    data=result,
                    message=message,
                    total_record=total_record
                });
            }
            return Ok(new
            {
                status = 0,
                message = _domainNotificationHandler.GetNotifications().Select(n => n.Value).FirstOrDefault()
            });
        }

        protected IActionResult Response2(object result = null, object result2 = null, string message = "成功", int total_record = 0, int status = 1)
        {
            if (IsValidOperation())
            {
                return Ok(new
                {
                    status = status,
                    data=result,
                    data2=result2,
                    message=message,
                    total_record=total_record
                }) ;
            }

            return Ok(new { 
                status=0,
                message= _domainNotificationHandler.GetNotifications().Select(n => n.Value).FirstOrDefault()
            });
        }

        protected void NotifyModelStateErrors()
        {
            var errors = ModelState.Values.SelectMany(v=>v.Errors);
            foreach (var item in errors)
            {
                var erroMsg = item.Exception == null ? item.ErrorMessage : item.Exception.Message;
                NotifyError(string.Empty,erroMsg);
            }
        }

        protected void NotifyError(string code,string message)
        {
            _mediator.RaiseEvent(new DomainNotification(code,message));
        }

        protected void AddIdentityErrors(IdentityResult result)
        {
            foreach (var item in result.Errors)
            {
                NotifyError(result.ToString(),item.Description);
            }
        }
    }
}
