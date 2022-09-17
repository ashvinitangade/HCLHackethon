using Dapper;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using SharpGamingAPI.Common.Exceptions;
using System.Data.SqlClient;
using SharpGamingAPI.Common.Configuration;

namespace SharpGamingAPI.Generic
{
    public class GenericDB<TEntity> where TEntity : class
    {
        private readonly IDbConnection _con;
        private readonly DynamicParameters _dParam;
        public GenericDB()
        {
            _con = new SqlConnection(DBConfig.Connection);
            // _connection = new SQLiteConnection(_connectionString); // To use SQLite as data source 
            _con.Open();
            _dParam = new DynamicParameters();
        }
        public async Task<IEnumerable<TEntity>> SearchBySPOnly(string query)
        {
            var result = await _con.QueryAsync<TEntity>(query, commandType: CommandType.StoredProcedure);
            return result.AsList<TEntity>().Count > 0 ? result : throw new DataNotFoundException();
        }
        public async Task<IEnumerable<TEntity>> SearchByParam(string query, DynamicParameters param)
        {
            var result = await _con.QueryAsync<TEntity>(query, param, commandType: CommandType.StoredProcedure);
            return result.AsList<TEntity>().Count > 0 ? result : throw new DataNotFoundException();
        }
        public async Task<TEntity> SearchSingle(string query, DynamicParameters param)
        {
            var result = await _con.QueryFirstOrDefaultAsync<TEntity>(query, param, commandType: CommandType.StoredProcedure);
            //return result != null ? result : throw new DataNotFoundException();
            return result ?? throw new DataNotFoundException();
        }
        public async Task<SqlMapper.GridReader> SearchMultiple(string query, DynamicParameters param)
        {
            return await _con.QueryMultipleAsync(query, param, commandType: CommandType.StoredProcedure);
        }
        public async Task<TEntity> GetById(string query, long id)
        {
            _dParam.Add("@Id", id);
            var result = await _con.QueryFirstOrDefaultAsync<TEntity>(query, _dParam, commandType: CommandType.StoredProcedure);
            //return result != null ? result : throw new DataNotFoundException();
            return result ?? throw new DataNotFoundException();
        }
        //public async Task<TEntity> GetByModel(string query, DynamicParameters param)
        //{
        //    _dParam.Add("@Id", id);
        //    var result = await _con.QueryFirstOrDefaultAsync<TEntity>(query, _dParam, commandType: CommandType.StoredProcedure);
        //    //return result != null ? result : throw new DataNotFoundException();
        //    return result ?? throw new DataNotFoundException();
        //}
        public async Task<SqlMapper.GridReader> GetSingleRow(string query, DynamicParameters param)
        {
            return await _con.QueryMultipleAsync(query, param, commandType: CommandType.StoredProcedure);
        }
        public async Task<SqlMapper.GridReader> GetSingleRowBySPOnly(string query)
        {
            return await _con.QueryMultipleAsync(query, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Add(string query, DynamicParameters param)
        {
            param.Add("@UserId", UserConfig.UserId);
            return await _con.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> Update(string query, DynamicParameters param)
        {
            param.Add("@UserId", UserConfig.UserId);
            return await _con.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> Active(long id, long tableId)
        {
            _dParam.Add("@Id", id);
            _dParam.Add("@TableId", tableId);
            _dParam.Add("@UserId", UserConfig.UserId);
            return await _con.ExecuteAsync("USP_Active", _dParam, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> Delete(long id, long tableId)
        {
            _dParam.Add("@Id", id);
            _dParam.Add("@TableId", tableId);
            _dParam.Add("@UserId", UserConfig.UserId);
            return await _con.ExecuteAsync("USP_Delete", _dParam, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> DeleteCompleltely(long id)
        {
            _dParam.Add("@Id", id);
            return await _con.ExecuteAsync("USP_DeleteError", _dParam, commandType: CommandType.StoredProcedure);
        }
    }
}