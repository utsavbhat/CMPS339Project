using webapi.Models;

namespace webapi.Contracts
{
    public interface IUserRepository
    {
        public Task<IEnumerable<Users>> GetUsers();
        public Task<Users> GetUser(int id);
        public Task<Users> SaveUser(Users form);
        public Task<IEnumerable<Users>> DeleteUser(int id);


        //User Detail
        public Task<UserDetails> GetUserDetail(int id);
        public Task<UserDetails> SaveUserDetail(UserDetails form);
        public Task<bool> DeleteUserDetail(int id);
    }
}
