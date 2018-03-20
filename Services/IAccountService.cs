using System;
using B_MALL.Common;
using B_MALL.Core.Models;
namespace B_MALL.Services
{
    public interface IAccountService
    {
        ServerResponse<User> login(String username, String password);
    }
}