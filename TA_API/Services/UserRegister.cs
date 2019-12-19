using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using TA_API.EntityModels;
using TA_API.Interface;
using TA_API.IRepositoryService;
using TA_API.UtilityClass;
using TA_API.ViewModel;

namespace TA_API.Services
{
    public class UserRegister : IUserRegister
    {

        private IGenericRepository<Users> repository = null;
        public UserRegister(IGenericRepository<Users> repository)
        {
            this.repository = repository;
        }
        public Users CreateUser(UsersModel model)
        {
            Users users = new Users();
            try
            {
                Users userslist = repository.FindByCondition(x => x.EmailId == model.EmailId).FirstOrDefault();
                if (userslist!=null)
                {
                    throw new HttpException((int)HttpStatusCode.NotFound, "EmailId Already exist,Please Try Again");
                }
                
                users.UserName = model.UserName;
                users.EmailId = model.EmailId;
                users.Password = EncryptionHelper.Encrypt(model.Password);
                users.IsActive = true;
                users.MobileNo = model.MobileNo;
                users.CreateDate= DateTime.Now.ToString();
                users.LastModifiedDate = model.LastModifiedDate;
                users.ProfileImg = model.ProfileImg;
                users.RoleId = model.RoleId;
                repository.Insert(users);
                repository.Save();

            }
            catch (HttpException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return users;
        }
    }
}
