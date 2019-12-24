using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using TA_API.EntityModels;
using TA_API.Interface;
using TA_API.IRepositoryService;
using TA_API.ViewModel;

namespace TA_API.RepositoryService
{
    public class JobAppliedService : IJobApplied
    {
        private IGenericRepository<JobApplied> repository = null;
        public JobAppliedService(IGenericRepository<JobApplied> repository)
        {
            this.repository = repository;
        }
        public JobApplied CreateJobApplied(JobApplied jobAppliedmodel)
        {
            try
            {
                jobAppliedmodel.IsAccepted = true;
                jobAppliedmodel.CreateDate = DateTime.Now.ToString();
                repository.Insert(jobAppliedmodel);
                repository.Save();
                return jobAppliedmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JobApplied RejectJobApplied(RejectJobmodel jobAppliedmodel)
        {
            try
            {
                JobApplied jobs = repository.FindBy(x => x.JobApplId == jobAppliedmodel.JobApplId && x.IsAccepted == true).FirstOrDefault();

                if (jobs == null)
                {
                    throw new HttpException((int)HttpStatusCode.NotFound, "JobId not Found ,Please Try Again");
                }
                jobs.IsAccepted = jobAppliedmodel.IsAccepted;
                jobs.LastModifiedBy = jobAppliedmodel.LastModifiedBy;
                jobs.LastModifiedDate = DateTime.Now.ToString();
                repository.Update(jobs);
                repository.Save();
                return jobs;

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
