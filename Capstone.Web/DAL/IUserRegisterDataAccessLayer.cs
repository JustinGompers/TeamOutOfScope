using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    interface IUserRegisterDataAccessLayer<T>
    {
        void createUser(T t);
        T getUserInfo(string userName, string Password);

    }
}
