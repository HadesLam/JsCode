using System.Configuration;

namespace H.Entity
{
    public class Connection
    {
        static string _connectionString = ConfigurationManager.ConnectionStrings["JsDBs"].ConnectionString;

        public static string ConnectionString { get { return _connectionString; } }
    }
}