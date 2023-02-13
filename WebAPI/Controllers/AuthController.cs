using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        private IUserOperationClaimsService _userOperationClaimsService;

        public AuthController(IAuthService authService,IUserOperationClaimsService userOperationClaimsService)
        {
            _userOperationClaimsService = userOperationClaimsService;
            _authService = authService;
        }

        [HttpGet("GetUserById")]
        public ActionResult GetById(int id)
        {
            var userToLogin = _authService.GetById(id);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            return Ok(userToLogin);
        }

        [HttpGet(template: "getusers")]
        public IActionResult GetAll()
        {

            var result = _authService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("delete")]
        public ActionResult Delete(int Id)
        {

            var result = _authService.Delete(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }





        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);




        }

        [HttpPost("update")]
        public ActionResult Update(UserForUpdateDto userForUpdateDto)
        {

            var result = _authService.Update(userForUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("operationupdate")]
        public ActionResult OperationUpdate(UserOperationClaim userOperationClaims)
        {

            var result = _userOperationClaimsService.Update(userOperationClaims);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("GetByAuthId")]
        public IActionResult GetByAuthId(int id)
        {
            var userToLogin = _userOperationClaimsService.GetByAuthId(id);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            return Ok(userToLogin);
        }







    }


 
}
 


