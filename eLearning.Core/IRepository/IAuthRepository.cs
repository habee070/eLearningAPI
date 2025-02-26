
using eLearning.Core.DTO.Authen;
using eLearning.Core.Entities.StoreProcedures;

namespace eLearning.Core.IRepository;

public interface IAuthRepository
{
    Task<Sp_Get_UserLogin?> LoginAsync(AuthenRequestDto authenRequestDto);
}
