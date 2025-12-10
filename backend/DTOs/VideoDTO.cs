namespace VideoStore.Backend.DTOs
{
    public class VideoDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ThumbnailUrl { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public List<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();
    }
}
