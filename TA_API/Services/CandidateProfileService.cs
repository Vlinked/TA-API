using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
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
    public class CandidateProfileService : ICandidateProfile
    {

        private IGenericRepository<CandidateProfile> repository = null;
        public CandidateProfileService(IGenericRepository<CandidateProfile> repository)
        {
            this.repository = repository;
        }
        public CandidateProfile ProfileSave(CandidateProfileModel Profilemodel)
        {
            string ResponesUrl = string.Empty;
            CandidateProfile profilemd = new CandidateProfile();
            try
            {
                CandidateProfile Profiles = repository.FindByCondition(x => x.EmailId == Profilemodel.EmailId && x.IsActive==true).FirstOrDefault();
                if (Profiles != null)
                {
                    throw new HttpException((int)HttpStatusCode.NotFound, "EmailId Already exist,Please Try Again");
                }
                if (Profilemodel.FileExist)
                {
                    using (var fileStream = Profilemodel.FileUpload.OpenReadStream())
                    {

                        byte[] fileData = new byte[Profilemodel.FileUpload.Length];
                        string mimeType = Profilemodel.FileUpload.ContentType;
                        string strContainerName = "fileconatiner";
                        BlobStorageService objBlobService = new BlobStorageService();
                        ResponesUrl =objBlobService.UploadFileToBlob(Profilemodel.FileUpload.FileName, fileData, mimeType, strContainerName);
                    }
                }
                profilemd.FirstName = Profilemodel.FirstName;
                profilemd.LastName = Profilemodel.LastName;
                profilemd.MobileNumber = Profilemodel.MobileNumber;
                profilemd.Skills = Profilemodel.Skills;
                profilemd.NoticePeriod = Profilemodel.NoticePeriod;
                profilemd.CreateDate = DateTime.Now.ToString();
                profilemd.CurrentCompany = Profilemodel.CurrentCompany;
                profilemd.CurrentCtc = Profilemodel.CurrentCtc;
                profilemd.Designation = Profilemodel.Designation;
                profilemd.DesiredLocation = Profilemodel.DesiredLocation;
                profilemd.EmailId = Profilemodel.EmailId;
                profilemd.ExpectedCtc = Profilemodel.ExpectedCtc;
                profilemd.Experience = Profilemodel.Experience;
                profilemd.Userid = Profilemodel.Userid;
                profilemd.IsActive = true;
                profilemd.Resumeattachment = ResponesUrl;
                repository.Insert(profilemd);
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

            return profilemd;
        }
    }
}
