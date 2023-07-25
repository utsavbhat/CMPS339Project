using Dapper;
using webapi.Context;
using webapi.Contracts;
using webapi.Models;

namespace webapi.Repository
{
    public class ParksRepository : IParksRepository
    {
        private readonly DapperContext _context;

        public ParksRepository(DapperContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Parks>> GetParks()
        {
            var query = "SELECT * FROM Parks";
            using (var connection = _context.CreateConnection())
            {
                var Parks = await connection.QueryAsync<Parks>(query);
                return Parks.ToList();
            }
        }

        public async Task<Parks> GetPark(int id)
        {
            var query = $@"SELECT * FROM Parks WHERE Id = {id}";
            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QueryFirstAsync<Parks>(query);
                return user;
            }
        }

        public async Task<Parks> SavePark(Parks park)
        {
            if (park.Id == 0)
            {
                var query = $@"Insert INTO Parks (Name) Values (@Name)";
                using (var connection = _context.CreateConnection())
                {
                    var parkReturn = await connection.QueryAsync(query, new { Name = park.Name });
                    return park;
                }
            }
            else
            {
                var query = $@"UPDATE Parks SET Name = '{park.Name}' WHERE Id= {park.Id}";
                using (var connection = _context.CreateConnection())
                {
                    var parkReturn = await connection.QueryAsync(query);
                    return park;
                }
            }
        }

        public async Task<IEnumerable<Parks>> DeletePark(int id)
        {
            var query = $@" DELETE FROM PARKS WHERE Id = {id}";
            using (var connection = _context.CreateConnection())
            {
                var parkReturn = await connection.QueryAsync(query);

                var Parks = await GetParks();
                return Parks;
            }
        }
    }
}
