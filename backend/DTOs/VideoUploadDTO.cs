using System.ComponentModel.DataAnnotations;

namespace VideoStore.Backend.DTOs
{
    public class VideoUploadDTO
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
        public string Title { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string Description { get; set; } = string.Empty;

        public List<int> CategoryIds { get; set; } = new List<int>();
    }
}
