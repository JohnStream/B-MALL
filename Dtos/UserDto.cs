using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace B_MALL.Dtos
{
    public class UserDto
    {
        public string UserName;
        [EmailAddress]
        public string email;
        [Phone]
        public string phone;
        // 显示到天
        [DataType(DataType.Date)]
        public DateTime createTime;

    }
}