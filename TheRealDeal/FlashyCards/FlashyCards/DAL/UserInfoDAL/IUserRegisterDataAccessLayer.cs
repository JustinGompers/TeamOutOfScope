using FlashyCards.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashyCards.DAL
{
    interface IUserRegisterDataAccessLayer 
    {
        void createUser(RegisterUserModel newUser);
        UserModel getUserInfo(string userName, string Password);
    }
}
