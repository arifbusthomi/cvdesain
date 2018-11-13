using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csdesain.DAL
{
    class DBManager
    {
        private SqlConnection TheConn;
        private const string CONNECTION_STRING_NAME = "DefaultConnectionString";

        public SqlConnection DBConnectionDefault
        {
            get
            {
                if(TheConn == null)
                {
                    TheConn = new SqlConnection(ConnectionStringDefault);
                    TheConn.Open();
                }
                return TheConn;
            }

        }

        public string ConnectionStringDefault
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[CONNECTION_STRING_NAME].ToString();
            }
        }

        public SqlConnection GetDBConnection(string ConnectionStringName)
        {
            if (string.IsNullOrEmpty(ConnectionStringName))
            {
                throw new Exception("Connection String Must Be Specified or defined");
            }
            else
            {
                ConnectionStringSettings Connstr = ConfigurationManager.ConnectionStrings[CONNECTION_STRING_NAME];
                if (Connstr == null)
                {
                    return null;
                }
                else
                {
                    return new SqlConnection(Connstr.ConnectionString);
                }
            }
        }
    }
}
