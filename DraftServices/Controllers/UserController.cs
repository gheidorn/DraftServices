using DraftServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace DraftServices.Controllers
{
    public class UserController : ApiController
    {
        // /api/user/1/
        public User Get()
        {
            return new User { Id = 1, Username = "Greg" };
        }

        // /api/user
        public List<User> GetAll()
        {
            List<User> users = new List<User> {
                new User { Id = 1, Username = "Greg" }, 
                new User { Id = 2, Username = "Kristin" }
            };

            return users;
        }

    }
}
