using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using StoreApi.DataTransferObject;

namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {   
        private readonly IUserBL _userBL;
        private readonly ICustomerBL _customerBL;

        public AuthenticationController(IUserBL p_userBL, ICustomerBL p_customerBL)
        {
            _userBL = p_userBL;
            _customerBL = p_customerBL;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterForm p_registerForm)
        {
            try
            {
                _userBL.Register(new User()
                {
                    UserName = p_registerForm.UserName,
                    Password = p_registerForm.Password
                });
                _customerBL.AddCustomer(new Customer(){
                    Name = p_registerForm.Name,
                    Address = p_registerForm.Address,
                    Email = p_registerForm.Email,
                    ContactNo = p_registerForm.ContactNo,
                    UserName = p_registerForm.UserName
                });

                return Created("Register successful", p_registerForm);
            }
            catch (System.Exception)
            {
                
                return BadRequest(new {results = "user name is exsist"});
            }
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginForm p_loginForm)
        {
            try
            {
              if(_userBL.Login(new User()
              {
                  UserName = p_loginForm.UserName,
                  Password = p_loginForm.Password
              }))
              {
                    return Ok("Login Successful");            
              }
              return BadRequest("Login failed"); 
            }
            catch (System.Exception e)
            {
              
                return StatusCode(500, e);
            }
        }

    }
}
