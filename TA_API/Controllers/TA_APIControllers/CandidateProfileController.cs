using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TA_API.EntityModels;
using TA_API.Interface;
using TA_API.ViewModel;

namespace TA_API.Controllers.TA_APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateProfileController : ControllerBase
    {

        private readonly ICandidateProfile _repository;
        public CandidateProfileController(ICandidateProfile _repository)
        {
            this._repository = _repository;
        }


        [HttpPost]
        [Consumes("multipart/form-data")]
        public IActionResult Post([FromForm] CandidateProfileModel candidateProfile)
        {
            try
            {
                CandidateProfile Profile = _repository.ProfileSave(candidateProfile);
                return Ok(new { Status = StatusCodes.Status200OK, Message = "success", Profile });
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