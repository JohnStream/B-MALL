using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using B_MALL.Core.Models;
using B_MALL.EntityFramework;
using B_MALL.Common;
using B_MALL.Service;

namespace B_MALL.Controllers
{
    [Route("api/[controller]")]
    public class UserController: Controller
    {
    
        private IUserService iUserService;

    }
        
}