using Dapper;
using eLearning.Core.DTO.Authen;
using eLearning.Core.Entities.StoreProcedures;
using eLearning.Core.IRepository;
using eLearning.Infrastructure.DbContext;
using System.Data;

namespace eLearning.Infrastructure.Repository;

public class AuthRepository : IAuthRepository
{
    private readonly DapperDbContext _dbContext;
    public AuthRepository(DapperDbContext dapperDbContext)
    {
        _dbContext = dapperDbContext;
    }

    public async Task<Sp_Get_UserLogin?> LoginAsync(AuthenRequestDto authenRequestDto)
    {
        using var connection = _dbContext.CreateConnection();
        //var parameters = new DynamicParameters();
        var usrlogIn =  await connection.QueryFirstOrDefaultAsync<Sp_Get_UserLogin>("Sp_Get_UserLogin", authenRequestDto, commandType: CommandType.StoredProcedure);
        return usrlogIn;
    }
}
