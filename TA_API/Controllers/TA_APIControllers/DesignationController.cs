using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TA_API.EntityModels;
using TA_API.Interface;

namespace TA_API.Controllers.TA_APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {

        private readonly ICandidateProfile _repository;
        public DesignationController(ICandidateProfile _repository)
        {
            this._repository = _repository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List <Designation> Listdesignations= _repository.GetDesignation();
                return Ok(new { Status = StatusCodes.Status200OK, Message = "success", Listdesignations });
            }
            catch (Exception ex)
            {
                return new ObjectResult(new { Status = StatusCodes.Status500InternalServerError, Message = ex.Message });
            }
        }
    }
}