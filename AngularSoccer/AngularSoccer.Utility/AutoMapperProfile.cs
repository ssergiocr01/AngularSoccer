using AngularSoccer.DTO;
using AngularSoccer.Models;
using AutoMapper;

namespace AngularSoccer.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            #region Rol
            CreateMap<Rol, RolDTO>().ReverseMap();
            #endregion

            #region Menu
            CreateMap<Menu>().ReverseMap();
            #endregion
        }
    }
}
