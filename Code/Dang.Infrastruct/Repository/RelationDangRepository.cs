using Dang.Context;
using Dang.Domain.Interfaces;
using Dang.Domain.Models;
using Dang.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dang.Infrastruct.Repository
{
    public class RelationDangRepository: DangRepository<RelationDang, int>,IRelationDangRepository
    {
        public RelationDangRepository(DangContext context)
            : base(context)
        { }
    }
}
