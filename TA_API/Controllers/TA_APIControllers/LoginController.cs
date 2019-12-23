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
    public class LoginController : ControllerBase
    {

        private readonly IUserRegister _repository;
        public LoginController(IUserRegister _repository)
        {
            this._repository = _repository;
        }
        [HttpPost]
        public IActionResult Authorization(LoginModel loginModel)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Users users = _repository.LoginUser(loginModel);
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