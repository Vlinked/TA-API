using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TA_API.EntityModels;
using TA_API.Interface;

namespace TA_API.Controllers.TA_APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobAppliedController : ControllerBase
    {

        private readonly IJobApplied _repository;
        public JobAppliedController(IJobApplied _repository)
        {
            this._repository = _repository;
        }
        [HttpPost]
        public IActionResult Post(JobApplied jobAppliedmodel)
        {
            try
            {
                JobApplied jobApplied = _repository.CreateJobApplied(jobAppliedmodel);
                return Ok(new { Status = StatusCodes.Status200OK, Message = "success", jobApplied });
            }
            catch (Exception ex)
            {
                return new ObjectResult(new { Status = StatusCodes.Status500InternalServerError, Message = ex.Message });
            }
        }


        [HttpPut]
        public IActionResult Put(JobApplied jobAppliedmodel)
        {
            try
            {
                JobApplied Rejectedjob = _repository.RejectJobApplied(jobAppliedmodel);
                return Ok(new { Status = StatusCodes.Status200OK, Message = "success", Rejectedjob });
            }
            catch (HttpException ex)
            {
                return new ObjectResult(new { Status = ex.StatusCode, Message = ex.StatusDescription });
            }
            catch (Exception ex)
            {
                return new ObjectResult(new { Status = StatusCodes.Status500InternalServerError, Message = ex.Message });
            }
        }
    }
}