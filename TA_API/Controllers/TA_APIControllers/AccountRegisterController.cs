using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class AccountRegisterController : ControllerBase
    {
        private readonly IUserRegister _repository;
        public AccountRegisterController(IUserRegister _repository)
        {
            this._repository = _repository;
        }


        [HttpPost]
        public IActionResult Post(UsersModel usersmodel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                Users users = _repository.CreateUser(usersmodel);
                return Ok(new { Status = StatusCodes.Status200OK, Message = "success", users });
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
        [Consumes("multipart/form-data")]
        public IActionResult put([FromForm] updatemodel updatemodel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                Users users = _repository.UpdateUser(updatemodel);
                return Ok(new { Status = StatusCodes.Status200OK, Message = "success", users });
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