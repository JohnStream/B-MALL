using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace B_MALL.Core.Models
{
    // user信息表
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone{get;set;}
        public string Question{get;set;}
        public string Answer{get;set;}
        public int Role{get;set;}
        public DateTime Create_Time { get; set; }
        public DateTime Update_Time { get; set; }
    }
}