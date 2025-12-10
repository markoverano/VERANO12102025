using VideoStore.Backend.DTOs;
using VideoStore.Backend.Models;
using VideoStore.Backend.Repositories;

namespace VideoStore.Backend.Services
{
    public class VideoService : IVideoService
    {
        private readonly IVideoRepository _videoRepository;

        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public async Task<IEnumerable<VideoDTO>> GetAllVideosAsync()
        {
            var videos = await _videoRepository.GetAllWithCategoriesAsync();
            return videos.Select(MapToDTO);
        }

        public async Task<VideoDTO?> GetVideoByIdAsync(int id)
        {
            var video = await _videoRepository.GetByIdWithCategoriesAsync(id);
            return video != null ? MapToDTO(video) : null;
        }

        private static VideoDTO MapToDTO(Video video)
        {
            return new VideoDTO
            {
                Id = video.Id,
                Title = video.Title,
                Description = video.Description,
                ThumbnailUrl = video.ThumbnailPath,
                CreatedDate = video.CreatedDate,
                Categories = video.VideoCategories
                    .Select(vc => new CategoryDTO
                    {
                        Id = vc.Category.Id,
                        Name = vc.Category.Name
                    })
                    .ToList()
            };
        }
    }
}
