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

        //Login User Get API
        [HttpGet("{username}/{password}", Name = "GetUserInfo")]
        public ActionResult<UserModel> GetUserInfo(string username, string password)
        {
            UserModel user = dal.getUserInfo(username, password);
            if (user != null)
            {
                return user;
            }
            return NotFound();
        }

        // Register User Post API
        [HttpPost]
        public ActionResult RegisterUser([FromBody] RegisterUserModel newUser)
        {
            dal.createUser(newUser);

            return CreatedAtRoute("GetUserInfo", new { username = newUser.userName, password = newUser.password }, newUser);
        }
    }
}
