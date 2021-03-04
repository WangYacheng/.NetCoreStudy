
using System.Threading.Tasks;
using Dang.Domain.Models;
namespace Dang.Application.Interfaces
{
    public interface IRelationDangService
    {
        public Task<bool> AddRelationDang(RelationDang param);
    }
}
