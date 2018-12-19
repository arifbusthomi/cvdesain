using cvdesain.BL;
using cvdesain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Security;

namespace cvdesain.Api
{
    [RoutePrefix("/api/User")]
    public class UserController : ApiController
    {
        cvdesainEntities dbContext = null;

        public UserController()
        {
            dbContext = new cvdesainEntities();
        }

        [ResponseType(typeof(Tbl_User))]
        [HttpPost]
        public HttpResponseMessage SaveUsers(Tbl_User users)
        {
            int result = 0;
            try
            {
                dbContext.Tbl_User.Add(users);
                dbContext.SaveChanges();
                result = 1;
            }
            catch (Exception e)
            {
                result = 0;
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [ResponseType(typeof(Tbl_User))]
        [HttpGet]
        public List<Tbl_User> GetUsers()
        {
            List<Tbl_User> users = null;
            try
            {
                users = dbContext.Tbl_User.ToList();
            }
            catch (Exception e)
            {
                users = null;
            }
            return users;
        }
        
        [HttpGet]
        public string GetUsersByUsername(mUser users)
        {
            /*
            BL_Users BL_users = new BL_Users();
            DataTable dt = new DataTable();
            dt = BL_users.GetUserByUsername(users.username, users.password);
            List<DataRow> user = new List<DataRow>();
            try
            {
                user = dt.AsEnumerable().ToList();
            }
            catch (Exception)
            {
                user = null;
            }
            */

            cvdesainEntities cv = new cvdesainEntities();
            var user = dbContext.Tbl_User.Where(x => x.Username == users.username).SingleOrDefault();
            return user.ToString();
        }
    }
}
