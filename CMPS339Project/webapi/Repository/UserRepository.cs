using Dapper;
using webapi.Context;
using webapi.Contracts;
using webapi.Models;

namespace webapi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;

        public UserRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Users>> GetUsers()
        {
            var query = "SELECT * FROM Users WHERE IsActive = 1";
            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<Users>(query);
                return users.ToList();
            }
        }

        public async Task<Users> GetUser(int id)
        {
            var query = $@"SELECT * FROM USERS WHERE Id = {id}";
            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QueryFirstAsync<Users>(query);
                return user;
            }
        }

        public async Task<Users> SaveUser(Users user)
        {
            if (user.Id == 0)
            {
                var query = $@"Insert INTO USERS (Username, Password, IsActive) Values (@Username, @Password, @IsActive)";
                using (var connection = _context.CreateConnection())
                {
                    var userReturn = await connection.QueryAsync(query, new { Username = user.Username, Password = user.Password, IsActive = true });
                    return user;
                }
            }
            else
            {
                var isActive = user.IsActive ? 1 : 0;
                var query = $@"UPDATE USERS SET Username = '{user.Username}', Password = '{user.Password}', IsActive = {isActive} WHERE Id= {user.Id}";
                using (var connection = _context.CreateConnection())
                {
                    var userReturn = await connection.QueryAsync(query);
                    return user;
                }
            }
        }

        public async Task<IEnumerable<Users>> DeleteUser(int id)
        { 
            var query = $@"UPDATE USERS SET IsActive = 0 WHERE Id = {id}";
            using (var connection = _context.CreateConnection())
            {
                var userReturn = await connection.QueryAsync(query);

                
                
                var users = await GetUsers();
                return users;
            }
        }
    }
}
