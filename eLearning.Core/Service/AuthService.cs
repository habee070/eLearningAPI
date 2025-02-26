using AutoMapper;
using eLearning.Core.DTO.Authen;
using eLearning.Core.IRepository;
using eLearning.Core.IService;

namespace eLearning.Core.Service;

public class AuthService:IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public AuthService(IAuthRepository authRepository,ITokenService tokenService, IMapper mapper)
    {
        _authRepository = authRepository;
        _tokenService = tokenService;
        _mapper = mapper;
    }

    public async Task<AuthenResponseDto?> LoginAsync(AuthenRequestDto authenRequestDto)
    {
        var user = await _authRepository.LoginAsync(authenRequestDto);

        if (user == null)
        {
            return null;
        }

        var response = _mapper.Map<AuthenResponseDto>(user);

        response.Token = _tokenService.CreateToken(response);

        return response;
    }
}
