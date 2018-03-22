using System;
using B_MALL.Common;
using B_MALL.Core.Models;
using B_MALL.EntityFramework;
using System.Linq;
using B_MALL.Util;
using B_MALL.Dtos;
using AutoMapper;
namespace B_MALL.Services
{
    public class AccountService : IAccountService
    {
        private IUserService _userservice;
        // private readonly IMapper _mapper;

        public AccountService(IUserService userservice)
        {
            _userservice = userservice;
        }
        // public AccountService(IMapper mapper)
        // {
        //     _mapper = mapper;
        // }
        public ServerResponse<UserDto> login(String username, String password)
        {

            int resultCount = _userservice.checkUsername(username);
            if (resultCount == 0)
            {
                return ServerResponse<UserDto>.createByErrorMessage("用户名不存在");
            }
            // String md5Password = MD5Util.GetMD5(password);
            User user = _userservice.selectLogin(username, password);
            var userdto = AutoMapper.Mapper.Map<UserDto>(user);

            if (user == null)
            {
                return ServerResponse<UserDto>.createByErrorMessage("密码错误");
            }
            return ServerResponse<UserDto>.createBySuccess("登录成功", userdto);
        }
    }
}