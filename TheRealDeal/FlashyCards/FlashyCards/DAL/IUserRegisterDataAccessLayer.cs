using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashyCards.DAL
{
    interface IUserRegisterDataAccessLayer<T>
    {
        void createUser(T t);
        T getUserInfo(string userName, string Password);
    }
}
