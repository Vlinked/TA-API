using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using TA_API.EntityModels;
using TA_API.Interface;
using TA_API.IRepositoryService;

namespace TA_API.Services
{
    public class NewJobService : INewJob
    {
        private IGenericRepository<NewJob> repository = null;
        public NewJobService(IGenericRepository<NewJob> repository)
        {
            this.repository = repository;
        }
        public NewJob CreateJobs(NewJob newJobmodel)
        {
            try
            {

                NewJob NewJoblist = repository.FindByCondition(x => x.IsCompleted == false && x.DesgnId== newJobmodel.DesgnId).FirstOrDefault();
                if (NewJoblist != null)
                {
                    throw new HttpException((int)HttpStatusCode.NotFound, "Positions are not completed for this Designation ,Please Try Again");
                }
                newJobmodel.CreatedDate = DateTime.Now.ToString();
                newJobmodel.IsCompleted = false;
                repository.Insert(newJobmodel);
                repository.Save();
                return newJobmodel;
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

        public List<NewJob> GetJobs()
        {
            try
            {
                List <NewJob> jobs = repository.FindBy(x=>x.IsCompleted==false).ToList();
                return jobs;
            }
            catch (Exception ex)
            {
               throw ex;
            }
        }

        public NewJob UpdateJob(NewJob newJobmodel)
        {

            try
            {

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
