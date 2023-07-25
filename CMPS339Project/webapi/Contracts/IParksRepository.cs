using webapi.Models;

namespace webapi.Contracts
{
    public interface IParksRepository
    {
        public Task<IEnumerable<Parks>> GetParks();
        public Task<Parks> GetPark(int id);
        public Task<Parks> SavePark(Parks form);
        public Task<IEnumerable<Parks>> DeletePark(int id);
    }
}
