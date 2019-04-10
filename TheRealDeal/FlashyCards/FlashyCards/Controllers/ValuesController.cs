using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlashyCards.DAL;
using FlashyCards.Model;
using Microsoft.AspNetCore.Mvc;

namespace FlashyCards.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private UserRegisterDataAccessLayer dal;
        public ValuesController(UserRegisterDataAccessLayer dataAccessLayer)
        {
            dal = dataAccessLayer;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        ////GET api/values
        //[HttpGet("{username:string}/{password:string}", Name = "GetUserInfo")]
        //public ActionResult<UserModel> GetUserInfo(string username, string password)
        //{
        //    UserModel user = dal.getUserInfo(username, password);
        //    if (user != null)
        //    {
        //        return user;
        //    }
        //    return NotFound();
        //}

        // POST api/values
        [HttpPost]
        public ActionResult RegisterUser([FromForm] UserModel newUser)
        {
            dal.createUser(newUser);

            return CreatedAtRoute("GetUserInfo", new { username = newUser.userName, password = newUser.password }, newUser);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
