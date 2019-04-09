using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashyCardController : ControllerBase
    {
        private UserRegisterDataAccessLayer dal;
        public FlashyCardController(UserRegisterDataAccessLayer dataAccessLayer)
        {
            dal = dataAccessLayer;
        }

        // POST api/values
        [HttpPost]
        public ActionResult RegisterUser([FromBody] UserModel newUser)
        {
            dal.createUser(newUser);

            return CreatedAtRoute("GetUserInfo", new {id = newUser.userId}, newUser);
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
