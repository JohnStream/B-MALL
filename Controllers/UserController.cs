using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using B_MALL.Core.Models;
using B_MALL.EntityFramework;
using B_MALL.Common;
using B_MALL.Services;
using B_MALL.ViewModel;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace B_MALL.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IAccountService _accountService;
        public UserController(IAccountService accountService){
            
            _accountService = accountService;
        }
        [HttpPost]
        public ServerResponse<User>  login([FromBody]UserViewModel user){
        ServerResponse<User> response =  _accountService.login(user.username,user.password);
        return response;        
    }
    }


}