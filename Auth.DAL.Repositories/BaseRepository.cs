using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Auth.DAL.Repositories
{
    public abstract class BaseRepository(ILogger<BaseRepository> logger, IConfiguration configuration)
    {
        protected readonly string _connectionString = configuration.GetConnectionString("DefaultConnection");
        protected readonly ILogger _logger = logger;

        public async Task ExecuteAsync(string sql, object param)
        {
            try
            {
                using var connection = GetConnection();
                await connection.QueryAsync(sql, param);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка ExecuteAsync");
                throw;
            }
        }

        public async IAsyncEnumerable<T> Query<T>(string sql, object param = null)
        {
            using var connection = GetConnection();
            var reader = await connection.ExecuteReaderAsync(sql, param);
            var rowParser = reader.GetRowParser<T>();

            while (await reader.ReadAsync())
            {
                yield return rowParser(reader);
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null)
        {
            try
            {
                using var connection = GetConnection();

                return await connection.QueryAsync<T>(sql, param);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка QueryAsync");
                throw;
            }
        }
        public async Task<T> QuerySingleAsync<T>(string sql, object param = null)
        {
            try
            {
                using var connection = GetConnection();
                return await connection.QueryFirstAsync<T>(sql, param);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка QuerySingleAsync");
                throw;
            }
        }
        protected NpgsqlConnection GetConnection()
        {
            try
            {
                return new NpgsqlConnection(_connectionString);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка соединения в BaseRepository");
                throw;
            }
        }
    }
}
