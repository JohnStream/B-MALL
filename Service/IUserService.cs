using System;
using B_MALL.Common;
using B_MALL.Core.Models;
namespace B_MALL.Service
{
    public interface IUserService
    {
        //登录接口
        ServerResponse<User> login(String username, String password);
    }
}