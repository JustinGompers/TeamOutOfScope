using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlashyCards.DAL;
using FlashyCards.DAL.FlashCardDeckDAL;
using FlashyCards.Model;
using FlashyCards.Model.FlashCardDeckModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FlashyCards.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private UserRegisterDataAccessLayer dal;
        public ValuesController(UserRegisterDataAccessLayer dataAccessLayer)
        {
            dal = dataAccessLayer;
        }

        //Login User Get API (url = api/values/username/password)
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

        // Register User Post API (url = api/values)
        [HttpPost]
        public ActionResult RegisterUser([FromForm] RegisterUserModel newUser)
        {
            dal.createUser(newUser);

            return CreatedAtRoute("GetUserInfo", new { username = newUser.userName, password = newUser.password }, newUser);
        }
    }
}
