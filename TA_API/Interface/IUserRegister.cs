using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TA_API.EntityModels;
using TA_API.ViewModel;

namespace TA_API.Interface
{
    public interface IUserRegister
    {
        Users CreateUser(UsersModel model);

        Users LoginUser(LoginModel loginModel);

    }
}
