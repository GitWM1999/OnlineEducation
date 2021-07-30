using Education.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace Education.API.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private ICRUD _crud;
        private JWTTokenOptions _tokenOptions;
        public LoginController(ICRUD crud, JWTTokenOptions tokenOptions)
        {
            _crud = crud;
            _tokenOptions = tokenOptions;
        }
        
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string username,string pwd)
        {
            string token = "";
            object j = _crud.ExecuteScalar($"select count(*) from UserInfo where UserAccount='{username}' and UserPass='{pwd}'");
            int i = Convert.ToInt32(j);
            if (i == 1)
            {
                TokenResult JwtToken = new TokenResult();
                JwtToken = new JwtTokenHelper().AuthorizeToken(username, _tokenOptions);
                token = JwtToken.Access_token;
            }
            
            return Ok(new {i,token });
        }
    }
}
