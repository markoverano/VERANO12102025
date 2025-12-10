using Microsoft.AspNetCore.Mvc;
using VideoStore.Backend.DTOs;
using VideoStore.Backend.Services;

namespace VideoStore.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoController : ControllerBase
    {
        private readonly IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoDTO>>> GetAllVideos()
        {
            var videos = await _videoService.GetAllVideosAsync();
            return Ok(videos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VideoDTO>> GetVideo(int id)
        {
            var video = await _videoService.GetVideoByIdAsync(id);

            if (video == null)
            {
                return NotFound();
            }

            return Ok(video);
        }
    }
}
