using Microsoft.EntityFrameworkCore;
using VideoStore.Backend.Models;

namespace VideoStore.Backend.Data
{
    public class VideoContext : DbContext
    {
        public VideoContext(DbContextOptions<VideoContext> options) : base(options)
        {
        }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<VideoCategory> VideoCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Video>()
                .HasKey(v => v.Id);

            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<VideoCategory>()
                .HasKey(vc => new { vc.VideoId, vc.CategoryId });

            modelBuilder.Entity<VideoCategory>()
                .HasOne(vc => vc.Video)
                .WithMany(v => v.VideoCategories)
                .HasForeignKey(vc => vc.VideoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<VideoCategory>()
                .HasOne(vc => vc.Category)
                .WithMany(c => c.VideoCategories)
                .HasForeignKey(vc => vc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
