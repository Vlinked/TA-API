using Microsoft.AspNetCore.Http;
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
                if (userslist != null)
                {
                    throw new HttpException((int)HttpStatusCode.NotFound, "EmailId Already exist,Please Try Again");
                }
                users.FirstName = model.FirstName;
                users.LastName = model.LastName;
                users.UserName = model.UserName;
                users.EmailId = model.EmailId;
                users.Password = EncryptionHelper.Encrypt(model.Password);
                users.IsActive = true;
                users.MobileNo = model.MobileNo;
                users.CreateDate = DateTime.Now.ToString();
                users.LastModifiedDate = model.LastModifiedDate;
                users.ProfileImg = model.ProfileImg;
                users.RoleId = (model.RoleId == 0) ? 4 : model.RoleId;
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

        public Users LoginUser(LoginModel loginModel)
        {

            try
            {
                var userslist = new Users();
                if (loginModel.UserNameorEmail.Contains("@"))
                {
                    userslist = repository.FindByCondition(x => x.EmailId == loginModel.UserNameorEmail && x.Password == EncryptionHelper.Encrypt(loginModel.Password) && x.IsActive == true).FirstOrDefault();
                }
                else
                {
                    userslist = repository.FindByCondition(x => x.UserName == loginModel.UserNameorEmail && x.Password == EncryptionHelper.Encrypt(loginModel.Password) && x.IsActive == true).FirstOrDefault();
                }
                if (userslist == null)
                {
                    throw new HttpException((int)HttpStatusCode.NotFound, " Login Failed,Please Try Again");
                }

                return userslist;
            }
            catch (HttpException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Users UpdateUser(updatemodel model)
        {
            string ResponesUrl = string.Empty;
            try
            {
                Users userslist = repository.FindByCondition(x => x.Userid == model.Userid).FirstOrDefault();
                if (userslist == null)
                {
                    throw new HttpException((int)HttpStatusCode.NotFound, "Userid Not Found,Please Try Again");
                }
                if (model.FileExist)
                {
                    using (var fileStream = model.ImageUpload.OpenReadStream())
                    {

                        byte[] fileData = new byte[model.ImageUpload.Length];
                        string mimeType = model.ImageUpload.ContentType;
                        string strContainerName = "imagecontainer";
                        BlobStorageService objBlobService = new BlobStorageService();
                        ResponesUrl = objBlobService.UploadFileToBlob(model.ImageUpload.FileName, fileData, mimeType, strContainerName);
                    }
                    userslist.ProfileImg = ResponesUrl;
                    userslist.LastModifiedDate = DateTime.Now.ToString();
                    repository.Update(userslist);
                    repository.Save();
                }

                return userslist;
            }
            catch (HttpException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
