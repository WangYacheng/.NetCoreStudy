
using System;
using System.Threading.Tasks;
using Dang.Application.Interfaces.Base;
using Dang.Domain.Models;

namespace Dang.Application.Interfaces
{
    public interface IRelationDangService: IBaseAppService, IDisposable
    {
        public Task<bool> AddRelationDang(RelationDang param);

        
    }
}
