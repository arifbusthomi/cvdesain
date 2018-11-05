using cvdesain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

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

        [ResponseType(typeof(Tbl_User))]
        [HttpGet]
        public List<Tbl_User> GetUsersByUsername(Tbl_User users)
        {
            var user = from cust in  
                                       where cust.City == "London"
                                       select cust;

            List<Tbl_User> users = null;
            try
            {
                users = dbContext.Tbl_User.;
            }
            catch (Exception e)
            {
                users = null;
            }
            return users;
        }
    }
}
