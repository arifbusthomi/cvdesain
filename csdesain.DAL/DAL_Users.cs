using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csdesain.DAL
{
    public class DAL_Users
    {
        private DBManager dbManager;

        public DAL_Users()
        {
            dbManager = new DBManager();
        }

        public DataTable GetUserByUsername(string username, string password)
        {
            object param = new object();
            param = new { username = username, password = password };

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = DBTransaction.DbToDataSet(BasedEntities.c_stp_select_user_byusername, param);
            return dt = ds.Tables[0];
        }
    }
}
