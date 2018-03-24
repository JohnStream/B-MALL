using System;
using System.Linq;
using B_MALL.Core.Models;
namespace B_MALL.EntityFramework
{
    public class DbInitializer
    {
        public static void Initialize(UserContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }
            #region 添加用户种子信息

            var users = new[]
            {
                new User{
                    Id = 1,
                    UserName = "pimliulu",
                    PassWord = "123456",
                    Email ="1021283712@qq.com",
                    Phone = "18588450754",
                    Question = "我的名字是?",
                    Answer = "pimliulu",
                    Create_Time = DateTime.Parse("2018-03-19"),
                    Update_Time = DateTime.Parse("2018-03-19")
                    }
            };
            foreach (var s in users)
                context.Users.Add(s);
            context.SaveChanges();
            #endregion
        }
    }
}