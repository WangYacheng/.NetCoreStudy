using Dang.Domain.Core.Operations;
using Dang.Domain.Interfaces;
using Dapper;
using JLSys.Domain.Core;
using JLSys.Domain.Core.Datas;
using JLSys.Domain.Interfaces;
using JLSys.Infra.Data.Context;
using JLSys.Infra.Data.Repository;
using JLSys.Infrastruct.Collections;
using JLSys.Infrastruct.DapperAdapter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JLSys.Infra.Data.UoW
{
    /// <summary>
    /// 工作单元类
    /// </summary>
    public class DangUnitOfWork<TContext> : IDangUnitOfWork where TContext : DbContext
    {
        //数据库上下文
        private readonly TContext _context;
        private bool disposed = false;

        //构造函数注入
        public DangUnitOfWork(TContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the db context.
        /// </summary>
        /// <returns>The instance of type <typeparamref name="TContext"/>.</returns>
        public TContext DbContext => _context;

        //上下文提交
        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public System.Data.IDbTransaction GetDbTransaction()
        {
            return _context.Database.CurrentTransaction.GetDbTransaction();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public void RollBackTransaction()
        {
            _context.Database.RollbackTransaction();
        }

        //手动回收
        public void Dispose()
        {
            //Dispose(true);

            //GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">The disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // dispose the db context.
                    _context.Dispose();
                }
            }

            disposed = true;
        }

        /// <summary>
        /// get connection
        /// </summary>
        /// <returns></returns>
        public System.Data.IDbConnection GetConnection()
        {
            return _context.Database.GetDbConnection();
        }

        /// <summary>
        /// QueryAsync
        /// ag:await _unitOfWork.QueryAsync`Demo`("select id,name from school where id = @id", new { id = 1 });
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public Task<IEnumerable<TEntity>> QueryAsync<TEntity>(string sql, object param = null, System.Data.IDbTransaction trans = null) where TEntity : class
        {
            var conn = GetConnection();
            return conn.QueryAsync<TEntity>(sql, param, trans);

        }

        /// <summary>
        /// ExecuteAsync
        /// ag:await _unitOfWork.ExecuteAsync("update school set name =@name where id =@id", new { name = "", id=1 });
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public async Task<int> ExecuteAsync(string sql, object param, System.Data.IDbTransaction trans = null)
        {
            var conn = GetConnection();
            return await conn.ExecuteAsync(sql, param, trans);

        }

        public async Task<IPagedList<TEntity>> QueryPagedListAsync<TEntity>(int pageIndex, int pageSize, string pageSql, object pageSqlArgs = null) where TEntity : class
        {
            if (pageSize < 1 || pageSize > 5000)
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            if (pageIndex < 1)
                throw new ArgumentOutOfRangeException(nameof(pageIndex));

            var partedSql = PagingUtil.SplitSql(pageSql);
            Infrastruct.DapperAdapter.ISqlAdapter sqlAdapter = null;
            if (_context.Database.IsMySql())
                sqlAdapter = new MysqlAdapter();
            if (sqlAdapter == null)
                throw new Exception("Unsupported database type");
            pageSql = sqlAdapter.PagingBuild(ref partedSql, pageSqlArgs, (pageIndex - 1) * pageSize, pageSize);
            var sqlCount = PagingUtil.GetCountSql(partedSql);
            var conn = GetConnection();
            var totalCount = await conn.ExecuteScalarAsync<int>(sqlCount, pageSqlArgs);
            var items = await conn.QueryAsync<TEntity>(pageSql, pageSqlArgs);
            var pagedList = items.ToPagedList(pageIndex - 1, pageSize, needPage: false, totalCount: totalCount);
            return pagedList;
        }

    }
}
