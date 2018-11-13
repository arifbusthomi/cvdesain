using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace csdesain.DAL
{
    class DBTransaction
    {
        private static string SqlConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ToString();

        public static DataSet DbToDataSet(string query, object param)
        {
            return ExecuteDataSet(query, ObjectToSqlParameter(param));
        }

        private static DataSet ExecuteDataSet(string query, params SqlParameter[] arrParam)
        {
            DataSet ds = new DataSet();
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnectionString))
            {
                if (sqlConnection.State != ConnectionState.Open)
                    sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = query;
                    cmd.CommandTimeout = 0;

                    if (arrParam != null)
                        foreach (SqlParameter param in arrParam)
                            cmd.Parameters.Add(param);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(ds);
                }
            }
            return ds;
        }

        public static SqlParameter[] ObjectToSqlParameter(Object dataObject)
        {
            Type type = dataObject.GetType();
            PropertyInfo[] props = type.GetProperties();
            List<SqlParameter> paramList = new List<SqlParameter>();

            for (int i = 0; i < props.Length; i++)
            {
                if (props[i].PropertyType.IsValueType || props[i].PropertyType.Name == "String" || props[i].PropertyType.Name == "Object")
                {
                    object fieldValue = type.InvokeMember(props[i].Name, BindingFlags.GetProperty, null, dataObject, null);
                    SqlParameter sqlParameter = new SqlParameter("@" + props[i].Name, fieldValue);
                    paramList.Add(sqlParameter);
                }
            }
            return paramList.ToArray();
        }
    }
}
