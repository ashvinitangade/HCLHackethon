using SharpGamingAPI.Models;
using SharpGamingAPI.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharpGamingAPI.Repository
{
    public interface ISportsRepository : IGetById<SportsResponseModel>, IAdd<AddSportsModel>, IActiveDelete
    {
        Task<IEnumerable<SportsResponseModel>> Search(SearchSportsModel search);
    }
}