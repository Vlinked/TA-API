using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TA_API.EntityModels;
using TA_API.Interface;
using TA_API.IRepositoryService;

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
    }
}
