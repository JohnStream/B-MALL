using System;
using B_MALL.Common;
using B_MALL.Core.Models;
using B_MALL.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace B_MALL.Services
{
    public class UserService : IUserService
    {
        private UserContext _context;
        public UserService(UserContext context)
        {
            _context = context;
        }
        // 检查用户名是否存在
        public int checkUsername(string name)
        {
            var count = _context.Users.Where(i => i.UserName == name).Count();
            return count;
        }
        // 检查账号密码是否正确
        public User selectLogin(string name, string password)
        {
            User user = (from c in _context.Users where c.UserName == name && c.PassWord == password select c).SingleOrDefault();
            return user;
        }
    }
}