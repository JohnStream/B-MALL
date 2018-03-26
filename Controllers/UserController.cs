using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using B_MALL.Core.Models;
using B_MALL.EntityFramework;
using B_MALL.Common;
using B_MALL.Services;
using B_MALL.Dtos;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using B_MALL.Util;
using Microsoft.AspNetCore.Http;

namespace B_MALL.Controllers
{
    public class UserController : Controller
    {
        private readonly IAccountService _accountService;
        public UserController(IAccountService accountService)
        {

            _accountService = accountService;
        }
        [HttpPost, Route("/user/login")]
        public ServerResponse<UserDto> login([FromBody]User user)
        {
            // 登录
            // TODO 非空检查
            ServerResponse<UserDto> response = _accountService.login(user.UserName, user.PassWord);
            if (response.isSuccess())
            {
                HttpContext.Session.Set("CurrentUser", ByteConvertHelper.Object2Bytes(response.getData()));
            }

            return response;

        }
        [HttpPost, Route("/user/register")]
        // 注册
        public ServerResponse<String> register([FromBody]User user)
        {
            // 登录
            // TODO 非空检查
            ServerResponse<String> response = _accountService.register(user);
            return response;
        }
        // 获取用户登录状态
        [HttpGet,Route("/user/getUserInfo")]
        public ServerResponse<UserDto> getUserInfo()
        {
            UserDto user = (UserDto)ByteConvertHelper.Bytes2Object(HttpContext.Session.Get("CurrentUser"));
            if (user != null)
            {
                return ServerResponse<UserDto>.createBySuccess(user);
            }
            return ServerResponse<UserDto>.createByErrorCodeMessage(10,"用户未登录,无法获取当前用户的信息");
        }

        // TODO 忘记密码
        // TODO 重置密码
        // TODO 获取用户信息

    }
}