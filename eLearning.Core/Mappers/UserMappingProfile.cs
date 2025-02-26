using AutoMapper;
using eLearning.Core.DTO.Authen;
using eLearning.Core.Entities.StoreProcedures;

namespace eLearning.Core.Mappers;

public class UserMappingProfile: Profile
{
    public UserMappingProfile()
    {
        CreateMap<Sp_Get_UserLogin, AuthenResponseDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username));
    }
}
