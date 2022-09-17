using Dapper;
using DapperParameters;
using System.Collections.Generic;

namespace SharpGamingAPI.Generic
{
    public static class Param
    {
        
        public static DynamicParameters SetParam(string name, object value)
        {
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@" + name, value);
            return dp;
        }
        public static DynamicParameters SetParam(object model)
        {
            DynamicParameters dp = new DynamicParameters();
            foreach (var prop in model.GetType().GetProperties())
            {
                dp.Add("@" + prop.Name, prop.GetValue(model, null));
            }
            return dp;
        }
        public static DynamicParameters SetParam<T>(object model, string listName, string listType, List<T> list)
        {
            DynamicParameters dp = new DynamicParameters();
            foreach (var prop in model.GetType().GetProperties())
            {
                if (listName == prop.Name)
                {
                    dp.AddTable("@" + listName, listType, list);
                }
                else
                {
                    dp.Add("@" + prop.Name, prop.GetValue(model, null));
                }
            }          
            return dp;
        }

    }
}