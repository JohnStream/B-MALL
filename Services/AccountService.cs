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
            String md5Password = MD5Util.GetMD5(password);
            User user = _userservice.selectLogin(username, md5Password);
            var userdto = AutoMapper.Mapper.Map<UserDto>(user);

            if (user == null)
            {
                return ServerResponse<UserDto>.createByErrorMessage("密码错误");
            }
            return ServerResponse<UserDto>.createBySuccess("登录成功", userdto);

        }
        // 效验用户名
        public ServerResponse<String> checkValid(string str, string type)
        {
            if (ConstType.USERNAME.Equals(type))
            {
                int count = _userservice.checkUsername(str);
                if (count > 0)
                {
                    return ServerResponse<String>.createByErrorMessage("该用户名已经注册");
                }
            }
            else if (ConstType.EMAIL.Equals(type))
            {
                int count = _userservice.checkEmail(str);
                if (count > 0)
                {
                    return ServerResponse<String>.createByErrorMessage("该邮箱已经注册");
                }

            }
            else
            {
                return ServerResponse<String>.createByErrorMessage("参数错误");
            }
            return ServerResponse<String>.createBySuccessMessage("校验成功");

        }
        // 注册
        public ServerResponse<String> register (User user)
        {
            ServerResponse<String> validResponse = this.checkValid(user.UserName, ConstType.USERNAME);
            if (!validResponse.isSuccess())
            {
                return validResponse;
            }
            validResponse = this.checkValid(user.Email, ConstType.EMAIL);
            if (!validResponse.isSuccess())
            {
                return validResponse;
            }
            // TODO 管理员 用户
            user.PassWord = MD5Util.GetMD5(user.PassWord);
            user.Create_Time = DateTime.Now;
            int resultCount = _userservice.insert(user);
            if (resultCount == 0)
            {
                return ServerResponse<String>.createByErrorMessage("注册失败");
            }
            return ServerResponse<String>.createBySuccessMessage("注册成功");

        }
    }
}