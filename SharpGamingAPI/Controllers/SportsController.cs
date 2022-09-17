using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SharpGamingAPI.Models;


using System.Collections.Generic;

namespace SharpGamingAPI.Controllers
{
    [Route("sports")]
    [ApiController]    
    public class SportsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SportsController(IUnitOfWork IUnitOfWork)
        {
            _unitOfWork = IUnitOfWork;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SportsResponseModel>>> SearchAsync([FromQuery] SearchSportsModel search)
        {
            return Ok(await _unitOfWork.Sportss.Search(search));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SportsResponseModel>> GetByIdAsync(long id)
        {
            return Ok(await _unitOfWork.Sportss.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] AddSportsModel model)
        {
            return Ok(await _unitOfWork.Sportss.Add(model));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> ActiveByIdAsync(long id)
        {
            return Ok(await _unitOfWork.Sportss.Active(id));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteByIdAsync(long id)
        {
            return Ok(await _unitOfWork.Sportss.Delete(id));
        }
    }
}