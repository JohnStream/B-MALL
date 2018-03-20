using System;
using B_MALL.Common;
using B_MALL.Core.Models;
using B_MALL.EntityFramework;
using System.Linq;
using B_MALL.Util;
namespace B_MALL.Services
{
    public class AccountService : IAccountService
    {
        private  IUserService _userservice;
  
        public AccountService(IUserService userservice){
            _userservice =  userservice;
        }
        public ServerResponse<User> login(String username, String password)
        {
            int resultCount = _userservice.checkUsername(username);
            if (resultCount == 0)
            {
                return ServerResponse<User>.createByErrorMessage("用户名不存在");
            }
            String md5Password = MD5Util.GetMD5(password);
            User user = _userservice.selectLogin(username, md5Password);
            if (user == null)
            {
                return ServerResponse<User>.createByErrorMessage("密码错误");
            }
            return ServerResponse<User>.createBySuccess("登录成功",user);
        }
    }
}