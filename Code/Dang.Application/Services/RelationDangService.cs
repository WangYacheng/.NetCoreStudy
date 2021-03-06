﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dang.Application.Interfaces;
using Dang.Application.Services.Base;
using Dang.Domain.Core.Bus;
using Dang.Domain.Interfaces;
using Dang.Domain.Models;

namespace Dang.Application.Services
{
    class RelationDangService: BaseAppService,IRelationDangService
    {
        private readonly IRelationDangRepository _relationDangRepository;
        private readonly IDangUnitOfWork _dangUnitOfWork;
        public RelationDangService(IRelationDangRepository relationDangRepository, IMediatorHandler bus) :base(bus)
        {
            _relationDangRepository = relationDangRepository;
        }

        public async Task<bool> AddRelationDang(RelationDang param)
        {
             await _relationDangRepository.AddAsync(param);
             await _dangUnitOfWork.SaveChangesAsync();

            return true;

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
