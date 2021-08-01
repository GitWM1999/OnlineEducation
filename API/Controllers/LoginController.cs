using Education.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Education.Service;

namespace Education.API.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private IUserService _user;
        private JWTTokenOptions _tokenOptions;
        
        public LoginController(IUserService user, JWTTokenOptions tokenOptions)
        {
            _user = user;
            _tokenOptions = tokenOptions;
        }

        

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string username,string pwd)
        {
            string token = "";

            int i = _user.Login(username, pwd);

            int userId = _user.GetUserId(username, pwd);
            if (i == 1)
            {
                TokenResult JwtToken = new TokenResult();
                JwtToken = new JwtTokenHelper().AuthorizeToken(username, _tokenOptions);
                token = JwtToken.Access_token;
            }
            
            return Ok(new {i,token,userId});
        }


        [HttpGet]
        [Route("GetUserInfo")]
        public IActionResult GetUserInfo()
        {

            var list = _user.GetUserInfo();
            return Ok(list);
            
        }


    }
}
