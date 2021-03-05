using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dang.Infrastruct.DB
{
    public class SqlHelper:ISqlHelper,IDisposable
    {
        public SqlHelper(IDbConnection connection)
        {
            Connection = connection;
        }

        public IDbConnection Connection { get; set; }

        public void Dispose()
        {
            Connection.Dispose();
        }


        private IDbCommand buildCommand(string sqlText, CommandType commandType, IDbTransaction trans = null, params IDbDataParameter[] parms)
        {
            if (Connection == null)
                throw new Exception("IDbConnection is NULL");

            IDbCommand command = Connection.CreateCommand();
            command.CommandText = sqlText;
            command.CommandType = commandType;
            if (trans != null)
            {
                command.Transaction = trans;
            }
            if (parms != null && parms.Length > 0)
            {
                foreach (var item in parms)
                {
                    command.Parameters.Add(item);
                }
            }

            return command;
        }

        public int Execute(string sqlText, CommandType commandType = CommandType.Text, IDbTransaction trans = null, params IDbDataParameter[] parms)
        {
            if (trans != null)
            {
                Connection = trans.Connection;

                return buildCommand(sqlText, commandType, trans, parms).ExecuteNonQuery();
            }
            else
            {
                if (Connection == null)
                    throw new Exception("IDbConnection is NULL");

                ConnectionState originalState = Connection.State;

                if (originalState != ConnectionState.Open)
                    Connection.Open();

                try
                {
                    return buildCommand(sqlText, commandType, trans, parms).ExecuteNonQuery();
                }
                finally
                {
                    if (originalState == ConnectionState.Closed)
                        Connection.Close();
                }
            }

        }



        public int Execute(string sqlText, Func<IDbDataParameter[]> func, CommandType commandType = CommandType.Text, IDbTransaction trans = null)
        {
            return Execute(sqlText, commandType, trans, func());
        }

        public DataTable Query(string sqlText, CommandType commandType = CommandType.Text, params IDbDataParameter[] parms)
        {
            if (Connection == null)
                throw new Exception("IDbConnection is NULL");

            ConnectionState originalState = Connection.State;

            if (originalState != ConnectionState.Open)
                Connection.Open();
            try
            {
                var reader = buildCommand(sqlText, commandType, null, parms).ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
            finally
            {
                if (originalState == ConnectionState.Closed)
                    Connection.Close();
            }
        }

        public DataTable Query(string sqlText, Func<IDbDataParameter[]> func, CommandType commandType = CommandType.Text)
        {
            return Query(sqlText, commandType, func());
        }

        public object Scalar(string sqlText, CommandType commandType = CommandType.Text, params IDbDataParameter[] parms)
        {
            if (Connection == null)
                throw new Exception("IDbConnection is NULL");

            ConnectionState originalState = Connection.State;

            if (originalState != ConnectionState.Open)
                Connection.Open();
            try
            {
                return buildCommand(sqlText, commandType, null, parms).ExecuteScalar();
            }
            finally
            {
                if (originalState == ConnectionState.Closed)
                    Connection.Close();
            }
        }

        public object Scalar(string sqlText, Func<IDbDataParameter[]> func, CommandType commandType = CommandType.Text)
        {
            return Scalar(sqlText, commandType, func());
        }

        public T Scalar<T>(string sqlText, CommandType commandType = CommandType.Text, params IDbDataParameter[] parms) where T : struct
        {
            return (T)Scalar(sqlText, commandType, parms);
        }

        public T Scalar<T>(string sqlText, Func<IDbDataParameter[]> func, CommandType commandType = CommandType.Text) where T : struct
        {
            return Scalar<T>(sqlText, commandType, func());
        }
    }
}
