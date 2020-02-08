using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleDapperApp.Domain
{
	public interface IAirlineRepository
	{
		Task<Aircraft> GetAircraft(int id);
		Task<IEnumerable<Aircraft>> GetAircrafts();
		Task<IEnumerable<Aircraft>> GetAircraftsByModel(string model);
	}
}
