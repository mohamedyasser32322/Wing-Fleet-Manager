using AutoMapper;
using Wing_Fleet_Manager.Models;
using Wing_Fleet_Manager.Dtos;
using Wing_Fleet_Manager.Dtos.User;
using Wing_Fleet_Manager.Helpers;
using Microsoft.Identity.Client.Extensibility;

namespace Wing_Fleet_Manager.Data
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<User, UserReadDto>()
                .ForMember(dest => dest.RoleName, options => options.MapFrom(src => src.Role.Name));
            CreateMap<UserCreateDto, User>()
                .ForMember(dest => dest.HashPassword, opt => opt.MapFrom(src => PasswordHelper.PasswordHasher(src.Password)));
            CreateMap<UserUpdateDto, User>()
                .ForMember(dest => dest.HashPassword, opt => opt.Ignore())
                .ForMember(dest => dest.FullName, opt => opt.Condition(src => !string.IsNullOrEmpty(src.FullName)))
                .ForMember(dest => dest.NickName, opt => opt.Condition(src => !string.IsNullOrEmpty(src.NickName)))
                .ForMember(dest => dest.Phone, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Phone)))
                .ForMember(dest => dest.ImageUrl, opt => opt.Condition(src => !string.IsNullOrEmpty(src.ImageUrl)));
        }
    }
}
