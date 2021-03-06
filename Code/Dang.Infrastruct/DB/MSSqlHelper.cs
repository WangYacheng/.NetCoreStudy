using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dang.Infrastruct.DB
{
    public class MSSqlHelper:SqlHelper
    {
        public MSSqlHelper(string connectionString) : base(new Microsoft.Data.SqlClient.SqlConnection(connectionString)) { }
       
    }
}
