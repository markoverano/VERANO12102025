namespace VideoStore.Backend.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public string ThumbnailPath { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }

        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}
