using System;
using B_MALL.Common;
using B_MALL.Core.Models;
using B_MALL.Dtos;
namespace B_MALL.Services
{
    public interface IAccountService
    {
        ServerResponse<UserDto> login(String username, String password);
    }
}