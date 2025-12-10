using Microsoft.EntityFrameworkCore;
using VideoStore.Backend.Data;
using VideoStore.Backend.Models;

namespace VideoStore.Backend.Repositories
{
    public class VideoRepository : Repository<Video>, IVideoRepository
    {
        public VideoRepository(VideoContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Video>> GetAllWithCategoriesAsync()
        {
            return await Context.Videos
                .Include(v => v.VideoCategories)
                    .ThenInclude(vc => vc.Category)
                .OrderByDescending(v => v.CreatedDate)
                .ToListAsync();
        }

        public async Task<Video?> GetByIdWithCategoriesAsync(int id)
        {
            return await Context.Videos
                .Include(v => v.VideoCategories)
                    .ThenInclude(vc => vc.Category)
                .FirstOrDefaultAsync(v => v.Id == id);
        }
    }
}
