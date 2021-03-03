using Dang.Domain.Core;
using Dang.Domain.Core.Bus;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code.Controllers
{
    [Route("api/[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        //public HomeController(INotificationHandler<DomainNotification> notification,
        //    IMediatorHandler mediator) :base(notification,mediator)
        //{ 
        //    
        //}
        
        public IActionResult Index()
        {
            //return Response(result:"sss",status:1);
            return null;
        }

        public string Index2()
        {
            return "string";
        }
    }
}
