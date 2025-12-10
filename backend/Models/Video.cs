using System.ComponentModel.DataAnnotations;

namespace VideoStore.Backend.Models
{
    public class Video
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string FilePath { get; set; } = string.Empty;

        [StringLength(500)]
        public string ThumbnailPath { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<VideoCategory> VideoCategories { get; set; } = new List<VideoCategory>();
    }
}
