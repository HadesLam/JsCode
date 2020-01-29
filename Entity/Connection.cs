using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Entity
{
    public class Connection
    {
        static string _connectionString = ConfigurationManager.ConnectionStrings["JsDBs"].ConnectionString;

        public static string ConnectionString { get { return _connectionString; } }
    }
}