using AutoMapper;
using B_MALL.Core.Models;
using B_MALL.Dtos;
namespace B_MALL.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //此文件中添加所有的实体到实体间的映射
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}