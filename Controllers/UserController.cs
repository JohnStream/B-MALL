using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using B_MALL.Core.Models;
using B_MALL.EntityFramework;
using B_MALL.Common;
using B_MALL.Services;

namespace B_MALL.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IAccountService _accountService;
        public UserController(IAccountService accountService){
            
            _accountService = accountService;
        }
        [HttpGet]
        public string login(){
            return "1";
        }
        [HttpPost]
        public string login([FromBody]String username, String password){
        // ServerResponse<User> response = _accountService.login(username,password);
        return "123";
    }

    }


}