using Dang.Domain.Core;
using Dang.Domain.Core.Bus;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dang.Application.Interfaces;
using Dang.Domain.Models;
namespace Code.Controllers
{
    [Route("api/[controller]/[action]")]
    public class HomeController : ApiController
    {
        private readonly IRelationDangService _relationDangService;
        public HomeController(INotificationHandler<DomainNotification> notification,
            IMediatorHandler mediator,
            IRelationDangService relationDangService) :base(notification,mediator)
        {
            _relationDangService = relationDangService;
        }
        
        public IActionResult Index()
        {
            //return Response(result:"sss",status:1);
            return null;
        }

        public string Index2()
        {
            return "string";
        }

        public async Task<IActionResult> AddRelationDang()
        {
            RelationDang model = new RelationDang() 
            {
                Name="江户川乱步",
                RelationType=5,
                EstimateDang="不评",
                EstimateOther="不评",

            };
            if (await _relationDangService.AddRelationDang(model))
            {
                return Response(message:"增加成功",status:1);
            }

            return Response(message:"失败",status:0);
        }
    }
}
