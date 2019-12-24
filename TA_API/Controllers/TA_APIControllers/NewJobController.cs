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
    public class NewJobController : ControllerBase
    {

        private readonly INewJob _repository;
        public NewJobController(INewJob _repository)
        {
            this._repository = _repository;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<NewJob> jobs = _repository.GetJobs();
                return Ok(new { Status = StatusCodes.Status200OK, Message = "success" , jobs });
            }
            catch (Exception ex)
            {
                return new ObjectResult(new { Status = StatusCodes.Status500InternalServerError, Message = ex.Message });
            }
           
        }



        [HttpPost]
        public IActionResult Post(NewJob newJobmodel)
        {
            try
            {
                NewJob job = _repository.CreateJobs(newJobmodel);
                return Ok(new { Status = StatusCodes.Status200OK, Message = "success", job });
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


        [HttpPut]
        public IActionResult Put()
        {
            try
            {
                return Ok(new { Status = StatusCodes.Status200OK, Message = "success" });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}