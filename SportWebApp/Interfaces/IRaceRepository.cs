using SportWebApp.Models;

namespace SportWebApp.Interfaces
{
    public interface IRaceRepository
    {
        Task<IEnumerable<Race>> GetAll();
        Task<Race> GetByIdAsync(int id);
        Task<Race> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<Race>> GetAllRacesByCity(string city);
        bool Add(Race race);
        bool Delete(Race race);
        bool Update(Race race);

        bool Save();


            
    }
}
