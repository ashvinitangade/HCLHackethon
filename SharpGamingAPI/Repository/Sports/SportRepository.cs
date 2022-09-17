using System.Threading.Tasks;
using SharpGamingAPI.Models;
using SharpGamingAPI.Generic;
using System.Collections.Generic;

namespace SharpGamingAPI.Repository
{
    public class SportsRepository : GenericDB<SportsResponseModel>, ISportsRepository
    {
        public Task<IEnumerable<SportsResponseModel>> Search(SearchSportsModel search)
        {
            return base.SearchByParam("USP_SearchSports", Param.SetParam(search));
        }
        public Task<SportsResponseModel> GetById(long id)
        {
            return base.GetById("Usp_GetSportsById", id);
        }
        public Task<int> Add(AddSportsModel model)
        {
            return base.Add("USP_AddSports", Param.SetParam(model));
        }
        public Task<int> Active(long id)
        {
            return base.Active(id, 2);
        }
        public Task<int> Delete(long id)
        {
            return base.Delete(id, 2);
        }
    }
}