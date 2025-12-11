namespace VideoStore.Backend.Services
{
    public interface IFileValidationService
    {
        bool IsValidFileType(string fileName);
        bool IsValidFileSize(long fileSize);
        bool ValidateMimeType(string contentType);
        string GetAllowedExtensions();
        long GetMaxFileSizeInBytes();
        string GetMaxFileSizeFormatted();
    }
}
