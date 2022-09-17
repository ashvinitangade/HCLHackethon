using System;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using SharpGamingAPI.Common.Configuration;

namespace SharpGamingAPI.Common.Exceptions
{
    public class LogException : IDisposable
    {
        private IDbConnection _con;
        private DynamicParameters _dynamicParameter;
        private CommandType _commandType;
        public LogException()
        {
            _con = new SqlConnection(DBConfig.Connection);
        }
        public void Dispose()
        {
            _con.Close();
        }
        public void Log(HttpContext context, Exception ex)
        {
            _commandType = CommandType.StoredProcedure;
            _dynamicParameter = new DynamicParameters();
            _dynamicParameter.Add("@URL", context.Request.Path.Value);
            _dynamicParameter.Add("@Message", ex.Message);
            _dynamicParameter.Add("@Description", ex.StackTrace.ToString());
            _dynamicParameter.Add("@AppType", "API");
            _con.Open();
            _con.ExecuteAsync("USP_AddError", _dynamicParameter, commandType: _commandType);
        }
    }
}

