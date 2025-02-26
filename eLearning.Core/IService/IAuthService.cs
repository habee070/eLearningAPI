using eLearning.Core.DTO.Authen;

namespace eLearning.Core.IService;

public interface IAuthService
{
    Task<AuthenResponseDto?> LoginAsync(AuthenRequestDto authenRequestDto);
}
