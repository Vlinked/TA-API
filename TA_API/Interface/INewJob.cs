using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TA_API.EntityModels;

namespace TA_API.Interface
{
    public interface INewJob
    {
        NewJob CreateJobs(NewJob newJobmodel);
        List<NewJob> GetJobs();
        NewJob UpdateJob(NewJob newJobmodel);

    }
}
