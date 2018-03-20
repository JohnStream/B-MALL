using System;
using System.Collections.Generic;
using System.Linq;
using B_MALL.Core.Models;
using B_MALL.Common;
namespace B_MALL.Services
{
    public interface IUserService
    {
         int  checkUsername(string username);
         User selectLogin(string username,string password);
    }
}