using csdesain.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvdesain.BL
{
    public class BL_Users
    {
        private DAL_Users DAL_Users;
        
        public BL_Users()
        {
            DAL_Users = new DAL_Users();
        }

        public DataTable GetUserByUsername(string username, string password)
        {
            return DAL_Users.GetUserByUsername(username, password);
        }
    }
}
