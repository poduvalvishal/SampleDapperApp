using Microsoft.AspNetCore.Mvc;
using SampleDapperApp.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleDapperApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineController : ControllerBase
    {
        private IAirlineRepository _airlineRepo;
        public AirlineController(IAirlineRepository repo)
        {
            _airlineRepo = repo;
        }

        [HttpGet("{id}")]
        public async Task<Aircraft> Get(int id)
        {
            return await _airlineRepo.GetAircraft(id).ConfigureAwait(false);
        }

        [HttpGet]
        public async Task<IEnumerable<Aircraft>> Get()
        {
            return await _airlineRepo.GetAircrafts().ConfigureAwait(false);
        }

        [HttpGet("model/{model}")]
        public async Task<IEnumerable<Aircraft>> Get(string model)
        {
            return await _airlineRepo.GetAircraftsByModel(model).ConfigureAwait(false);
        }
    }
}