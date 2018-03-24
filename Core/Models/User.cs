using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace B_MALL.Core.Models
{
    // user信息表
    public class User
    {
        [Key,Required]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PassWord { get; set; }
        [EmailAddress,Required]
        public string Email { get; set; }
        [Phone]
        public string Phone{get;set;}
        public string Question{get;set;}
        public string Answer{get;set;}
        // 区分门户及管理员
        // public int Role{get;set;}
        public DateTime Create_Time { get; set; }
        public DateTime Update_Time { get; set; }
    }
}