using VideoStore.Backend.Models;

namespace VideoStore.Backend.Repositories
{
    public interface IVideoRepository : IRepository<Video>
    {
        Task<IEnumerable<Video>> GetAllWithCategoriesAsync();
        Task<Video?> GetByIdWithCategoriesAsync(int id);
    }
}
