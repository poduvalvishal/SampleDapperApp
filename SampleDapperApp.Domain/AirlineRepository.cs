using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SampleDapperApp.Domain
{
    public class AirlineRepository : IAirlineRepository
	{
        private AirlineConnection _connection;

        public AirlineRepository(AirlineConnection connection)
        {
            _connection = connection;
        }

		public async Task<Aircraft> GetAircraft(int id)
		{
            Aircraft aircraft;
            using (var connection = new SqlConnection(_connection.ConnectionString))
            {
                await connection.OpenAsync();
                var query = @"
                            SELECT 
                                   Id
                                  ,Manufacturer
                                  ,Model
                                  ,RegistrationNumber
                                  ,FirstClassCapacity
                                  ,RegularClassCapacity
                                  ,CrewCapacity
                                  ,ManufactureDate
                                  ,NumberOfEngines
                                  ,EmptyWeight
                                  ,MaxTakeoffWeight
                              FROM Aircraft WHERE Id = @Id";

                aircraft = await connection.QuerySingleAsync<Aircraft>(query, new { Id = id });
            }

            return aircraft;
        }

        public async Task<IEnumerable<Aircraft>> GetAircrafts()
        {
            IEnumerable<Aircraft> aircrafts;

            using (var connection = new SqlConnection(_connection.ConnectionString))
            {
                await connection.OpenAsync();
                var query = @"
                            SELECT 
                                   Id
                                  ,Manufacturer
                                  ,Model
                                  ,RegistrationNumber
                                  ,FirstClassCapacity
                                  ,RegularClassCapacity
                                  ,CrewCapacity
                                  ,ManufactureDate
                                  ,NumberOfEngines
                                  ,EmptyWeight
                                  ,MaxTakeoffWeight
                              FROM Aircraft";
                aircrafts = await connection.QueryAsync<Aircraft>(query);
            }
            return aircrafts;
        }

        public async Task<IEnumerable<Aircraft>> GetAircraftsByModel(string model)
        {
            IEnumerable<Aircraft> aircraft;

            using (var connection = new SqlConnection(_connection.ConnectionString))
            {
                await connection.OpenAsync();

                aircraft = await connection.QueryAsync<Aircraft>("GetAircraftByModel",
                                new { Model = model },
                                commandType: CommandType.StoredProcedure);
            }
            return aircraft;
        }
    }
}
