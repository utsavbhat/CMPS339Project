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

        #region User Detail
        public async Task<UserDetails> GetUserDetail(int id)
        {
            var query = $@"SELECT * FROM UserDetails WHERE Id = {id}";
            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QueryFirstAsync<UserDetails>(query);
                return user;
            }
        }

        public async Task<UserDetails> SaveUserDetail(UserDetails user)
        {
            if (user.Id == 0)
            {
                var query = $@"Insert INTO UserDetails (Email, PhoneNumber, Address, UserID) Values (@Email, @PhoneNumber, @Address, @UserID)";
                using (var connection = _context.CreateConnection())
                {
                    var userReturn = await connection.QueryAsync(query, new { Email = user.Email, PhoneNumber = user.PhoneNumber, Address = user.Address, UserID = user.UserId });
                    return user;
                }
            }
            else
            {
                var query = $@"UPDATE UserDetails SET Email = '{user.Email}', PhoneNumber = '{user.PhoneNumber}', Address = '{user.Address}', UserID = {user.UserId} WHERE Id= {user.Id}";
                using (var connection = _context.CreateConnection())
                {
                    var userReturn = await connection.QueryAsync(query);
                    return user;
                }
            }
        }

        public async Task<bool> DeleteUserDetail(int id)
        {
            var query = $@"DELETE FROM UserDetails WHERE Id = {id}";
            using (var connection = _context.CreateConnection())
            {
                var userReturn = await connection.QueryAsync(query);
                return true;
            }
        }
        #endregion



    }
}
