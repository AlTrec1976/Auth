using Auth.Entities.Permissions;
using Auth.Entities.Roles;
using AutoMapper;

namespace Auth.BLL.Logic.Profiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            #region Маппинг Role
            //маппинг из RoleRequest в Role
            CreateMap<RoleRequest, Role>()
             .ForMember(dest => dest.RoleName, src => src.MapFrom(x => x.RoleName));
            //маппинг из Role в RoleDTO
            CreateMap<Role, RoleDTO>()
                .ForMember(dest => dest.RoleId, src => src.MapFrom(x => x.RoleId))
                .ForMember(dest => dest.RoleName, src => src.MapFrom(x => x.RoleName));
            //маппинг из RoleDTO в RoleResponse
            CreateMap<RoleDTO, RoleResponse>()
                .ForMember(dest => dest.RoleId, src => src.MapFrom(x => x.RoleId))
                .ForMember(dest => dest.RoleName, src => src.MapFrom(x => x.RoleName));
            //маппинг из RoleResponse в Role
            CreateMap<RoleResponse, Role>()
                .ForMember(dest => dest.RoleId, src => src.MapFrom(x => x.RoleId))
                .ForMember(dest => dest.RoleName, src => src.MapFrom(x => x.RoleName));
            #endregion

            #region Маппинг Permission

            CreateMap<PermissionRequest, Permission>()
             .ForMember(dest => dest.PermissionName, src => src.MapFrom(x => x.PermissionName));

            CreateMap<Permission, PermissionDTO>()
                .ForMember(dest => dest.PermissionId, src => src.MapFrom(x => x.PermissionId))
                .ForMember(dest => dest.PermissionName, src => src.MapFrom(x => x.PermissionName));

            CreateMap<PermissionDTO, PermissionResponse>()
                .ForMember(dest => dest.PermissionId, src => src.MapFrom(x => x.PermissionId))
                .ForMember(dest => dest.PermissionName, src => src.MapFrom(x => x.PermissionName));

            CreateMap<PermissionResponse, Permission>()
                .ForMember(dest => dest.PermissionId, src => src.MapFrom(x => x.PermissionId))
                .ForMember(dest => dest.PermissionName, src => src.MapFrom(x => x.PermissionName));
            #endregion

            CreateMap<RolePermissionRequest, RolePermissionDTO>()
                .ForMember(dest => dest.RoleId, src => src.MapFrom(x => x.RoleId))
                .ForMember(dest => dest.PermissionId, src => src.MapFrom(x => x.PermissionId));

        }
    }
}
