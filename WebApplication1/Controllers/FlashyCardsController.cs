﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
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

        [HttpGet]
        public IEnumerable<string> Get()
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
        public ActionResult RegisterUser([FromBody] UserModel newUser)
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
