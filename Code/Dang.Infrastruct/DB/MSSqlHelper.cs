using System;
using System.Collections.Generic;
using System.Text;

namespace Dang.Infrastruct.DB
{
    public class MSSqlHelper:SqlHelper
    {
        public MSSqlHelper(string connectionString) : base(new Microsoft..SqlClient.SqlConnection(connectionString)) { }
    }
}
