using eLearning.Core.DTO.Authen;

namespace eLearning.Core.IService;

public interface ITokenService
{
    string CreateToken(AuthenResponseDto authenResponseDto);
}
