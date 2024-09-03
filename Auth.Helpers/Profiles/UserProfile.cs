using Auth.Entities.Users;
using AutoMapper;

namespace Auth.Helpers.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //маппинг из базы данных в объект
            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.Id,
                    src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Login,
                    src => src.MapFrom(x => x.Login))
                .ForMember(dest => dest.Password,
                    src => src.MapFrom(x => x.Password))
                .ForMember(dest => dest.Name,
                    src => src.MapFrom(x => x.Name))
                .ForMember(dest => dest.Surname,
                    src => src.MapFrom(x => x.Surname))
                .ForMember(dest => dest.Email,
                    src => src.MapFrom(x => x.Email))
                .ForMember(dest => dest.Phone,
                    src => src.MapFrom(x => x.Phone));

            //маппинг из объекта в сервис
            CreateMap<User, UserResponse>()
                .ForMember(dest => dest.Id,
                    src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Login,
                    src => src.MapFrom(x => x.Login))
                .ForMember(dest => dest.Password,
                    src => src.MapFrom(x => x.Password))
                .ForMember(dest => dest.Name,
                    src => src.MapFrom(x => x.Name))
                .ForMember(dest => dest.Surname,
                    src => src.MapFrom(x => x.Surname))
                .ForMember(dest => dest.Email,
                    src => src.MapFrom(x => x.Email))
                .ForMember(dest => dest.Phone,
                    src => src.MapFrom(x => x.Phone));

            //маппинг из DTO в сервис
            CreateMap<UserDTO, UserResponse>()
                .ForMember(dest => dest.Id,
                    src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Login,
                    src => src.MapFrom(x => x.Login))
                .ForMember(dest => dest.Password,
                    src => src.MapFrom(x => x.Password))
                .ForMember(dest => dest.Name,
                    src => src.MapFrom(x => x.Name))
                .ForMember(dest => dest.Surname,
                    src => src.MapFrom(x => x.Surname))
                .ForMember(dest => dest.Email,
                    src => src.MapFrom(x => x.Email))
                .ForMember(dest => dest.Phone,
                    src => src.MapFrom(x => x.Phone));

            //из Request в объект
            CreateMap<UserRequest, User>()
                .ForMember(dest => dest.Login,
                    src => src.MapFrom(x => x.Login))
                .ForMember(dest => dest.Password,
                    src => src.MapFrom(x => x.Password))
                .ForMember(dest => dest.Name,
                    src => src.MapFrom(x => x.Name))
                .ForMember(dest => dest.Surname,
                    src => src.MapFrom(x => x.Surname))
                .ForMember(dest => dest.Email,
                    src => src.MapFrom(x => x.Email))
                .ForMember(dest => dest.Phone,
                    src => src.MapFrom(x => x.Phone));

            //из объекта в DTO
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Id,
                    src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Login,
                    src => src.MapFrom(x => x.Login))
                .ForMember(dest => dest.Password,
                    src => src.MapFrom(x => x.Password))
                .ForMember(dest => dest.Name,
                    src => src.MapFrom(x => x.Name))
                .ForMember(dest => dest.Surname,
                    src => src.MapFrom(x => x.Surname))
                .ForMember(dest => dest.Email,
                    src => src.MapFrom(x => x.Email))
                .ForMember(dest => dest.Phone,
                    src => src.MapFrom(x => x.Phone));

            CreateMap<UserRoleRequest, UserRoleDTO>()
                    .ForMember(dest => dest.Id,
                        src => src.MapFrom(x => x.Id))
                    .ForMember(dest => dest.RoleId,
                        src => src.MapFrom(x => x.RoleId));
        }
    }
}
