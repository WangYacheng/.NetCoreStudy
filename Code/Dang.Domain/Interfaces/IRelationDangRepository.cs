using System;
using System.Collections.Generic;
using System.Text;
using Dang.Domain;
using Dang.Domain.Models;
using Dang.Domain.Interfaces.Base;

namespace Dang.Domain.Interfaces
{
    public interface IRelationDangRepository:IDangRepository<RelationDang,int>
    {
    }
}
