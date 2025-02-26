using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace eLearning.Infrastructure.DbContext;

public class DapperDbContext
{
    private readonly IConfiguration _config;
    private readonly string? _connectionString;

    public DapperDbContext(IConfiguration config)
    {
        _config = config;
        _connectionString = _config.GetConnectionString("SqlServerConnection");
    }

    // สร้าง Connection ใหม่ทุกครั้งที่เรียกใช้งาน เพื่อป้องกัน Connection Leak
    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}
