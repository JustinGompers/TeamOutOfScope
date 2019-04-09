using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml.Linq;
using

namespace Capstone.Web.DAL
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashyCardsController : ControllerBase

    {
        private UserRegisterDataAccessLayer dal;
        public FlashyCardsController(UserRegisterDataAccessLayer dataAccessLayer)
        {
            dal = dataAccessLayer;
        }
        
        // GET api/<controller>
        [HttpGet("{username}", "{password}" Name="GetUserInfo")]
        public IHttpActionResult<UserModel> GetUserInfo(string username, string password)
        {

        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}