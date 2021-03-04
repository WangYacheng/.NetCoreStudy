using Dang.Domain.Core.Operations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dang.Domain.Interfaces
{
    public interface IDangUnitOfWork:IDisposable
    {
        /// <summary>
        /// 提交更改
        /// </summary>
        /// <returns></returns>
        bool Commit();
        /// <summary>
        /// 提交更改
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
        /// <summary>
        /// 提交更改异步
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();
        /// <summary>
        /// 开启事务
        /// </summary>
        void BeginTransaction();
        /// <summary>
        /// 获取Db事务对象
        /// </summary>
        /// <returns></returns>
        System.Data.IDbTransaction GetDbTransaction();
        /// <summary>
        /// 提交事务
        /// </summary>
        void CommitTransaction();
        /// <summary>
        /// 回滚事务
        /// </summary>
        void RollBackTransaction();

        /// <summary>
        /// get connection
        /// </summary>
        /// <returns></returns>
        System.Data.IDbConnection GetConnection();

        #region command sql

        /// <summary>
        /// QueryAsync
        /// ag:await _unitOfWork.QueryAsync`Demo`("select id,name from school where id = @id", new { id = 1 });
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> QueryAsync<TEntity>(string sql, object param = null, System.Data.IDbTransaction trans = null) where TEntity : class;

        /// <summary>
        /// ExecuteAsync
        /// ag:await _unitOfWork.ExecuteAsync("update school set name =@name where id =@id", new { name = "", id=1 });
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        Task<int> ExecuteAsync(string sql, object param, System.Data.IDbTransaction trans = null);

        /// <summary>
        /// QueryPagedListAsync, complex sql, use "select * from (your sql) b"
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageSql"></param>
        /// <param name="pageSqlArgs"></param>
        /// <returns></returns>
        Task<IPagedList<TEntity>> QueryPagedListAsync<TEntity>(int pageIndex, int pageSize, string pageSql, object pageSqlArgs = null)
            where TEntity : class;
        #endregion
    }
}
